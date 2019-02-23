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
        // GET: SpisPracownikow
        public ActionResult Random()
        {
            using (var ctx = new ERP_DB())
            {
                var spisPracownikow = ctx.SpisPracownikow.Where(sp => sp.CzyObecny == true);

                return View(spisPracownikow);
            }     
        }
    }
}