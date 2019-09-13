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
    public class InvoicesController : Controller
    {
        private IInvoiceRespository invoiceRepository;

        public InvoicesController()
        {
            this.invoiceRepository = new InvoiceRepository(new TransportEntities());
        }

        // GET: Invoices
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult InvoiceForm(int Id)
        {
            Invoice invoice = new Invoice();
            if (Id != 0)
            {
                invoice = this.invoiceRepository.GetInvoiceByID(Id);
                if (invoice == null)
                {
                    invoice = new Invoice();
                }
            }
            return PartialView("_InvoiceForm", invoice);
        }

        [HttpPost]
        public ActionResult Save(FormCollection fmdata)
        {
            Invoice invoice = new Invoice();

            try
            {
                invoice.InvoiceNo = Request.Form["InvoiceNo"];
                invoice.InvoiceDate = Convert.ToDateTime(Request.Form["InvoiceDate"]);

                //  invoice.ClientID = Request.Form["ClientID"];
                invoice.AmountNo = Convert.ToDecimal(Request.Form["AmountNo"]);
                invoice.AmountText = Request.Form["AmountText"];
                //  invoice.InvoiceType = Request.Form["InvoiceType"];
                invoice.CheckNo = Request.Form["CheckNo"];
                invoice.BankName = Request.Form["BankName"];
                invoice.ExchangeOfficeName = Request.Form["ExchangeOfficeName"];
                invoice.Note = Request.Form["Note"];

                if (invoice.ID == 0)
                {
                    invoiceRepository.Insert(invoice);
                }
                else
                {
                    invoiceRepository.Update(invoice);
                }
                return null;//Json(new { filePath = FileName }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }




        [WebMethod]
        public JsonResult GetListOfInvoices()
        {
            try
            {
                var emplist = this.invoiceRepository.GetInvoice().ToList();
                return Json(new { Success = true, listOfInvoices = emplist, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, listOfInvoices = "", ExceptionMessage = ex.Message });
            }

        }
    }
}