//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FDI.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class CheckLogin
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public Nullable<bool> IsLogin { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string IpAddress { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}