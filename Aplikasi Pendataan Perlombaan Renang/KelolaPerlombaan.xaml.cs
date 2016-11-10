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
            listSekolah.Clear();
            listPeserta.Clear();
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

        private void kembaliKeMenuUtamaClick(object sender, RoutedEventArgs e) {
            kembaliKeMainMenu();
        }

        private void buatAcara(object sender, RoutedEventArgs e) {
            int kodeAcara = 1;
            List<string> listKodeKelompok = new List<String>();
            List<string> listGayaRenang = new List<String>();
            listGayaRenang.Add("bebas_25m");
            listGayaRenang.Add("bebas_50m");
            listGayaRenang.Add("dada_25m");
            listGayaRenang.Add("dada_50m");
            listGayaRenang.Add("kupu_kupu_50m");
            listGayaRenang.Add("punggung_50m");
            listGayaRenang.Add("estafet_4x25m");
            List<Peserta> listPeserta = new List<Peserta>();
            bool jenisKelamin = true;
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            try {
                //getlist kelompok
                connection.Open();
                string query = "SELECT kode_kelompok FROM `peserta` where kode_perlombaan = '"+listPerlombaanCB.SelectedValue.ToString()+"' group by kode_kelompok";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    listKodeKelompok.Add(reader.GetString(0));
                }
                reader.Close();
                //end getlist kelompok

                foreach (string kodeKelompok in listKodeKelompok) {
                    foreach (string gayaRenang in listGayaRenang) {
                        jenisKelamin = true;
                        for(int i = 0; i<2 ;i++){
                            query = "SELECT kode_sekolah, kode_peserta, "+gayaRenang+" from peserta where kode_perlombaan = '" + listPerlombaanCB.SelectedValue.ToString() + "' and "+gayaRenang+" != 0 and jenis_kelamin = " + jenisKelamin + " order by "+gayaRenang+" ASC";
                            command.CommandText = query;
                            reader = command.ExecuteReader();
                            while (reader.Read()) {
                                listPeserta.Add(new Peserta() {
                                    KodeSekolah = reader.GetString(0),
                                    KodePeserta = reader.GetString(1),
                                    Bebas25m = reader.GetString(2)
                                });
                            }
                            reader.Close();
                            //DO SOME PARSE ABOUT FRIGGIN SERI HERE
                            //PLES
                            //DO SOME PARSE ABOUT FRIGGIN SERI HERE
                            if (listPeserta.Count != 0) {
                                foreach (Peserta peserta in listPeserta) {
                                    query = "INSERT INTO `hasil_lomba`(`kode_perlombaan`, `kode_sekolah`, `kode_peserta`, `kode_acara`, `gaya_renang`, `seri`, `waktu`) VALUES ('"
                                        + listPerlombaanCB.SelectedValue.ToString() + "','"
                                        + peserta.KodeSekolah + "','"
                                        + peserta.KodePeserta + "','"
                                        + kodeAcara.ToString("D3") + "','"
                                        + gayaRenang + "',"
                                        + "0,'"
                                        + peserta.Bebas25m + "')";
                                    command.CommandText = query;
                                    command.ExecuteNonQuery();
                                }
                                kodeAcara++;
                                listPeserta.Clear();
                            }
                                jenisKelamin = false;
                            }
                        }
                }
                //looping kelompok
                //select peserta where jenis kelamin true terus false and kotak ke(i) != 0 sort by 
                //looping kelamin
                //looping by gaya renang sort ascending
                //end looping kelamin
                //end looping kelompok
                query = "SELECT kode_kelompok FROM `peserta` where kode_perlombaan = '" + listPerlombaanCB.SelectedValue.ToString() + "' group by kode_kelompok";

                connection.Close();
            } catch (Exception excep) {
                MessageBox.Show(excep.Message + "\nTidak Terkoneksi Ke Database!");
            }
            listPerlombaanCB.Items.Refresh();
        }

        private void kembaliKeMainMenu() {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }
    }
}
