using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikasi_Pendataan_Perlombaan_Renang.Class {
    class Kelompok {
        public string KodeKelompok { get; set; }
        public string NamaKelompok { get; set; }

        public Kelompok(string kodeKelompok, string namaKelompok) {
            KodeKelompok = kodeKelompok;
            NamaKelompok = namaKelompok;
        }

    }
}
