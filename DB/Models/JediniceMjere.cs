using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class JediniceMjere
    {
        public int JediniceMjereID { get; set; }
        public string Naziv { get; set; }

        public ICollection<Proizvodi> Proizvodis { get; set; }
    }
}