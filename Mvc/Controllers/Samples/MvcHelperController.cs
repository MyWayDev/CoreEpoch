using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;


namespace Mvc.Controllers.Samples
{
    public class MvcHelperController : Controller
    {
        public ActionResult Helper01()
        {
            return View();
        }

        public ActionResult Helper02()
        {
            UserData model = new UserData();

            return View("~/Views/Samples/MvcHelper/Helper02.cshtml", model);
        }

        public ActionResult Helper03()
        {
            UserData model = new UserData();

            return View("~/Views/Samples/MvcHelper/Helper03.cshtml", model);
        }

        public ActionResult Helper04()
        {
            UserData model = new UserData();

            return View("~/Views/Samples/MvcHelper/Helper04.cshtml", model);
        }

        public ActionResult Helper05()
        {
            UserData model = new UserData();

            return View("~/Views/Samples/MvcHelper/Helper05.cshtml", model);
        }

        public ActionResult Helper06()
        {
            UserData model = new UserData();

            return View("~/Views/Samples/MvcHelper/Helper06.cshtml", model);
        }
    }
}