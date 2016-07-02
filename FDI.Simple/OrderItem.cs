using System;
using System.Collections.Generic;

namespace FDI.Simple
{
    [Serializable]
    public class OrderItem : BaseSimple
    {
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsShow { get; set; }
        public bool? IsActive { get; set; }
        public decimal? Price { get; set; }
    }
    public class ModelOrderItem : BaseModelSimple
    {

        public IEnumerable<OrderItem> ListItem { get; set; }
    }

    public class OrderDetailItem : BaseSimple
    {
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
    public class ModelOrderDetailItem : BaseModelSimple
    {

        public IEnumerable<OrderDetailItem> ListItem { get; set; }
    }
}
