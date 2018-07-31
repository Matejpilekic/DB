using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.ViewModels
{
    public class SkladisteVm
    {
        
        public int SkladisteID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Opis { get; set; }
    }
}