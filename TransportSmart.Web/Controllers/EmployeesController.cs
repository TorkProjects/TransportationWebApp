using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using DataContracts;
using DataContracts.DL;
using TransportSmart.Web.ViewModels;
using Helper.Enums;
using System.Dynamic;

namespace TransportSmart.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeesRespository employeeRepository;
        private IRefDetailsRespository refDetailsRespository;

        public EmployeesController()
        {
            this.employeeRepository = new EmployeesRepository(new TransportEntities());

            this.refDetailsRespository = new RefDetailsRepository(new TransportEntities());
        }

        private IEnumerable<EmployeesVM> ConvertFromEmpToEmployeesVM(IEnumerable<Employee> emps)
        {
            try
            {
                return emps.Where(emp => emp.Active == true).Select(
                                            x => new EmployeesVM()
                                            {
                                                EmployeeId = x.EmployeeId,
                                                Name = x.Name,
                                                PositionID = x.Position,
                                                NationalityID = x.Nationality,
                                                PassportNumber = x.PassportNumber,
                                                PlaceofissueID = x.Placeofissue,
                                                DateofIssue = x.DateofIssue,
                                                ExpiryDate = x.ExpiryDate,
                                                DOB = x.DOB,
                                                CopyofPassport = x.CopyofPassport,
                                                ResidenceNumber = x.ResidenceNumber,
                                                UnifiedNumber = x.UnifiedNumber,
                                                DateofResidence = x.DateofResidence,
                                                ExpirationofResidence = x.ExpirationofResidence,
                                                ResidenceCopy = x.ResidenceCopy,
                                                LaborCardNumber = x.LaborCardNumber,
                                                LaborCardExpiryDate = x.LaborCardExpiryDate,
                                                EmiratesIDNumber = x.EmiratesIDNumber,
                                                EmiratedExpiryDate = x.EmiratedExpiryDate,
                                                FrontFaceforEmiratesID = x.FrontFaceforEmiratesID,
                                                BackfaceForEmiratesID = x.BackfaceForEmiratesID,
                                                Active = x.Active,
                                                CreatedBy = x.CreatedBy,
                                                NationalityName = x.RefNationality != null ? x.RefNationality.RefValue : null,
                                                PositionName = x.RefPosition != null ? x.RefPosition.RefValue : null,
                                                PlaceofissueName = x.RefPlaceOfIssue != null ? x.RefPlaceOfIssue.RefValue : null
                                            }).ToList();
            }
            catch (Exception ex)
            {

                return null;
            }


        }
        private EmployeesVM ConvertFromEmpToEmployeesVM(Employee emps)
        {
            try
            {
                EmployeesVM employeesVM = new EmployeesVM()
                {
                    EmployeeId = emps.EmployeeId,
                    Name = emps.Name,
                    PositionID = emps.Position,
                    NationalityID = emps.Nationality,
                    PassportNumber = emps.PassportNumber,
                    PlaceofissueID = emps.Placeofissue,
                    DateofIssue = emps.DateofIssue,
                    ExpiryDate = emps.ExpiryDate,
                    DOB = emps.DOB,
                    CopyofPassport = emps.CopyofPassport,
                    ResidenceNumber = emps.ResidenceNumber,
                    UnifiedNumber = emps.UnifiedNumber,
                    DateofResidence = emps.DateofResidence,
                    ExpirationofResidence = emps.ExpirationofResidence,
                    ResidenceCopy = emps.ResidenceCopy,
                    LaborCardNumber = emps.LaborCardNumber,
                    LaborCardExpiryDate = emps.LaborCardExpiryDate,
                    EmiratesIDNumber = emps.EmiratesIDNumber,
                    EmiratedExpiryDate = emps.EmiratedExpiryDate,
                    FrontFaceforEmiratesID = emps.FrontFaceforEmiratesID,
                    BackfaceForEmiratesID = emps.BackfaceForEmiratesID,
                    Active = emps.Active,
                    CreatedBy = emps.CreatedBy,
                    NationalityName = emps.RefNationality != null ? emps.RefNationality.RefValue : null,
                    PositionName = emps.RefPosition != null ? emps.RefPosition.RefValue : null,
                    PlaceofissueName = emps.RefPlaceOfIssue != null ? emps.RefPlaceOfIssue.RefValue : null
                };
                return employeesVM;
            }
            catch (Exception ex)
            {

                return null;
            }


        }

        [WebMethod]
        public JsonResult GetListOfEmployee()
        {
            try
            {
                return Json(new { Success = true, listOfEmployee = ConvertFromEmpToEmployeesVM(this.employeeRepository.GetEmployee().ToList()), Message = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, listOfEmployee = "", ExceptionMessage = ex.Message });
            }
        }
        // GET: Employees
        public ActionResult AddEmployee()
        {
            List<Employee> emplist = new List<Employee>();
            emplist = this.employeeRepository.GetEmployee().ToList();
            return View(emplist);
        }

        [HttpPost]
        public ActionResult Save(Tuple<List<RefDetailsVM>, List<RefDetailsVM>, EmployeesVM> fmdata)
        {
            var z = fmdata;
            return null;
            //Employee employee = new Employee();
            //// Checking no of files injected in Request object  
            //Int16 EmployeeId = Convert.ToInt16(fmdata["EmployeeId"]);
            //var name = Request.Form["name"];
            //string fname = "";
            //string FileName = "";
            //try
            //{
            //    if (Request.Files.Count > 0)
            //    {

            //        //  Get all files from Request object  
            //        HttpFileCollectionBase files = Request.Files;
            //        for (int i = 0; i < files.Count; i++)
            //        {
            //            HttpPostedFileBase file = files[i];
            //            // Get the complete folder path and store the file inside it.
            //            string GUIDPath = Guid.NewGuid().ToString();
            //            var TEMPName = "/Upload/" + GUIDPath + System.IO.Path.GetExtension(file.FileName);
            //            fname = Path.Combine(Server.MapPath("~/Upload/"), GUIDPath + System.IO.Path.GetExtension(file.FileName));
            //            file.SaveAs(fname);

            //            switch (files.AllKeys[i])
            //            {
            //                case "copyofpassport":
            //                    employee.CopyofPassport = TEMPName;
            //                    break;
            //                case "Residencecopy":
            //                    employee.ResidenceCopy = TEMPName;
            //                    break;
            //                case "FrontfaceforEmiratesID":
            //                    employee.FrontFaceforEmiratesID = TEMPName;
            //                    break;
            //                case "BackfaceforEmiratesID":
            //                    employee.BackfaceForEmiratesID = TEMPName;
            //                    break;
            //                default:
            //                    break;
            //            }
            //        }
            //    }
            //    // Returns message that successfully uploaded
            //    employee.EmployeeId = EmployeeId;
            //    employee.Name = Request.Form["Name"];
            //    employee.Nationality = Convert.ToInt32(Request.Form["Nationality"]);
            //    employee.PassportNumber = Request.Form["Passportnumber"];
            //    employee.Placeofissue = Convert.ToInt32(Request.Form["Placeofissue"]);
            //    DateTime? tempDate = new DateTime();
            //    if (String.IsNullOrEmpty(Convert.ToString(Request.Form["Dateofissue"])))
            //        tempDate = null;
            //    else
            //        tempDate = Convert.ToDateTime(Request.Form["Dateofissue"]);
            //    employee.DateofIssue = tempDate;
            //    if (String.IsNullOrEmpty(Convert.ToString(Request.Form["Expirydate"])))
            //        tempDate = null;
            //    else
            //        tempDate = Convert.ToDateTime(Request.Form["Expirydate"]);
            //    employee.ExpiryDate = tempDate;
            //    if (String.IsNullOrEmpty(Convert.ToString(Request.Form["Bob"])))
            //        tempDate = null;
            //    else
            //        tempDate = Convert.ToDateTime(Request.Form["Bob"]);
            //    employee.DOB = tempDate;
            //    employee.UnifiedNumber = Request.Form["Unifiednumber"];
            //    if (String.IsNullOrEmpty(Convert.ToString(Request.Form["Dateofissuance"])))
            //        tempDate = null;
            //    else
            //        tempDate = Convert.ToDateTime(Request.Form["Dateofissuance"]);
            //    employee.DateofResidence = tempDate;
            //    if (String.IsNullOrEmpty(Convert.ToString(Request.Form["Expirationofresidence"])))
            //        tempDate = null;
            //    else
            //        tempDate = Convert.ToDateTime(Request.Form["Expirationofresidence"]);
            //    employee.ExpirationofResidence = tempDate;
            //    employee.ResidenceNumber = Request.Form["Residencenumber"];
            //    employee.LaborCardNumber = Request.Form["Laborcardnumber"];
            //    if (String.IsNullOrEmpty(Convert.ToString(Request.Form["Laborcardexpirydate"])))
            //        tempDate = null;
            //    else
            //        tempDate = Convert.ToDateTime(Request.Form["Laborcardexpirydate"]);
            //    employee.LaborCardExpiryDate = tempDate;
            //    employee.EmiratesIDNumber = Request.Form["EmiratesIDnumber"];
            //    if (String.IsNullOrEmpty(Convert.ToString(Request.Form["EmiratesIDexpirydate"])))
            //        tempDate = null;
            //    else
            //        tempDate = Convert.ToDateTime(Request.Form["EmiratesIDexpirydate"]);
            //    employee.EmiratedExpiryDate = tempDate;
            //    if (employee.EmployeeId == 0)
            //    {
            //        employeeRepository.Insert(employee);
            //    }
            //    else
            //    {
            //        employeeRepository.Update(employee);
            //    }
            //    return Json(new { filePath = FileName }, JsonRequestBehavior.DenyGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json("Error occurred. Error details: " + ex.Message);
            //}
        }

        public PartialViewResult EmpForm(int EmpId)
        {
            // Get  current Emplyee details if Emplyee Selected
            EmployeesVM empVM = new EmployeesVM();
            if (EmpId != 0)
            {
                var emp = this.employeeRepository.GetEmployeeByID(EmpId);

                if (emp == null)
                {
                    empVM = new EmployeesVM();
                }
                else
                {
                    empVM = ConvertFromEmpToEmployeesVM(emp);
                }
            }




            // Get List of Designation 
            List<RefDetails> designation = this.refDetailsRespository.GetRefDetailsByHeaderID((int)Helper.Enums.RefHeader.Designation);


            // Get List Of Nationalty 
            List<RefDetails> nationalty = this.refDetailsRespository.GetRefDetailsByHeaderID((int)Helper.Enums.RefHeader.Nationality);


            var tupelData = new Tuple<List<RefDetailsVM>, List<RefDetailsVM>, EmployeesVM>(designation, nationalty, empVM);


            return PartialView("EmpForm", tupelData);
        }

        public JsonResult DeleteEmp(int EmpId)
        {
            try
            {
                Employee emp = new Employee();
                if (EmpId != 0)
                {
                    emp = this.employeeRepository.GetEmployeeByID(EmpId);
                    if (emp != null)
                    {
                        if (this.employeeRepository.Delete(emp) == 1)
                        {
                            return Json(true, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        private List<RefDetailsVM> ConvertFromRefDetailsToRefDetailsVM(List<RefDetails> redDetails)
        {
            try
            {
                return redDetails.Where(refd => refd.Active == true).Select(
                                           x => new RefDetailsVM()
                                           {
                                               ID = x.ID,
                                               HeaderID = x.HeaderID,
                                               RefValue = x.RefValue,
                                               Active = x.Active,
                                               CreatedBy = x.CreatedBy
                                           }).ToList();


            }
            catch (Exception ex)
            {

                return null;
            }


        }
    }
}