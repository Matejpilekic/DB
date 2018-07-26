using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class Uloge
    {
        public int UlogaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }
    }
}