using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class ProvincialAgencyItem : BaseSimple
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string NameAscii { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsShow { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? OrderBy { get; set; }
        public string AccountNumber { get; set; }
        public string InformationAccount { get; set; }

        public virtual IEnumerable<CustomerItem> Customers { get; set; }
    }

    public class ModeProvincialAgencyItem
    {
        public List<ProvincialAgencyItem> ListItem { get; set; }
        public SystemActionItem SystemActionItem { get; set; }
        public string PageHtml { get; set; }
    }
}
