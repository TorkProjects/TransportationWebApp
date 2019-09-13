using DataContracts;
using DataContracts.DL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace TransportSmart.Web.Controllers
{
    public class TrucksController : Controller
    {
        private ITruckRespository truckRepository;

        public TrucksController()
        {
            this.truckRepository = new TruckRepository(new TransportEntities());
        }

        // GET: Trucks
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult TruckForm(int TruckId)
        {
            Truck truck = new Truck();
            if (TruckId != 0)
            {
                truck = this.truckRepository.GetTruckByID(TruckId);
                if (truck == null)
                {
                    truck = new Truck();
                }
            }
            return PartialView("TruckForm", truck);
        }

        [WebMethod]
        public JsonResult GetListOfTrucks()
        {
            try
            {
                var Trucklist = this.truckRepository.GetTruck().ToList();
                return Json(new { Success = true, listOfTruck = Trucklist, Message = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, listOfTruck = "", ExceptionMessage = ex.Message });
            }

        }

        [HttpPost]
        public ActionResult Save(FormCollection fmdata)
        {
            Truck truck = new Truck();
            int truckID = Convert.ToInt16(fmdata["ID"]);
            try
            {
                truck.VehicleOwner = fmdata["VehicleOwner"];
                truck.VehiclePlateNumber = fmdata["VehiclePlateNumber"];
                truck.VehicleDriverName = fmdata["VehicleDriverName"];
                truck.VehicleSerialNumber = fmdata["VehicleSerialNumber"];
                truck.VehicleEngineNumber = fmdata["VehicleEngineNumber"];
                truck.VehicleChassisNo = fmdata["VehicleChassisNo"];
                truck.VehiclePlateClass = Convert.ToInt32(fmdata["ddlPlateType"]);
                truck.VehicleCountryMade = fmdata["VehicleCountryMade"];
                truck.VehicleType = fmdata["VehicleType"];
                truck.VehicleColor = fmdata["VehicleColor"];
                truck.VehicleOwnershipCopy = fmdata["VehicleOwnershipCopy"];
                truck.VehicleOwnershipExpiryDate = Convert.ToDateTime(fmdata["VehicleOwnershipExpiryDate"]);
                truck.VehicleModel = fmdata["VehicleModel"];
                truck.Note = fmdata["Note"];
                truck.Active = Convert.ToBoolean(fmdata["Active"]);
                truck.CreatedBy = Convert.ToInt32(fmdata["CreatedBy"]);



                //truck.VehicleOwner = Request.Form["EmiratesIDnumber"];
                //if (String.IsNullOrEmpty(Convert.ToString(Request.Form["EmiratesIDexpirydate"])))
                //    tempDate = null;
                //else
                //    tempDate = Convert.ToDateTime(Request.Form["EmiratesIDexpirydate"]);
                //employee.EmiratedExpiryDate = tempDate;
                if (truck.ID == 0)
                {
                    truckRepository.Insert(truck);
                }
                else
                {
                    truckRepository.Update(truck);
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