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
    
    public partial class Page
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public Nullable<int> Parent { get; set; }
        public Nullable<int> CountChild { get; set; }
        public string Icon { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<bool> IsMenu { get; set; }
        public string Skin { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> UserCreate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UserUpdate { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public Nullable<int> PortalID { get; set; }
    }
}
