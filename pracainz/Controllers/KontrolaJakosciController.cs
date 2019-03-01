using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pracainz.Models;

namespace pracainz.Controllers
{
    public class KontrolaJakosciController : Controller
    {
        private ERP_DB ctx;

        public KontrolaJakosciController()
        {
            ctx = new ERP_DB();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        // GET: KontrolaJakosci
        public ViewResult Index()
        {
            var kj = GetKJ();

            return View(kj);
        }

        private IEnumerable<KontrolaJakosci> GetKJ() => ctx.KontrolaJakosci.ToList();
    }
}