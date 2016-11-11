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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aplikasi_Pendataan_Perlombaan_Renang {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainMenu : Window {
        public MainMenu() {
            InitializeComponent();
        }

        private void buatPerlombaan(object sender, RoutedEventArgs e) {
            BuatLomba lombaWindow = new BuatLomba();
            lombaWindow.Show();
            this.Close();
        }

        private void exit(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void pendaftaranPeserta(object sender, RoutedEventArgs e) {
            PendaftaranPeserta pendaftaranPesertaWindow = new PendaftaranPeserta();
            pendaftaranPesertaWindow.Show();
            this.Close();
        }

        private void kelolaPerlombaan(object sender, RoutedEventArgs e) {
            KelolaPerlombaan kelolaPerlombaanWindow = new KelolaPerlombaan();
            kelolaPerlombaanWindow.Show();
            this.Close();
        }

        private void kelolaHasilPerlombaan(object sender, RoutedEventArgs e) {
            KelolaHasilLomba kelolaHasilPerlombaanWindow = new KelolaHasilLomba();
            kelolaHasilPerlombaanWindow.Show();
            this.Close();
        }
    }
}
