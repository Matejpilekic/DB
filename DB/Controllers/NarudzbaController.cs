using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB.Models;
using DB.ViewModels;
using System.Data.Entity;
using AutoMapper;

namespace DB.Controllers
{
    public class NarudzbaController : Controller
    {
        private Context _context;

        public NarudzbaController()
        {
            _context = new Context();
        }
        // GET: Narudzba
        public ActionResult Index()
        {
            return View();
        }
        
        [Route("Narudzba/CreatNarudzba")]
        [HttpGet]
        public ActionResult CreatNarudzba()
        {
            int kupacId=2;
            NarudzbaVm narudzba = new NarudzbaVm
            {
                BrojNarudzbe = 1,
                KupacID = kupacId,
                Datum = DateTime.Now,
                Status = false,
                Otkazano =null
            };
            Narudzbe narudzbaDb = new Narudzbe
            {
                BrojNarudzbe = narudzba.BrojNarudzbe,
                KupacID = narudzba.KupacID,
                Datum = narudzba.Datum,
                Status = narudzba.Status,
                Otkazano = null
            };
            _context.Narudzbes.Add(narudzbaDb);
            _context.SaveChanges();

            narudzba.NarudzbeID = narudzbaDb.NarudzbeID;

            var proizvodVm = _context.Proizvodis.Include(j => j.JediniceMjere).Include(v => v.VrsteProizvoda).ToList().Select(Mapper.Map<Proizvodi,ProizvodVm>);

            var model = new AddNarudzbe
            {
                Narudzba = narudzba,
                Proizvodi= proizvodVm

            };

            return View("NarudzbaStavka", model);
        }

        [Route("Narudzba/AddNarudzbaStavka")]
        [HttpPost]
        public ActionResult AddNarudzbaStavka(AddNarudzbe Vmodel)
        {
            NarudzbaStavke stavka = new NarudzbaStavke
            {
                NarudzbaID = Vmodel.Narudzba.NarudzbeID,
                ProizvodID = Vmodel.ProizvodID,
                Kolicina = Vmodel.Kolicina
            };
            _context.NarudzbaStavkes.Add(stavka);
            _context.SaveChanges();

            

            var model = new AddNarudzbe
            {
                Narudzba = Vmodel.Narudzba,
                Proizvodi = _context.Proizvodis.Include(j => j.JediniceMjere).Include(v => v.VrsteProizvoda).ToList().Select(Mapper.Map<Proizvodi, ProizvodVm>)

        };

            return View("NarudzbaStavka", model);
        }

        [Route("Narudzba/UpdateNarudzba/{id}")]
        [HttpGet]
        public ActionResult UpdateNarudzba(int id)
        {
            var narudzba = _context.Narudzbes.SingleOrDefault(i => i.NarudzbeID == id);

            narudzba.Status = true;
            _context.SaveChanges();



            return RedirectToAction("Index", "Proizvodi");
        }

        [Route("narudzba/getAll")]
        [HttpGet]
        public ActionResult GetAllNarudzbe()
        {
            var narudzbe = _context.Narudzbes.Include(k => k.Kupci).Where(s => s.Status ==true).ToList().Select(Mapper.Map<Narudzbe, NarudzbaVm>); 

            return View("Narudzbe",narudzbe);
        }

        [Route("narudzba/Details/{id}")]
        [HttpGet]
        public ActionResult GetNarudzba(int id)
        {
            var narudzba = _context.Narudzbes.SingleOrDefault(k => k.NarudzbeID== id);

            if(narudzba== null || narudzba.Status == false)
            {
                return HttpNotFound();
            }
            var narudzbaStavke = _context.NarudzbaStavkes.Where(i => i.NarudzbaID == id).Include(p => p.Proizvodi).ToList();

          
            return View("NarudzbaDetails", narudzbaStavke);
        }

        [HttpGet]
        public ActionResult OtkaziNarudzbu(int id)
        {
            var narudzba = _context.Narudzbes.SingleOrDefault(i => i.NarudzbeID == id);

            if(narudzba == null || narudzba.Status==false)
            {
                return HttpNotFound();
            }
            narudzba.Otkazano = DateTime.Now;

            _context.SaveChanges();

            return Redirect("");

        }






        /*
        [Route("Narudzba/AddNarudzbaStavka/{idN}/{idP}")]
        [HttpGet]
        public ActionResult AddNarudzbaStavka(int idN, int idP)
        {
            NarudzbaStavke stavka = new NarudzbaStavke
            {
                NarudzbaID = idN,
                ProizvodID = idP,
                Kolicina = 1
            };
            _context.NarudzbaStavkes.Add(stavka);
            _context.SaveChanges();

            Narudzbe narudzbaDb = _context.Narudzbes.SingleOrDefault(id => id.NarudzbeID == idN);

            NarudzbaVm narudzba = new NarudzbaVm
            {
                NarudzbeID = narudzbaDb.NarudzbeID,
                BrojNarudzbe = narudzbaDb.BrojNarudzbe,
                KupacID = narudzbaDb.KupacID,
                Datum = narudzbaDb.Datum,
                Status = narudzbaDb.Status,
                Otkazano = null
            };

            var model = new AddNarudzbe
            {
                Narudzba = narudzba,
                Proizvodi = _context.Proizvodis.Include(j => j.JediniceMjere).Include(v => v.VrsteProizvoda).ToList()

            };

            return View("AddProizvode", model);
        }*/
    }
}
