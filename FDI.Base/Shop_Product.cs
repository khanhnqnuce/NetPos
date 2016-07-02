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
    
    public partial class Shop_Product
    {
        public Shop_Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Shop_Order_Product = new HashSet<Shop_Order_Product>();
        }
    
        public int ID { get; set; }
        public Nullable<int> PictureID { get; set; }
        public string Name { get; set; }
        public string NameAscii { get; set; }
        public Nullable<bool> IsShow { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<decimal> PriceOld { get; set; }
        public Nullable<decimal> PriceNew { get; set; }
        public string LanguageId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Shop_Order_Product> Shop_Order_Product { get; set; }
    }
}
