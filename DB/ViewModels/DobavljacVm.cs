using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DB.ViewModels
{
    public class DobavljacVm
    {
        public int DobavljacId { get; set; }

        [Required]
        public string Naziv { get; set; }

        [Required]
        public string KontaktOsoba { get; set; }

        [Required]
        public string Adresa { get; set; }

        [Required]
        public string Telefon { get; set; }

        public string Fax { get; set; }
        public string Web { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int ZiroRacun { get; set; }
        public string Napomena { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}