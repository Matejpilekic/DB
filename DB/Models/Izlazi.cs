using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class Izlazi
    {
        public int IzlazID { get; set; }
        public int BrojRacuna { get; set; }
        public DateTime Datum { get; set; }
        public int KorisnikID { get; set; }
        public bool Zakljucen { get; set; }
        public float IznosBezPDV { get; set; }
        public float IznosSaPDV { get; set; }
        public int NaruzdbaID { get; set; }
        public int SkladisteID { get; set; }

        public Korisnici Korisnici { get; set; }
        public Narudzbe Narudzbe { get; set; }
        public Skladista Skladista { get; set; }

        public ICollection<IzlazStavke> IzlazStavke { get; set; }
    }
}