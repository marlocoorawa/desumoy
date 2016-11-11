using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using Aplikasi_Client_Perlombaan_Renang;

namespace Aplikasi_Client_Perlombaan_Renang {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        List<Perlombaan> listPerlombaan = new List<Perlombaan>();
        List<string> listAcara = new List<string>();
        List<HasilLomba> listHasilLomba = new List<HasilLomba>();
        public MainWindow() {
            InitializeComponent();
            listPerlombaanCB.ItemsSource = listPerlombaan;
            listPerlombaanCB.SelectedValuePath = "KodePerlombaan";
            listPerlombaanCB.DisplayMemberPath = "NamaPerlombaan";
            listAcaraCB.ItemsSource = listAcara;
            listPesertaCB.ItemsSource = listHasilLomba;
            listPesertaCB.DisplayMemberPath = "NamaPeserta";
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            try {
                connection.Open();
                string query = "SELECT kode_perlombaan,nama_perlombaan FROM `perlombaan`";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    listPerlombaan.Add(new Perlombaan(reader.GetString(0), reader.GetString(1)));
                }
                reader.Close();
                connection.Close();
            } catch (Exception e) {
                MessageBox.Show(e.Message + "\nTidak Terkoneksi Ke Database!");
            }
            listPerlombaanCB.Items.Refresh();
        }

        private void listPerlombaanClosed(object sender, EventArgs e) {
            listAcara.Clear();
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            try {
                connection.Open();
                string query = "SELECT kode_acara FROM `hasil_lomba` where kode_perlombaan = '" + listPerlombaanCB.SelectedValue.ToString() + "' group by kode_acara";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    listAcara.Add(reader.GetString(0));
                }
                reader.Close();
                connection.Close();
                listAcaraCB.Items.Refresh();
            } catch (Exception excep) {
                MessageBox.Show(excep.Message + "\nTidak Terkoneksi Ke Database!");
            }
        }

        private void listAcaraClosed(object sender, EventArgs e) {
            //select nama_sekolah, nama_peserta, waktu from hasil_lomba, sekolah, peserta where hasil_lomba.kode_peserta = peserta.kode_peserta AND hasil_lomba.kode_sekolah = peserta.kode_sekolah AND peserta.kode_sekolah = sekolah.kode_sekolah
            listHasilLomba.Clear();
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            try {
                connection.Open();
                string query = "select hasil_lomba.kode_sekolah, hasil_lomba.kode_peserta, nama_sekolah, nama_peserta, waktu_daftar, waktu_lomba from hasil_lomba, sekolah, peserta where hasil_lomba.kode_peserta = peserta.kode_peserta AND hasil_lomba.kode_sekolah = peserta.kode_sekolah AND peserta.kode_sekolah = sekolah.kode_sekolah AND hasil_lomba.kode_perlombaan = '" + listPerlombaanCB.SelectedValue.ToString() + "' and kode_acara = '" + listAcaraCB.SelectedValue.ToString() + "' order by waktu_lomba";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    listHasilLomba.Add(new HasilLomba() {
                        KodeSekolah = reader.GetString(0),
                        KodePeserta = reader.GetString(1),
                        NamaSekolah = reader.GetString(2),
                        NamaPeserta = reader.GetString(3),
                        WaktuDaftar = reader.GetString(4),
                        WaktuLomba = reader.GetString(5)
                    });
                }
                reader.Close();
                connection.Close();
                listPesertaCB.Items.Refresh();
            } catch (Exception excep) {
                MessageBox.Show(excep.Message + "\nTidak Terkoneksi Ke Database!");
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e) {
            HasilLomba selectedPeserta = new HasilLomba();
            selectedPeserta = (HasilLomba)listPesertaCB.SelectedItem;
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            try {
                connection.Open();
                string query = "UPDATE `hasil_lomba` SET `waktu_lomba` = '"+waktuLomba.Text+"' WHERE `hasil_lomba`.`kode_perlombaan` = '"
                    +listPerlombaanCB.SelectedValue.ToString()+"' AND `hasil_lomba`.`kode_sekolah` = '"
                    +selectedPeserta.KodeSekolah+"' AND `hasil_lomba`.`kode_peserta` = '"
                    +selectedPeserta.KodePeserta+"' AND `hasil_lomba`.`kode_acara` = '"
                    +listAcaraCB.SelectedValue.ToString()+"'";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Waktu lomba berhasil di input!");
                waktuLomba.Text = "";
            } catch (Exception excep) {
                MessageBox.Show(excep.Message + "\nTidak Terkoneksi Ke Database!");
            }
        }
    }
}
