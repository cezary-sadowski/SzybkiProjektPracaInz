using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pracainz.Models;

namespace pracainz.Controllers
{
    public class TraceabilityController : Controller
    {
        private ERP_DB ctx;

        public TraceabilityController()
        {
            ctx = new ERP_DB();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        // GET: Traceability
        public ViewResult Index()
        {
            var trace = GetTrace();

            return View(trace);
        }

        private IEnumerable<Traceability> GetTrace() => ctx.Traceability.ToList();
    }
}