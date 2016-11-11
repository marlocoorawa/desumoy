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
    /// Interaction logic for LihatHasilLomba.xaml
    /// </summary>
    public partial class KelolaHasilLomba : Window {
        List<string> listAcara = new List<string>();
        List<Perlombaan> listPerlombaan = new List<Perlombaan>();
        List<HasilLomba> listHasilLomba = new List<HasilLomba>();
        public KelolaHasilLomba() {
            InitializeComponent();
            listPerlombaanCB.ItemsSource = listPerlombaan;
            listPerlombaanCB.SelectedValuePath = "KodePerlombaan";
            listPerlombaanCB.DisplayMemberPath = "NamaPerlombaan";
            listAcaraCB.ItemsSource = listAcara;
            listViewHasilLomba.ItemsSource = listHasilLomba;

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

        //query select db

        private void listPerlombaanClosed(object sender, EventArgs e) {
            listAcara.Clear();
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            try {
                connection.Open();
                string query = "SELECT kode_acara FROM `hasil_lomba` where kode_perlombaan = '"+listPerlombaanCB.SelectedValue.ToString()+"' group by kode_acara";
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
                string query = "select nama_sekolah, nama_peserta, waktu_daftar, waktu_lomba from hasil_lomba, sekolah, peserta where hasil_lomba.kode_peserta = peserta.kode_peserta AND hasil_lomba.kode_sekolah = peserta.kode_sekolah AND peserta.kode_sekolah = sekolah.kode_sekolah AND hasil_lomba.kode_perlombaan = '"+listPerlombaanCB.SelectedValue.ToString()+"' and kode_acara = '"+listAcaraCB.SelectedValue.ToString()+"' order by waktu_lomba";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    listHasilLomba.Add(new HasilLomba(){
                        NamaSekolah = reader.GetString(0),
                        NamaPeserta = reader.GetString(1),
                        WaktuDaftar = reader.GetString(2),
                        WaktuLomba = reader.GetString(3)
                    });
                }
                reader.Close();
                connection.Close();
                listViewHasilLomba.Items.Refresh();
            } catch (Exception excep) {
                MessageBox.Show(excep.Message + "\nTidak Terkoneksi Ke Database!");
            }
        }

    }
}
