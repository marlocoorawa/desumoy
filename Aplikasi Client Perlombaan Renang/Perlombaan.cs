using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikasi_Client_Perlombaan_Renang {
    class Perlombaan {
        public string KodePerlombaan { get; set; }
        public string NamaPerlombaan { get; set; }
        public Perlombaan(string _kodePerlombaan, string _namaPerlombaan) {
            KodePerlombaan = _kodePerlombaan;
            NamaPerlombaan = _namaPerlombaan;
        }
    }
}
