using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplikasi_Pendataan_Perlombaan_Renang.Class {
    class Peserta {
        public string KodePerlombaan { get; set; }
        public string KodeSekolah { get; set; }
        public string KodePeserta { get; set; }
        public Kelompok Kelompok { get; set; }
        public string NamaPeserta { get; set; }
        public DateTime TanggalLahir { get; set; }
        public string TanggalLahirString { get; set; }
        public bool JenisKelamin { get; set; }
        public string Bebas25m { get; set; }
        public string Bebas50m { get; set; }
        public string Dada25m { get; set; }
        public string Dada50m { get; set; }
        public string KupuKupu { get; set; }
        public string Punggung { get; set; }
        public string Estafet { get; set; }
        public Peserta() { }
        public Peserta(Kelompok kelompok, string namaPeserta, DateTime tanggalLahir, bool jenisKelamin, string bebas25m, string bebas50m, string dada25m, string dada50m, string kupuKupu, string punggung, string estafet) {
            Kelompok = kelompok;
            NamaPeserta = namaPeserta;
            //string[] tanggalSplit = new string[3];
            //tanggalSplit = tanggalLahir.Split('-');
            //TanggalLahir = new DateTime(Convert.ToInt32(tanggalSplit[0]), Convert.ToInt32(tanggalSplit[1]), Convert.ToInt32(tanggalSplit[2]));
            TanggalLahir = tanggalLahir;
            TanggalLahirString = TanggalLahir.ToString("dd MMMM yyyy");
            JenisKelamin = jenisKelamin;
            Bebas25m = bebas25m;
            Bebas50m = bebas50m;
            Dada25m = dada25m;
            Dada50m = dada50m;
            KupuKupu = kupuKupu;
            Punggung = punggung;
            Estafet = estafet;
        }
    }
}
