using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB.Models;
using System.Data.Entity;
using DB.ViewModels;

namespace DB.Controllers
{
    public class ProizvodiController : Controller
    {

        private Context _context;

        public ProizvodiController()
        {
            _context = new Context();
        }

        // GET: Proizvodi
        [Route("proizvodi")]
        [HttpGet]
        public ActionResult Index()
        {
            var proizvodi = _context.Proizvodis.Include(j => j.JediniceMjere).Include(v => v.VrsteProizvoda).ToList();

            return View(proizvodi);
        }
        [Route("proizvodi/creat")]
        [HttpGet]
        public ActionResult Creat()
        {
            var jediniceMjere = _context.JediniceMjeres.ToList();
            var vrsteProizvoda = _context.VrsteProizvodas.ToList();

            var viewModel = new ProizvodAddVM
            {
                JediniceMjeres = jediniceMjere,
                VrsteProizvodas = vrsteProizvoda
            };
            return View("Creat",viewModel);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ProizvodAddVM model)
        {
            if (!ModelState.IsValid)
            {
                
                return View("Creat", model);
            }

           Proizvodi proizvod = new Proizvodi()
            {
                ProizvodID= model.ProizvodID,
                Sifra = model.Sifra,
                Slika="/asida",
                Naziv=model.Naziv,
                Cijena=model.Cijena,
                SlikaThumb="/asdma",
                Status=true,
                JedinicaMjereID=model.JedinicaMjereID,
                VrstaID= model.VrstaID
            };
            if(proizvod.ProizvodID == 0)
            {
                _context.Proizvodis.Add(proizvod);
            }
            else
            {
                var proizvodDB = _context.Proizvodis.Single(i => i.ProizvodID == proizvod.ProizvodID);

                proizvodDB.Naziv = proizvod.Naziv;
                proizvodDB.Sifra = proizvod.Sifra;
                proizvodDB.Cijena = proizvod.Cijena;
                proizvodDB.JedinicaMjereID = proizvod.JedinicaMjereID;
                proizvodDB.VrstaID = proizvod.VrstaID;               
            }

            
            _context.SaveChanges();

            return RedirectToAction("Index", "Proizvodi");
        }
        [Route("proizvodi/edit/{id}")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var proizvod = _context.Proizvodis.SingleOrDefault(i => i.ProizvodID == id);

            if(proizvod == null)
            {
                return HttpNotFound();
            }
            var viewModelProizvod = new ProizvodAddVM
            {
                JediniceMjeres = _context.JediniceMjeres.ToList(),
                VrsteProizvodas = _context.VrsteProizvodas.ToList(),
                ProizvodID= proizvod.ProizvodID,
                Naziv = proizvod.Naziv,
                Sifra = proizvod.Sifra,
                Cijena = proizvod.Cijena,
                VrstaID = proizvod.VrstaID,
                JedinicaMjereID = proizvod.JedinicaMjereID
            };
            return View("Creat", viewModelProizvod);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var proizvod = _context.Proizvodis.SingleOrDefault(i => i.ProizvodID == id);

            if(proizvod == null)
            {
                return HttpNotFound();
            }
            _context.Proizvodis.Remove(proizvod);
            _context.SaveChanges();

            return RedirectToAction("Index", "Proizvodi");
        }
    }
}