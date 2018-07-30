using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB.Models;

namespace DB.ViewModels
{
    public class ProizvodAddVM
    {
        public IEnumerable<JediniceMjere> JediniceMjeres { get; set; }
        public IEnumerable<VrsteProizvoda> VrsteProizvodas { get; set; }

        public int ProizvodID { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public double Cijena { get; set; }
        public int VrstaID { get; set; }
        public int JedinicaMjereID { get; set; }

    }
}