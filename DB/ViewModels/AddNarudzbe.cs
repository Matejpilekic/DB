using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB.ViewModels;
using DB.Models;

namespace DB.ViewModels
{
    public class AddNarudzbe
    {
        public NarudzbaVm Narudzba { get; set; }
        public List<Proizvodi> Proizvodi { get; set; }
    }
}