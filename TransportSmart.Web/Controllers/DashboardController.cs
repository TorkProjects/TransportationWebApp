using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransportSmart.Web.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public ActionResult MainDashboard()
        {
            return View("MainDashboard");
        }
    }
}