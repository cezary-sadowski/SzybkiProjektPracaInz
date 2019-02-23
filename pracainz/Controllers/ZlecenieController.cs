using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pracainz.Models;

namespace pracainz.Controllers
{
    public class ZlecenieController : Controller
    {
        private ERP_DB ctx;

        public ZlecenieController()
        {
            ctx = new ERP_DB();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        // GET: Zlecenie
        public ViewResult Index()
        {
            var tasks = GetTasks();
            foreach (var t in tasks)
            {
                t.OEE = CountOEE(t.Dostepnosc, t.Wydajnosc, t.Jakosc);
            }
            ctx.SaveChanges();

            return View(tasks);
        }

        private IEnumerable<Zlecenie> GetTasks()
        {
            return ctx.Zlecenie.ToList();
        }

        private double? CountOEE(double? dostepnosc, double? wydajnosc, double? jakosc)
        {
            if (dostepnosc == null || wydajnosc == null || jakosc == null)
                return null;

            else
                return (dostepnosc * wydajnosc * jakosc) / 1000;
        }
    }
}