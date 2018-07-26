using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class Ulazi
    {
        public int UlaziID { get; set; }
        public string BrojFakture { get; set; }
        public DateTime Datum { get; set; }
        public float IznosRacuna { get; set; }
        public int PDV { get; set; }
        public string Napomena { get; set; }
        public int SkladisteID { get; set; }
        public int KorisnikID { get; set; }
        public int DobavljacID { get; set; }

        public Skladista Skladista { get; set; }
        public Korisnici Korisnici { get; set; }
        public Dobavljaci Dobavljaci { get; set; }

        public ICollection<UlazStavke> UlazStavkes { get; set; }
    }
}