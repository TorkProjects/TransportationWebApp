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
    public class ClientsController : Controller
    {
        private IClientsRespository clientRepository;

        public ClientsController()
        {
            this.clientRepository = new ClientsRepository(new TransportEntities());
        }

        // GET: Clients
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }

        public PartialViewResult ClientForm(int ClientId)
        {
            Clients client = new Clients();
            if (ClientId != 0)
            {
                client = this.clientRepository.GetClientByID(ClientId);
                if (client == null)
                {
                    client = new Clients();
                }
            }
            return PartialView("ClientForm", client);
        }



        [HttpPost]
        public ActionResult Save(FormCollection fmdata)
        {
            Clients client = new Clients();

            Int16 ClientId = Convert.ToInt16(fmdata["ClientID"]);
            try
            {

                // Returns message that successfully uploaded
                client.ClientName = fmdata["ClientName"]  ;
                client.ClientAddress = fmdata["ClientAddress"];
                client.ClientType = Convert.ToInt32(fmdata["ClientType"]);
                client.AuthorizedPerson = fmdata["AuthorizedPerson"];
                client.Email = fmdata["Email"];
                client.TelNumber = fmdata["TelNumber"];
                client.PhoneNumber = fmdata["PhoneNumber"];
                client.PhoneNumber1 = fmdata["PhoneNumber1"];
                client.TaxNumber = fmdata["TaxNumber"];
                client.Active = Convert.ToBoolean(fmdata["Active"]);
                client.CreatedBy = Convert.ToInt32(fmdata["CreatedBy"]);


                if (client.ClientID == 0)
                {
                    clientRepository.Insert(client);
                }
                else
                {
                    clientRepository.Update(client);
                }
                return null; // Json(new { filePath = FileName }, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }
        }


        [WebMethod]
        public JsonResult GetListOfClients()
        {
            try
            {
                var clientList = this.clientRepository.GetClients().ToList();
                return Json(new { Success = true, listOfClient = clientList, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, listOfClient = "", ExceptionMessage = ex.Message });
            }

        }

        
    }
}