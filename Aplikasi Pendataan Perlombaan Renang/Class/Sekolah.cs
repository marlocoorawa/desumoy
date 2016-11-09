using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplikasi_Pendataan_Perlombaan_Renang.Class {
    class Sekolah {
        public string KodePerlombaan { get; set; }
        public string KodeSekolah { get; set; }
        public string NamaSekolah { get; set; }
        public string AlamatSekolah { get; set; }
        public string NoContact { get; set; }
        public string EmailSekolah { get; set; }
        public string NamaPendaftar { get; set; }
        public Sekolah(string kodeSekolah, string namaSekolah, string alamatSekolah, string noContact, string emailSekolah, string namaPendaftar) {
            KodeSekolah = kodeSekolah;
            NamaSekolah = namaSekolah;
            AlamatSekolah = alamatSekolah;
            NoContact = noContact;
            EmailSekolah = emailSekolah;
            NamaPendaftar = namaPendaftar;
        }
    }
}
