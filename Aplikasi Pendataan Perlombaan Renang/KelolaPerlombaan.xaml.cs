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
using Aplikasi_Pendataan_Perlombaan_Renang.Class;
using MySql.Data.MySqlClient;

namespace Aplikasi_Pendataan_Perlombaan_Renang {
    /// <summary>
    /// Interaction logic for KelolaPerlombaan.xaml
    /// </summary>
    public partial class KelolaPerlombaan : Window {
        List<Perlombaan> listPerlombaan = new List<Perlombaan>();
        List<Sekolah> listSekolah = new List<Sekolah>();
        List<Peserta> listPeserta = new List<Peserta>();
        public KelolaPerlombaan() {
            InitializeComponent();
            listPerlombaanCB.SelectedValuePath = "KodePerlombaan";
            listPerlombaanCB.DisplayMemberPath = "NamaPerlombaan";
            listPerlombaanCB.ItemsSource = listPerlombaan;
            listViewSekolah.ItemsSource = listSekolah;
            listViewPeserta.ItemsSource = listPeserta;
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

        private void listPerlombaanClosed(object sender, EventArgs e) {
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            //try {
                connection.Open();

                string query = "SELECT * FROM `sekolah`";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    listSekolah.Add(new Sekolah(reader.GetString(0),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4),reader.GetString(5)));
                }
                reader.Close();
                listViewSekolah.Items.Refresh();

                query = "SELECT * FROM `peserta`";
                command.CommandText = query;
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    listPeserta.Add(
                        new Peserta(
                            new Kelompok(reader.GetString(3),""),
                            reader.GetString(4),
                            reader.GetDateTime(5),
                            Convert.ToBoolean(reader.GetString(6)),
                            reader.GetString(7),
                            reader.GetString(8),
                            reader.GetString(9),
                            reader.GetString(10),
                            reader.GetString(11),
                            reader.GetString(12),
                            reader.GetString(13)
                         )
                    );
                }
                listViewPeserta.Items.Refresh();
                reader.Close();

                connection.Close();
            //} catch (Exception excep) {
            //    MessageBox.Show(excep.Message + "\nTidak Terkoneksi Ke Database!");
            //}
        }
    }
}
