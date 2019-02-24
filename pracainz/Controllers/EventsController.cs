using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pracainz.Models;

namespace pracainz.Controllers
{
    public class EventsController : Controller
    {
        private ERP_DB ctx;

        public EventsController()
        {
            ctx = new ERP_DB();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        // GET: Events
        public ViewResult Index()
        {
            var ev = GetErpEvents();
            foreach (var e in ev)
            {
                if (e.Komentarz == null)
                    e.Komentarz = "brak komentarza";
            }

            return View(ev);
        }

        private IEnumerable<Events> GetErpEvents()
        {
            var ev = ctx.Events.ToList();
            foreach (var e in ev)
            {
                var worker = ctx.SpisPracownikow.Find(e.OperatorId);
                e.NazwaOperatora = worker.ImieNaziwsko;
            }

            return ev;
        }
    }
}