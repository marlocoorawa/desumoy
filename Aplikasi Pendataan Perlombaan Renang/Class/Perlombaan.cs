using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplikasi_Pendataan_Perlombaan_Renang.Class {
    class Perlombaan {
        public string KodePerlombaan { get; set; }
        public string NamaPerlombaan { get; set; }
        public Perlombaan(string _kodePerlombaan, string _namaPerlombaan) {
            KodePerlombaan = _kodePerlombaan;
            NamaPerlombaan = _namaPerlombaan;
        }
    }
}
