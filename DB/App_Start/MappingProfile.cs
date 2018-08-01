using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB.Models;
using DB.ViewModels;

namespace DB.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to ViewModel
            this.CreateMap<Proizvodi, ProizvodVm>();
            this.CreateMap<Narudzbe, NarudzbaVm>();
            this.CreateMap<Skladista, SkladisteVm>();
            this.CreateMap<Dobavljaci, DobavljacVm>();
            this.CreateMap<Ulazi, UlaziVm>();


            // ViewModel to Domain
            this.CreateMap<ProizvodVm, Proizvodi>()
                .ForMember(c => c.ProizvodID, opt => opt.Ignore());
            this.CreateMap<NarudzbaVm, Narudzbe>()
                .ForMember(c => c.NarudzbeID, opt => opt.Ignore());
            this.CreateMap<SkladisteVm, Skladista>()
                .ForMember(c => c.SkladisteID, opt => opt.Ignore());
            this.CreateMap<DobavljacVm, Dobavljaci>()
                .ForMember(c => c.DobavljacId, opt => opt.Ignore());
            this.CreateMap<UlaziVm, Ulazi>()
                .ForMember(c => c.UlaziID, opt => opt.Ignore());
        }
         
    }
}