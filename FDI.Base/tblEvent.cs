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
    
    public partial class tblEvent
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string CardNumber { get; set; }
        public string MID { get; set; }
        public string FID { get; set; }
        public Nullable<int> Value { get; set; }
        public Nullable<int> Balance { get; set; }
        public string Action { get; set; }
        public string EventCode { get; set; }
        public string BuidingCode { get; set; }
        public string PCCode { get; set; }
        public string LineCode { get; set; }
        public string AreaCode { get; set; }
        public string ObjectCode { get; set; }
        public string CardTypeCode { get; set; }
        public string ShiftCode { get; set; }
        public string UserCode { get; set; }
        public Nullable<byte> InOut { get; set; }
        public Nullable<bool> IsServer1 { get; set; }
        public Nullable<bool> IsServer2 { get; set; }
        public string EventID { get; set; }
        public string ProductCode { get; set; }
    }
}