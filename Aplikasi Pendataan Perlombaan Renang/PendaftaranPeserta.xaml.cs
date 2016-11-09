using System;
using System.Collections.Generic;
using System.Linq;
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


namespace Aplikasi_Pendataan_Perlombaan_Renang {
    /// <summary>
    /// Interaction logic for PendaftaranPeserta.xaml
    /// </summary>
    public partial class PendaftaranPeserta : Window {
        List<Kelompok> listKelompok = new List<Kelompok>();
        List<Perlombaan> listPerlombaan = new List<Perlombaan>();
        byte[] tanggal = new byte[31] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31 };
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

        public PendaftaranPeserta() {
            InitializeComponent();
            listPerlombaanCB.SelectedValuePath = "KodePerlombaan";
            listPerlombaanCB.DisplayMemberPath = "NamaPerlombaan";
            listPerlombaanCB.ItemsSource = listPerlombaan;
            listPerlombaanCB.Items.Refresh();
            listKelompokCB.SelectedValuePath = "KodeKelompok";
            listKelompokCB.DisplayMemberPath = "NamaKelompok";
            listKelompokCB.ItemsSource = listKelompok;
            bulanLahir.SelectedValuePath = "Key";
            bulanLahir.DisplayMemberPath = "Value";
            tanggalLahir.ItemsSource = tanggal;
            bulanLahir.ItemsSource = bulan;
            for (int i = 1970; i <= tahunSekarang; i++) {
                tahunLahir.Items.Add(i);
            }

            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            try {
                connection.Open();
                string query = "SELECT kode_perlombaan,nama_perlombaan FROM `perlombaan`";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    listPerlombaan.Add(new Perlombaan(reader.GetString(0),reader.GetString(1)));
                }
                reader.Close();
                connection.Close();
            } catch (Exception e) {
                MessageBox.Show(e.Message + "\nTidak Terkoneksi Ke Database!");
            }
        }

        private void kembaliKeMainMenuClick(object sender, RoutedEventArgs e) {
            kembaliKeMainMenu();
        }

        private void kembaliKeMainMenu() {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }

        private void simpanKeDatabaseClick(object sender, RoutedEventArgs e) {
            //MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            //try {
            //    //connection.Open();
            //    string query = "SELECT count(kode_sekolah) FROM `sekolah` where kode_perlombaan = " + listPerlombaanCB.SelectedValue.ToString();
            //    MessageBox.Show(query);
            //    MySqlCommand command = new MySqlCommand(query, connection);
            //    int toBeKodeSekolah = (int)command.ExecuteScalar();
            //    string kodeSekolah = toBeKodeSekolah.ToString("D3");
            //    query = "Insert into sekolah(kode_perlombaan,kode_sekolah, nama_sekolah, alamat, no_contact, email, nama_pendaftar) values('"+listPerlombaanCB.SelectedValue.ToString()+"','"+kodeSekolah+"','"+namaSekolah+"','"+alamatSekolah+"','"+noContact+"','"+emailSekolah+"','"+namaPendaftar+"')";
            //    NEED TO BE CONTINUE LATER
            //}
            if ((bool)lakiLaki.IsChecked) {
                MessageBox.Show("Laki - laki");
            } else {
                MessageBox.Show("Perempuan");
            }
        }

        private void listKelompokOpened(object sender, EventArgs e) {
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            try {
                connection.Open();
                string query = "SELECT kode_kelompok,nama_kelompok FROM `kelompok` where kode_perlombaan = '" + listPerlombaanCB.SelectedValue.ToString() + "'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    listKelompok.Add(new Kelompok(reader.GetString(0), reader.GetString(1)));
                }
                listKelompokCB.Items.Refresh();
                reader.Close();
                connection.Close();
            } catch (Exception excep) {
                MessageBox.Show("Mohon pilih yang akan diikuti terlebih dahulu!");
            }
        }

        private void listPerlombaanClosed(object sender, EventArgs e) {
            listKelompok.Clear();
        }

    }
}
