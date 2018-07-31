using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB.Controllers
{
    public class UlaziController : Controller
    {
        // GET: Ulazi
        public ActionResult Index()
        {
            return View();
        }

        [Route("Ulazi/CreatUlaz")]
        [HttpGet]
        public ActionResult CreatUlazi()
        {
            return View();
        }
    }
}