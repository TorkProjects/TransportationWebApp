using DataContracts;
using DataContracts.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace TransportSmart.Web.Controllers
{
    public class ExchangeController : Controller
    {

        private IExchangeRespository exchangeRespository;

        public ExchangeController()
        {
            this.exchangeRespository = new ExchangeRepository(new TransportEntities());
        }

        // GET: Exchange
        public ActionResult Index()
        {
            return View();
        }



        public PartialViewResult ExchangeForm(int Id)
        {
            Bond bond = new Bond();
            if (Id != 0)
            {
                bond = this.exchangeRespository.GetExchangeByID(Id);
                if (bond == null)
                {
                    bond = new Bond();
                }
            }
            return PartialView("_ExchangeForm", bond);
        }

        



        [WebMethod]
        public JsonResult GetListOfBond()
        {
            try
            {
                var Bondlist = this.exchangeRespository.GetExchange().ToList();
                return Json(new { Success = true, listOfBond = Bondlist, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, listOfBond = "", ExceptionMessage = ex.Message });
            }

        }

        [HttpPost]
        public ActionResult Save(FormCollection fmdata)
        {
            Bond bond = new Bond();
          
            try
            {
                bond.BondNo = fmdata["BondNo"];

          //      bond.BondDate = Convert.ToDateTime(fmdata["VehiclePlateNumber"]);

                if(!string.IsNullOrEmpty(fmdata["ClientID"]))
                bond.ClientID = Convert.ToInt32(fmdata["ClientID"]);

                bond.AmountNo = Convert.ToInt32(fmdata["AmountNo"]);
                bond.AmountText = fmdata["AmountText"];
                bond.BondType = Convert.ToInt32(fmdata["BondType"]);

                if (!string.IsNullOrEmpty(fmdata["CheckNo"]))
                bond.CheckNo = fmdata["CheckNo"];

                bond.BankName = fmdata["BankName"];
                bond.ExchangeOfficeName = fmdata["ExchangeOfficeName"];
                bond.Note = fmdata["Note"];
               

                if (bond.ID == 0)
                {
                    exchangeRespository.Insert(bond);
                }
                else
                {
                    exchangeRespository.Update(bond);
                }

                return null;// Json(new { filePath = FileName }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }

    }
}