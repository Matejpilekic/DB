using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.ViewModels
{
    public class ProizvodVm
    {

        public int ProizvodID { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public double Cijena { get; set; }
        public int VrstaID { get; set; }
        public int JedinicaMjereID { get; set; }

        public VrsteProizvoda VrsteProizvoda { get; set; }
        public JediniceMjere JediniceMjere { get; set; }
    }
}