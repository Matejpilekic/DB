using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DB.Models
{
    public class Proizvodi
    {
        public int ProizvodID { get; set; }
        [Required]
        public string Naziv { get; set; }

        [Required]
        public string Sifra { get; set; }

        [Required]
        public double Cijena { get; set; }

        [Required]
        public int VrstaID { get; set; }

        [Required]
        public int JedinicaMjereID { get; set; }
        public string Slika { get; set; }
        public string SlikaThumb { get; set; }
        public bool Status { get; set; }

        public VrsteProizvoda VrsteProizvoda { get; set; }
        public JediniceMjere JediniceMjere { get; set; }

        public ICollection<Ocjene> Ocjenes { get; set; }
        public ICollection<NarudzbaStavke> NarudzbaStavkes { get; set; }
        public ICollection<IzlazStavke> IzlazStavkes { get; set; }
        public ICollection<UlazStavke> UlazStavkes { get; set; }
    }
}