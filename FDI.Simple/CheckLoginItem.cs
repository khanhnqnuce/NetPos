using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class CheckLoginItem : BaseSimple
    {
        public string Code { get; set; }
        public bool? IsLogin { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? CustomerID { get; set; }
        public string IpAddress { get; set; }

        public virtual CustomerItem Customer { get; set; }
    }
}
