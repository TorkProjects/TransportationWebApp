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
    
    public partial class Custmers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Nullable<int> Type { get; set; }
        public string AuthorizaedPerson { get; set; }
        public string EmailAddress { get; set; }
        public string TaxNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> Backup { get; set; }
        public Nullable<System.DateTime> BackupDate { get; set; }
        public Nullable<int> ClientId { get; set; }
    }
}