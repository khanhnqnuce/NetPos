using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDI.Base;

namespace FDI.Simple
{
    [Serializable]
    public class ProvincialAgenciesItem : BaseSimple
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsShow { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? OrderBy { get; set; }
        public string AccountNumber { get; set; }
        public string InformationAccount { get; set; }
        public string Code { get; set; }
        public int? CustomerId { get; set; }

        public decimal? TotalPV { get; set; }

        public virtual ICollection<Custome_RankCustomer> Custome_RankCustomer { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
