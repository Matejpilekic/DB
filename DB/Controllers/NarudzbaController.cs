using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DB.Models;
using DB.ViewModels;
using System.Data.Entity;

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
        /*
        [Route("Narudzba/CreatNarudzbaStavke")]
        [HttpPost]
        public ActionResult CreatNarudzbaStavke(AddNarudzbe model)
        {
            model.KupacId = 1;
            var kupac = _context.Kupcis.SingleOrDefault(i => i.KupacID == model.KupacId);

            if (kupac == null)
            {
                return HttpNotFound();
            }

            var proizvodi = _context.Proizvodis.Where(m => model.ProizvodiId.Contains(m.ProizvodID)).ToList();

            if(proizvodi.Count == 0)
            {
                return RedirectToAction("Index", "Proizvodi");
            }
            else
            {
                int narudzbaid = CreatNarudzba(model.KupacId);

                foreach (var proivod in proizvodi)
                {
                    NarudzbaStavke narudzbaStavka = new NarudzbaStavke
                    {
                        NarudzbaID = narudzbaid,
                        ProizvodID = proivod.ProizvodID,
                        Kolicina = 1
                    };
                    _context.NarudzbaStavkes.Add(narudzbaStavka);
                }
                _context.SaveChanges();

                return RedirectToAction("Index", "Proizvodi");
            }
           
            
        } */
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

            

            var model = new AddNarudzbe
            {
                Narudzba = narudzba,
                Proizvodi= _context.Proizvodis.Include(j => j.JediniceMjere).Include(v => v.VrsteProizvoda).ToList()

            };

            return View("AddProizvode",model);
        }

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
                NarudzbeID=narudzbaDb.NarudzbeID,
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
    }
}
