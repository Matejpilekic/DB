using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class NarudzbaStavke
    {
        public int NarudzbaStavkaID { get; set; }
        public int NarudzbaID { get; set; }
        public int ProizvodID { get; set; }
        public int Kolicina { get; set; }

        public Narudzbe Narudzbe { get; set; }
        public Proizvodi Proizvodi { get; set; }

    }
}