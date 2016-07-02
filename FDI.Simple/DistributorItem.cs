using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDI.Base;

namespace FDI.Simple
{
    public class DistributorItem : BaseSimple
    {
        public string FullName { get; set; }
        public int? Avartar { get; set; }
        public string Address { get; set; }
        public string PeoplesIdentity { get; set; }
        public DateTime? Birthday { get; set; }
        public string Mobile { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string TaxCode { get; set; }
        public string Email { get; set; }
        public int? PicturePeoplesIdentity { get; set; }
        public bool? IsActive { get; set; }
        public  string CodeContract { get; set; }

        public  ICollection<Customer> Customers { get; set; }
        public  PictureItem PictureItem { get; set; }
        public  PictureItem PictureItem1 { get; set; }
        public PictureItem PictureItem2 { get; set; }
    }

    public class ModelDistributorItem : BaseModelSimple
    {
        public ICollection<Customer> ListCustomers { get; set; }
        public ICollection<DistributorItem> ListDistributorItem { get; set; }
        public string PageHtml { get; set; }
    }
}
