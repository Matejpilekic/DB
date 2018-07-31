using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.ViewModels
{
    public class NarudzbaVm
    {
        public int NarudzbeID { get; set; }
        public int BrojNarudzbe { get; set; }
        public int KupacID { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public DateTime? Otkazano { get; set; }

        public Kupci Kupci { get; set; }
        //public ICollection<NarudzbaStavke> NarudzbaStavkes { get; set; }
    }
}