using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Aplikasi_Pendataan_Perlombaan_Renang.Class;
using System.Data;

namespace Aplikasi_Pendataan_Perlombaan_Renang {
    /// <summary>
    /// Interaction logic for BuatLomba.xaml
    /// </summary>
    public partial class BuatLomba : Window {
        List<Kelompok> kelompok = new List<Kelompok>();
        byte[] tanggal = new byte[31] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31};
        KeyValuePair<byte, string>[] bulan = new KeyValuePair<byte, string>[12] {
            new KeyValuePair<byte,string>(1,"Januari"),
            new KeyValuePair<byte,string>(2,"Februari"),
            new KeyValuePair<byte,string>(3,"Maret"),
            new KeyValuePair<byte,string>(4,"April"),
            new KeyValuePair<byte,string>(5,"Mei"),
            new KeyValuePair<byte,string>(6,"Juni"),
            new KeyValuePair<byte,string>(7,"Juli"),
            new KeyValuePair<byte,string>(8,"Agustus"),
            new KeyValuePair<byte,string>(9,"September"),
            new KeyValuePair<byte,string>(10,"Oktober"),
            new KeyValuePair<byte,string>(11,"November"),
            new KeyValuePair<byte,string>(12,"Desember")
        };
        Int16 tahunSekarang = Int16.Parse(DateTime.Now.ToString("yyyy"));

        public BuatLomba() {
            InitializeComponent();
            kodeKelompok.GotFocus += kodeKelompokFocus;
            namaKelompok.GotFocus += namaKelompokFocus;
            listKelompok.ItemsSource = kelompok;
            tanggalLomba.ItemsSource = tanggal;
            tanggalLomba.SelectedIndex = 0;
            bulanLomba.SelectedValuePath = "Key";
            bulanLomba.DisplayMemberPath = "Value";
            bulanLomba.ItemsSource = bulan;
            bulanLomba.SelectedIndex = 0;
            for (int i = 0; i < 10; i++) {
                tahunLomba.Items.Add(tahunSekarang+i);
            }
            tahunLomba.SelectedIndex = 0;
        }

        private void tambahKelompok(object sender, RoutedEventArgs e) {
            Kelompok newKelompok = new Kelompok(this.kodeKelompok.Text, this.namaKelompok.Text);
            kelompok.Add(newKelompok);
            kodeKelompok.Text = "";
            namaKelompok.Text = "";
            listKelompok.Items.Refresh();
        }

        private void hapusKelompok(object sender, RoutedEventArgs e) {
            string test = ((Button)sender).Tag.ToString();
            kelompok.Remove(kelompok.Find(find => find.KodeKelompok==test));
            listKelompok.Items.Refresh();
        }

        private void hapusSemuaKelompok(object sender, RoutedEventArgs e) {
            kelompok.Clear();
            listKelompok.Items.Refresh();
        }

        private void kembaliKeMainMenuClick(object sender, RoutedEventArgs e) {
            kembaliKeMainMenu();
        }

        private void kembaliKeMainMenu() {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }


        private void kodeKelompokFocus(object sender, RoutedEventArgs e) {
            if (String.Equals(kodeKelompok.Text, "Kode Kelompok")) {
                kodeKelompok.Text = "";
            }
        }

        public void namaKelompokFocus(object sender, RoutedEventArgs e) {
            if (String.Equals(namaKelompok.Text, "Nama Kelompok")) {
                namaKelompok.Text = "";
            }
        }

        private void buatPerlombaan(object sender, RoutedEventArgs e) {
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            connection.Open();
            string combinedDate = tahunLomba.Text + "-" + bulanLomba.SelectedValue + "-" + tanggalLomba.Text;
            string query = "SELECT count(tanggal_perlombaan) AS jumlah FROM `perlombaan` WHERE tanggal_perlombaan = '"+combinedDate+"'";
            MySqlCommand command = new MySqlCommand(query, connection);

            //making key for lomba
            string kodePerlombaan = tanggalLomba.Text.PadLeft(2,'0')
                + bulanLomba.SelectedValue.ToString().PadLeft(2, '0')
                + tahunLomba.Text;
            Int64 keyLastPieceInt = (Int64)command.ExecuteScalar()+1;
            string keyLastPiece = keyLastPieceInt.ToString("D2");
            kodePerlombaan = kodePerlombaan + keyLastPiece;
            //end making key

            query = "insert into perlombaan(kode_perlombaan,nama_perlombaan,tanggal_perlombaan) values('"+ kodePerlombaan+ "','" + namaPerlombaan.Text + "','" + combinedDate + "')";
            command.CommandText = query;
            command.ExecuteNonQuery();
            for (int i = 0; i < listKelompok.Items.Count; i++) {
                Kelompok kelompokForQuery = (Kelompok)listKelompok.Items.GetItemAt(i);
                query = "insert into kelompok(kode_kelompok, kode_perlombaan, nama_kelompok) values('" + kelompokForQuery.KodeKelompok + "','" + kodePerlombaan +"','" + kelompokForQuery.NamaKelompok + "')";
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Lomba berhasil di simpan di database!");
            connection.Close();
            kembaliKeMainMenu();
        }
    }
}
