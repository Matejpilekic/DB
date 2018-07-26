using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class VrsteProizvoda
    {
        public int VrstaID { get; set; }
        public string Naziv { get; set; }

        public ICollection<Proizvodi> Proizvodis { get; set; }
    }
}