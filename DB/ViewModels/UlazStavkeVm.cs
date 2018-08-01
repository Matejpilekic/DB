using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB.ViewModels
{
    public class UlazStavkeVm
    {
        public UlazStavke UlazStavka { get; set; }

        public IEnumerable<ProizvodVm> Proizvodi { get; set; }
        public IEnumerable<UlaziVm> Ulazi { get; set; }

    }
}