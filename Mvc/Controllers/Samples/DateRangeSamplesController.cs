using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers.Samples
{
    
        public class DateRangeSamplesController : Controller
        {
            public ActionResult DateRange1()
            {
                return View("~/Views/Samples/DateRangeSamples/DateRange1.cshtml");
            }

            public ActionResult DateRange2()
            {
                return View("~/Views/Samples/DateRangeSamples/DateRange2.cshtml");
            }

            public ActionResult DateRange3()
            {
                return View();
            }

            public ActionResult DateRange4()
            {
                return View();
            }

            public ActionResult DateRange5()
            {
                return View();
            }
        }
    }
