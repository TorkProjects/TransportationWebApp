using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransportSmart.Web.ViewModels
{
    public class RefDetailsVM
    {
        public int ID { get; set; }
        public Nullable<int> HeaderID { get; set; }
        public string RefValue { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> CreatedBy { get; set; }
               
    }
}