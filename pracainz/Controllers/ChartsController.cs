using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pracainz.Models;

namespace pracainz.Controllers
{
    public class ChartsController : Controller
    {
        private ERP_DB ctx;

        public ChartsController()
        {
            ctx = new ERP_DB();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        // GET: Charts
        public ViewResult Index()
        {
            var chart = GetCharts();

            return View(chart);
        }

        private Wykresy GetCharts() => ctx.Wykresy.FirstOrDefault(chart => chart.ID == 1);
    }
}