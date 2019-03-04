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

        public ViewResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(SpisPracownikow worker)
        {
            if (!ModelState.IsValid)
            {
                return View("New", worker);
            }

            if(worker.SpisID == 0)
                ctx.SpisPracownikow.Add(worker);

            else
            {
                var workerInDb = ctx.SpisPracownikow.Single(sp => sp.SpisID == worker.SpisID);
                workerInDb.CzyObecny = worker.CzyObecny;
                workerInDb.Email = worker.Email;
                workerInDb.ImieNaziwsko = worker.ImieNaziwsko;
                workerInDb.Login = worker.Login;
                workerInDb.Telefon = worker.Telefon;
                workerInDb.TypPracownika = worker.TypPracownika;
            }

            ctx.SaveChanges();

            return RedirectToAction("Index", "SpisPracownikow");
        }

        public ActionResult Edit(int id)
        {
            var worker = ctx.SpisPracownikow.SingleOrDefault(sp => sp.SpisID == id);

            if (worker == null)
                return HttpNotFound();

            return View("New", worker);
        }

        private IEnumerable<SpisPracownikow> GetActiveWorkers() => ctx.SpisPracownikow.Where(sp => sp.CzyObecny == true).ToList();
    }
}