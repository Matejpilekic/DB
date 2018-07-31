using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB.ViewModels;
using DB.Models;
using AutoMapper;

namespace DB.Controllers
{
    public class SkladistaController : Controller
    {

        private Context _context;

        public SkladistaController()
        {
            _context = new Context();
        }

        // GET: Creat Skladiste
        [Route("Skladista/Creat")]
        [HttpGet]
        public ActionResult CreatSkladiste()
        {
            return View();
        }

        [Route("Skladista/AddSkladiste")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddSkladiste(SkladisteVm model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatSkladiste", model);
            }
            if(model.SkladisteID == 0)
            {
                var skladisteDB = Mapper.Map<SkladisteVm, Skladista>(model);
                _context.Skladistas.Add(skladisteDB);
            }
            else
            {
                var skladisteDb = _context.Skladistas.SingleOrDefault(i => i.SkladisteID == model.SkladisteID);

                Mapper.Map(model, skladisteDb);

            }
            
            _context.SaveChanges();

            return RedirectToAction("GetAllSkladista", "Skladista");

        }

        [Route("Skladista/Update/{id}")]
        [HttpGet]
        public ActionResult UpdateSkladiste(int id)
        {
            var skladisteDB = _context.Skladistas.SingleOrDefault(i => i.SkladisteID == id);
            if (skladisteDB==null)
            {
                return HttpNotFound();
            }
            var skladiste = Mapper.Map<Skladista, SkladisteVm>(skladisteDB);
            

            return View("CreatSkladiste", skladiste);

        }

        [Route("Skladista/Delete/{id}")]
        [HttpGet]
        public ActionResult RemoveSkladiste(int id)
        {
            var skladisteDB = _context.Skladistas.SingleOrDefault(i => i.SkladisteID==id);
            if (skladisteDB== null)
            {
                return HttpNotFound();
            }
            _context.Skladistas.Remove(skladisteDB);
            _context.SaveChanges();

            return RedirectToAction("GetAllSkladista", "Skladista");

        }

        [Route("Skladista/GetSkladista")]
        [HttpGet]
        public ActionResult GetAllSkladista()
        {
            var skladista = _context.Skladistas.ToList().Select(Mapper.Map<Skladista,SkladisteVm>);

            return View("Skladista",skladista);
        }


    }
}