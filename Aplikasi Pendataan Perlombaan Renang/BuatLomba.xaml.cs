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
using Aplikasi_Pendataan_Perlombaan_Renang.Class;

namespace Aplikasi_Pendataan_Perlombaan_Renang {
    /// <summary>
    /// Interaction logic for BuatLomba.xaml
    /// </summary>
    public partial class BuatLomba : Window {
        List<Kelompok> kelompok = new List<Kelompok>();

        public BuatLomba() {
            InitializeComponent();
            Kelompok a = new Kelompok("A", "Cek Nama");
            kelompok.Add(a);
            listKelompok.ItemsSource = kelompok;
        }

        private void tambahKelompok(object sender, RoutedEventArgs e) {
            Kelompok newKelompok = new Kelompok(this.kodeKelompok.Text, this.namaKelompok.Text);
            kelompok.Add(newKelompok);
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

        private void kembaliKeMainMenu(object sender, RoutedEventArgs e) {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }
    }
}
