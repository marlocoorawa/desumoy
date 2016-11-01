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


namespace Aplikasi_Pendataan_Perlombaan_Renang {
    /// <summary>
    /// Interaction logic for PendaftaranPeserta.xaml
    /// </summary>
    public partial class PendaftaranPeserta : Window {
        public PendaftaranPeserta() {
            List<string> listPerlombaan = new List<string>();
            InitializeComponent();
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;");
            connection.Open();
            string query = "SELECT kode_perlombaan,nama_perlombaan FROM `perlombaan`";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                listPerlombaan.Add(reader.GetString(1));
            }
            reader.Close();
            daftarLomba.ItemsSource = listPerlombaan;
            connection.Close();
        }
    }
}
