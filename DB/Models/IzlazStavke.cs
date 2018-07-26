using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class IzlazStavke
    {
        public int IzlazStavkaID { get; set; }
        public int IzlazID { get; set; }
        public int ProizvodID { get; set; }
        public int Kolicina { get; set; }
        public float Cijena { get; set; }
        public int Popust { get; set; }

        public Izlazi Izlazi { get; set; }
        public Proizvodi Proizvodi { get; set; }
    }
}