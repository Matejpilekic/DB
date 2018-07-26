using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class Dobavljaci
    {
        public int DobavljacId { get; set; }
        public string Naziv { get; set; }
        public string KontaktOsoba { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public int ZiroRacun { get; set; }
        public string Napomena { get; set; }
        public bool Status { get; set; }

        public ICollection<Ulazi> Ulazis { get; set; }
    }
}