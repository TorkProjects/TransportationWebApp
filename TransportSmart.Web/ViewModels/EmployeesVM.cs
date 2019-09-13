using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TransportSmart.Web.ViewModels
{
    public class EmployeesVM
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "إسم الموظف مطلوب")]
        public string Name { get; set; }

        [Required(ErrorMessage = "حدد المسمى الوظيفي")]
        public Nullable<int> PositionID { get; set; }

        [Required(ErrorMessage = "حدد جنسية الموظف")]
        public Nullable<int> NationalityID { get; set; }

        [Required(ErrorMessage = "رقم الجواز السفر مطلوب")]
        public string PassportNumber { get; set; }

        public Nullable<int> PlaceofissueID { get; set; }

        [Required(ErrorMessage = "تاريخ اصدار الجواز مطلوب")]
        public Nullable<System.DateTime> DateofIssue { get; set; }

        [Required(ErrorMessage = "تاريخ إنتهاء الجواز مطلوب")]
        public Nullable<System.DateTime> ExpiryDate { get; set; }

        [Required(ErrorMessage = "تاريخ ميلاد الموظف مطلوب")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Required(ErrorMessage = "صورة الجواز مطلوبة")]
        public string CopyofPassport { get; set; }

        [Required(ErrorMessage = "رقم الإقامة مطلوب ")]
        public string ResidenceNumber { get; set; }

        [Required(ErrorMessage = "الرقم الموحد مطلوب")]
        public string UnifiedNumber { get; set; }

        [Required(ErrorMessage = "تاريخ إصدار الإقامة مطلوب")]
        public Nullable<System.DateTime> DateofResidence { get; set; }

        [Required(ErrorMessage = "تاريخ إنتهاء الإقامة مطلوب")]
        public Nullable<System.DateTime> ExpirationofResidence { get; set; }

        [Required(ErrorMessage = "صورة عن الإقامة")]
        public string ResidenceCopy { get; set; }

        [Required(ErrorMessage = "رقم بطاقة العمل مطلوب")]
        public string LaborCardNumber { get; set; }

        [Required(ErrorMessage = "تاريخ إنتهاء بطاقة العمل")]
        public Nullable<System.DateTime> LaborCardExpiryDate { get; set; }

        [Required(ErrorMessage = "تاريخ إنتهاء بطاقة العمل")]
        public string EmiratesIDNumber { get; set; }

        public Nullable<System.DateTime> EmiratedExpiryDate { get; set; }
        public string FrontFaceforEmiratesID { get; set; }
        public string BackfaceForEmiratesID { get; set; }

        public Nullable<Boolean> Active { get; set; }
        public Nullable<int> CreatedBy { get; set; }

        public string NationalityName { get; set; }
        public string PositionName { get; set; }
        public string PlaceofissueName { get; set; }

     
        

    }
}