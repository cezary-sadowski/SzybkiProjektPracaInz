using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pracainz.Models;

namespace pracainz.Controllers
{
    public class TechnologController : Controller
    {
        private ERP_DB ctx;

        public TechnologController()
        {
            ctx = new ERP_DB();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        // GET: Technolog
        public ViewResult Index()
        {
            var kj = GetTechnolog();

            return View(kj);
        }

        private IEnumerable<Technolog> GetTechnolog() => ctx.Technolog.ToList();
    }
}