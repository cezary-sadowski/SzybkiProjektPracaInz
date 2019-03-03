using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pracainz.Models;
using System.Linq.Expressions;

namespace pracainz.Controllers
{
    public class SpisPracownikowController : Controller
    {
        private ERP_DB ctx;

        public SpisPracownikowController()
        {
            ctx = new ERP_DB();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        // GET: SpisPracownikow
        public ViewResult Index()
        {
            var workers = GetActiveWorkers();
            return View(workers);
        }

        public ActionResult New()
        {
            return View();
        }

        private IEnumerable<SpisPracownikow> GetActiveWorkers() => ctx.SpisPracownikow.Where(sp => sp.CzyObecny == true).ToList();
    }
}