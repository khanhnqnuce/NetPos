using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class VoucherItem : BaseSimple
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string CustomerUserName { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? TotalCount { get; set; }
        public bool? IsShow { get; set; }
    }
    public class ModelVoucherItem : BaseModelSimple
    {
        public IEnumerable<VoucherItem> ListItem { get; set; }
    }
}
