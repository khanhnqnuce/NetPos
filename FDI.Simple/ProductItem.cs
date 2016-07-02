using System;
using System.Collections.Generic;

namespace FDI.Simple
{
    [Serializable]
    public class ProductItem : BaseSimple
    {
        public string Name { get; set; }
        public string NameAscii { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? IsShow { get; set; }
        public bool? IsSlide { get; set; }
        public bool? IsHot { get; set; }
        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public decimal? PriceOld { get; set; }
        public decimal? PriceNew { get; set; }
    }
    public class ModelProductItem : BaseModelSimple
    {
        
        public IEnumerable<ProductItem> ListItem { get; set; }
    }
}
