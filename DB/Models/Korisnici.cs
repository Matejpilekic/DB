using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class Korisnici
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public bool Status { get; set; }

        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }

        public ICollection<Izlazi> Izlazis { get; set; }
        public ICollection<Ulazi> Ulazis { get; set; }
    }
}