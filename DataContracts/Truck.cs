//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataContracts
{
    using System;
    using System.Collections.Generic;
    
    public partial class Truck
    {
        public int ID { get; set; }
        public string VehicleOwner { get; set; }
        public string VehiclePlateNumber { get; set; }
        public string VehicleDriverName { get; set; }
        public string VehicleSerialNumber { get; set; }
        public string VehicleEngineNumber { get; set; }
        public string VehicleChassisNo { get; set; }
        public Nullable<int> VehiclePlateClass { get; set; }
        public string VehicleCountryMade { get; set; }
        public string VehicleType { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleOwnershipCopy { get; set; }
        public Nullable<System.DateTime> VehicleOwnershipExpiryDate { get; set; }
        public string VehicleModel { get; set; }
        public string Note { get; set; }
        public Nullable<bool> Active { get; set; }
        public int CreatedBy { get; set; }
    }
}
