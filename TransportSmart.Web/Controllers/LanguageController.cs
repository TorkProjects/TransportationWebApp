using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TransportSmart.Web.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Change(string LanguageAbbrevation)
        {
            if(LanguageAbbrevation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
            }

            //delete the cookies if exist 
            HttpCookie nameCookie = new HttpCookie("Languageone");
            if(null != nameCookie)
            {
                //Set the Expiry date to past date.
                nameCookie.Expires = DateTime.Now.AddDays(-1);
                //Update the Cookie in Browser.
                Response.Cookies.Add(nameCookie);
            }
  
            //add new cookies 
            HttpCookie cookie = new HttpCookie("Languageone");
            cookie.Value = LanguageAbbrevation;
            cookie.Expires = DateTime.Now.AddDays(365);
            Response.Cookies.Add(cookie);
            return View();
        }
    }
}