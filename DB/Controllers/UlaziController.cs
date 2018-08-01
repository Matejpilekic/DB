using AutoMapper;
using DB.Models;
using DB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DB.Controllers
{
    public class UlaziController : Controller
    {

        private Context _context;

        public UlaziController()
        {
            _context = new Context();
        }

        [Route("Ulazi/CreatUlaz")]
        [HttpGet]
        public ActionResult CreatUlazi()
        {
            UlaziVm model = new UlaziVm
            {

                Skladista = _context.Skladistas.ToList().Select(Mapper.Map<Skladista, SkladisteVm>),
                Dobavljac = _context.Dobavljacis.ToList().Select(Mapper.Map<Dobavljaci, DobavljacVm>)
            };
            return View(model);
        }

        [Route("Ulazi/AddUlaz")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddUlaz(UlaziVm model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatUlazi", model);
            }
            if (model.UlaziID == 0)
            {
                model.KorisnikID = 1;
                var ulazDB = Mapper.Map<UlaziVm, Ulazi>(model);
                _context.Ulazis.Add(ulazDB);
            }
            else
            {
                var ulazDb = _context.Ulazis.SingleOrDefault(i => i.UlaziID == model.UlaziID);
                model.KorisnikID = 1;
                Mapper.Map(model, ulazDb);

            }

            _context.SaveChanges();

            return RedirectToAction("GetAllUlazi", "Ulazi");

        }

        [Route("Ulazi/Update/{id}")]
        [HttpGet]
        public ActionResult UpdateUlazi(int id)
        {
            var ulazDB = _context.Ulazis.SingleOrDefault(i => i.UlaziID == id);
            if (ulazDB == null)
            {
                return HttpNotFound();
            }
            var ulaz = Mapper.Map<Ulazi, UlaziVm>(ulazDB);

            ulaz.Skladista = _context.Skladistas.ToList().Select(Mapper.Map<Skladista,SkladisteVm>);
            ulaz.Dobavljac = _context.Dobavljacis.ToList().Select(Mapper.Map<Dobavljaci, DobavljacVm>);

            return View("CreatUlazi", ulaz);
        }

        [Route("Ulazi/Ulazi")]
        [HttpGet]
        public ActionResult GetAllUlazi()
        {
            var ulazi = _context.Ulazis.Include(i => i.Dobavljaci).Include(k => k.Korisnici).Include(s => s.Skladista).ToList();

            return View("Ulazi", ulazi);
        }


        [HttpGet]
        public ActionResult FormUlazStavke()
        {

            UlazStavkeVm model = new UlazStavkeVm
            {
                Proizvodi= _context.Proizvodis.ToList().Select(Mapper.Map<Proizvodi,ProizvodVm>),
                Ulazi= _context.Ulazis.ToList().Select(Mapper.Map<Ulazi,UlaziVm>)
            };
            return View("FormUlazStavke",model);
        }

        [HttpPost]
        public ActionResult AddUlazStavka(UlazStavkeVm model)
        {
            if (!ModelState.IsValid)
            {
                return View("FormUlazStavke", model);
            }

             _context.UlazStavkes.Add(model.UlazStavka);
          
            _context.SaveChanges();

            return RedirectToAction("GetAllUlazi", "Ulazi");
        }


    }
}