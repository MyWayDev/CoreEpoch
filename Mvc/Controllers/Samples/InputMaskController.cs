using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;

namespace Mvc.Controllers.Samples
{
    public class InputMaskController : Controller
    {
       
            public ActionResult Input01()
            {
                UserData model = new UserData();

                model.StartDate = null;

                return View("~/Views/Samples/InputMask/Input01.cshtml", model);
            }

            [HttpPost]
            public ActionResult Input01(UserData model)
            {
                System.Diagnostics.Debugger.Break();

                ModelState.Clear();

                return View("~/Views/Samples/InputMask/Input01.cshtml", model);
            }

            public ActionResult Input02()
            {
                UserData model = new UserData();

                model.StartDate = null;

                return View("~/Views/Samples/InputMask/Input02.cshtml", model);
            }

            [HttpPost]
            public ActionResult Input02(UserData model)
            {
                System.Diagnostics.Debugger.Break();

                ModelState.Clear();

                return View("~/Views/Samples/InputMask/Input02.cshtml", model);
            }
        
    }
}