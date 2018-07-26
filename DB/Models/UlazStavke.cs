using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class UlazStavke
    {
        public int UlazStavkeID { get; set; }
        public int UlazID { get; set; }
        public int ProizvodID { get; set; }
        public int Kolicina { get; set; }
        public float Cijena { get; set; }

        public Ulazi Ulazi { get; set; }
        public Proizvodi Proizvodi { get; set; }
    }
}