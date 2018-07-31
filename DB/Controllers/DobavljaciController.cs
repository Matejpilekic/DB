using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DB.Models;
using DB.ViewModels;

namespace DB.Controllers
{
    public class DobavljaciController : Controller
    {
        private Context _context;

        public DobavljaciController()
        {
            _context = new Context();
        }

        // GET: Dobavljaci
        [Route("Dobavljaci/Creat")]
        [HttpGet]
        public ActionResult CreatFormDobavljac()
        {
            return View("CreatDobavljac");
        }

        [Route("Dobavljaci/CreatDobavljac")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreatDobavljac(DobavljacVm model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreatDobavljac", model);
            }
            if (model.DobavljacId == 0)
            {
                var dobavljacDB = Mapper.Map<DobavljacVm, Dobavljaci>(model);
                _context.Dobavljacis.Add(dobavljacDB);
            }
            else
            {
                var dobavljacDb = _context.Dobavljacis.SingleOrDefault(i => i.DobavljacId == model.DobavljacId);

                Mapper.Map(model, dobavljacDb);

            }

            _context.SaveChanges();

            return RedirectToAction("GetDobavljaci", "Dobavljaci");

        }

        [Route("Dobavljaci/Update/{id}")]
        [HttpGet]
        public ActionResult UpdateDobavljac(int id)
        {
            var dobavljacDB = _context.Dobavljacis.SingleOrDefault(i => i.DobavljacId == id);
            if (dobavljacDB == null)
            {
                return HttpNotFound();
            }
            var dobavljac = Mapper.Map<Dobavljaci, DobavljacVm>(dobavljacDB);


            return View("CreatDobavljac", dobavljac);
        }

        [Route("Dobavljaci/UpdateStatus/{id}")]
        [HttpGet]
        public ActionResult UpdateStatus(int id)
        {
            var dobavljacDB = _context.Dobavljacis.SingleOrDefault(i => i.DobavljacId == id);
            if (dobavljacDB == null)
            {
                return HttpNotFound();
            }
            dobavljacDB.Status = false;
            _context.SaveChanges();
            
            return RedirectToAction("GetDobavljaci","Dobavljaci");
        }

        [Route("Dobavljaci/GetDobavljaci")]
        [HttpGet]
        public ActionResult GetDobavljaci()
        {
            var dobavljaci = _context.Dobavljacis.Where(s => s.Status==true).ToList().Select(Mapper.Map<Dobavljaci, DobavljacVm>);

            return View("GetAllDobavljace", dobavljaci);
        }
    }
}