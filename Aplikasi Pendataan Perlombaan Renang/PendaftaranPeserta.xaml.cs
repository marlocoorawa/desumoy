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
        List<Perlombaan> listPerlombaan = new List<Perlombaan>();
        List<Kelompok> listKelompok = new List<Kelompok>();
        List<Peserta> listPeserta = new List<Peserta>();
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
            listKelompokCB.SelectedValuePath = "KodeKelompok";
            listKelompokCB.DisplayMemberPath = "NamaKelompok";
            listKelompokCB.ItemsSource = listKelompok;
            bulanLahir.SelectedValuePath = "Key";
            bulanLahir.DisplayMemberPath = "Value";
            tanggalLahir.ItemsSource = tanggal;
            bulanLahir.ItemsSource = bulan;
            listViewPeserta.ItemsSource = listPeserta;
            listViewPeserta.Items.Refresh();
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
            listPerlombaanCB.Items.Refresh();
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
            int i=1;
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            try {
                connection.Open();
                string query = "SELECT count(kode_sekolah) as jumlah FROM `sekolah` where kode_perlombaan = '" + listPerlombaanCB.SelectedValue.ToString() +"'";
                MessageBox.Show(query);
                MySqlCommand command = new MySqlCommand(query, connection);
                Int64 toBeKodeSekolah = (Int64)command.ExecuteScalar()+1;
                string kodeSekolah = toBeKodeSekolah.ToString("D3");
                query = "Insert into sekolah(kode_perlombaan,kode_sekolah, nama_sekolah, alamat, no_contact, email, nama_pendaftar) values('"+listPerlombaanCB.SelectedValue.ToString()+"','"+kodeSekolah+"','"+namaSekolah.Text+"','"+alamatSekolah.Text+"','"+noContact.Text+"','"+emailSekolah.Text+"','"+namaPendaftar.Text+"')";
                command.CommandText = query;
                command.ExecuteNonQuery();
                foreach (Peserta peserta in listPeserta) {
                    query = "INSERT INTO `peserta`(`kode_perlombaan`, `kode_sekolah`, `kode_peserta`, `kode_kelompok`, `nama_peserta`, `tanggal_lahir`, `jenis_kelamin`, `bebas_25m`, `bebas_50m`, `dada_25m`, `dada_50m`, `kupu_kupu_50m`, `punggung_50m`, `estafet_4x25m`) VALUES ('"
                    + listPerlombaanCB.SelectedValue.ToString() + "','"
                    + kodeSekolah + "','"
                    + i.ToString("D3") + "','"
                    + peserta.Kelompok.KodeKelompok + "','"
                    + peserta.NamaPeserta + "','"
                    + peserta.TanggalLahir.ToString("yyyy-MM-dd") + "',"
                    + peserta.JenisKelamin + ",'"
                    + peserta.Bebas25m + "','"
                    + peserta.Bebas50m + "','"
                    + peserta.Dada25m + "','"
                    + peserta.Dada50m + "','"
                    + peserta.KupuKupu + "','"
                    + peserta.Punggung + "','"
                    + peserta.Estafet + "')";
                    Console.WriteLine(query);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    i++;
                }
                MessageBox.Show("Lomba berhasil di simpan di database!");
                connection.Close();
                //kembaliKeMainMenu();
            } catch (Exception excep) {
                MessageBox.Show(excep.Message);
            }
        }

        private void listKelompokOpened(object sender, EventArgs e) {
            listKelompok.Clear();
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
                MessageBox.Show("Mohon pilih perlombaan yang akan diikuti terlebih dahulu!");
                return;
            }
        }

        private void listPerlombaanClosed(object sender, EventArgs e) {
            listKelompok.Clear();
        }

        private void simpanPesertaClick(object sender, RoutedEventArgs e) {
            //checking form
            if (namaPeserta.Text == "") {
                MessageBox.Show("Mohon isi nama peserta terlebih dahulu");
                return;
            }
            if(tanggalLahir.SelectedValue==null || bulanLahir.SelectedValue==null || tahunLahir.SelectedValue==null){
                MessageBox.Show("Mohon isi tanggal lahir terlebih dahulu");
                return;
            }
            if (listKelompokCB.SelectedValue == null) {
                MessageBox.Show("Mohon pilih kelompok terlebih dahulu");
                return;
            }
            if ((bool)lakiLaki.IsChecked && (bool)perempuan.IsChecked) {
                MessageBox.Show("Mohon pilih jenis kelamin terlebih dahulu");
            }
            //end checking form
            Peserta peserta = new Peserta();
            Kelompok kelompok = new Kelompok(listKelompokCB.SelectedValue.ToString(), listKelompokCB.Text);
            peserta.Kelompok = kelompok;
            peserta.NamaPeserta = namaPeserta.Text;
            peserta.TanggalLahir = new DateTime(int.Parse(tahunLahir.Text), int.Parse(bulanLahir.SelectedValue.ToString()), int.Parse(tanggalLahir.Text));
            if ((bool)lakiLaki.IsChecked) {
                peserta.JenisKelamin = true;
            } else {
                peserta.JenisKelamin = false;
            }
            peserta.TanggalLahirString = peserta.TanggalLahir.ToString("dd MMMM yyyy");
            peserta.Bebas25m = bebas25m.Text;
            peserta.Bebas50m = bebas50m.Text;
            peserta.Dada25m = dada25m.Text;
            peserta.Dada50m = dada50m.Text;
            peserta.KupuKupu = kupuKupu.Text;
            peserta.Punggung = punggung.Text;
            peserta.Estafet = estafet.Text;
            listPeserta.Add(peserta);
            listViewPeserta.Items.Refresh();
            //cleaning form
            namaPeserta.Text = "";
            tanggalLahir.SelectedValue = 0;
            bulanLahir.SelectedValue = 0;
            tahunLahir.SelectedValue = 0;
            listKelompokCB.SelectedValue = 0;
            lakiLaki.IsChecked = false;
            perempuan.IsChecked = false;
            bebas25m.Text = "";
            bebas50m.Text = "";
            dada25m.Text = "";
            dada50m.Text = "";
            kupuKupu.Text = "";
            punggung.Text = "";
            estafet.Text = "";
            //end cleaning form
        }

        private void hapusSemuaPesertaClick(object sender, RoutedEventArgs e) {
            listPeserta.Clear();
            listViewPeserta.Items.Refresh();
        }

        private void hapusPesertaDipilih(object sender, RoutedEventArgs e) {
            listPeserta.RemoveAt(listViewPeserta.SelectedIndex);
            listViewPeserta.Items.Refresh();
        }

    }
}
