using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pracainz.Models;
using pracainz.Methods;

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
                t.OEE = Commons.CountOEE(t.Dostepnosc, t.Wydajnosc, t.Jakosc);
            }
            ctx.SaveChanges();

            return View(tasks);
        }

        public ContentResult Rtf() => Content(Commons.ConvertRTF());

        private IEnumerable<Zlecenie> GetTasks() => ctx.Zlecenie.ToList();
    }
}