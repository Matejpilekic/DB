using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class Skladista
    {
        public int SkladisteID { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Opis { get; set; }

        public ICollection<Izlazi> Izlazis { get; set; }
        public ICollection<Ulazi> Ulazi { get; set; }
    }
}