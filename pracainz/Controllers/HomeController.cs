using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pracainz.Models;

namespace pracainz.Controllers
{
    public class HomeController : Controller
    {
        private ERP_DB ctx;

        public HomeController()
        {
            ctx = new ERP_DB();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        public ActionResult Index()
        {
            var zlecenie = GetZlecenie();
            return View(zlecenie);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private Zlecenie GetZlecenie() => ctx.Zlecenie.FirstOrDefault(z => z.ID == 1);
    }
}