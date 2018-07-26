using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class KorisniciUloge
    {
        public int KorisnikUlogaID { get; set; }
        public int KorisnikID { get; set; }
        public int UlogaID { get; set; }
        public DateTime? DatumIzmjene { get; set; }

        public Korisnici Korisnici { get; set; }
        public Uloge Uloges { get; set; }
    }
}