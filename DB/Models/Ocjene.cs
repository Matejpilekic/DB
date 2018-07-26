using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class Ocjene
    {
        public int OcjenaID { get; set; }
        public int ProizvodID { get; set; }
        public int KupacID { get; set; }
        public DateTime Datum { get; set; }
        public int Ocjena { get; set; }

        public Kupci Kupci { get; set; }
        public Proizvodi Proizvodi { get; set; }

    }
}