using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransportSmart.Web.ViewModels
{
    public class UsersVM
    {
        public int ID { get; set; }

       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال الرمز السري")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<short> ClientId { get; set; }
    }
}