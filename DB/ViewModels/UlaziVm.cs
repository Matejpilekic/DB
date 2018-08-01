using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DB.ViewModels
{
    public class UlaziVm
    {
        public int UlaziID { get; set; }

        [Required]
        public string BrojFakture { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        [Required]
        public double IznosRacuna { get; set; }

        [Required]
        public int PDV { get; set; }

        public string Napomena { get; set; }

        [Required]
        public int SkladisteID { get; set; }
      
        public int KorisnikID { get; set; }

        [Required]
        public int DobavljacID { get; set; }

        public IEnumerable<SkladisteVm> Skladista { get; set; }
        public IEnumerable<DobavljacVm> Dobavljac { get; set; }
    }
}