using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB.ViewModels;
using DB.Models;
using DB.ViewModels;

namespace DB.ViewModels
{
    public class AddNarudzbe
    {
        public NarudzbaVm Narudzba { get; set; }
        public IEnumerable<ProizvodVm> Proizvodi { get; set; }

        public int ProizvodID { get; set; }
        public string Naziv { get; set; }

        public int Kolicina { get; set; }
    }
}