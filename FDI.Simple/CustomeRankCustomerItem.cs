using System;
using System.Collections.Generic;

namespace FDI.Simple
{
    public class CustomeRankCustomerItem : BaseSimple
    {
        public int? CustomerId { get; set; }
        public string Name { get; set; }
        public int? RankCustomerId { get; set; }
        public int? TotalAgency { get; set; }
        public DateTime? DateCreated { get; set; }
        public decimal? Price { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsShow { get; set; }
        public bool? IsCustomerType { get; set; }
        public decimal? PricePV { get; set; }
        public string NameCustomer { get; set; }
		public string UserCreated { get; set; }
        public string UserCustomer { get; set; }
        public string ProvincialAgenciesName { get; set; }
        public string ProvincialAgenciesCode { get; set; }
        public decimal? SumPricePv { get; set; }
        public int? TotelCustomerID { get; set; }
        public int Month { get; set; }
		public string Note { get; set; }
		public int Goi { get; set; }
		public string NameGoi { get; set; }
		public int? Active { get; set; }
		public string NameActive { get; set; }

		public string UserActive { get; set; }
		public DateTime? DateActive { get; set; }

        public string MobileCustomer { get; set; }
        public virtual CustomerItem Customer { get; set; }
        public virtual RankCustomeItem RankCustome { get; set; }
        //public virtual ProvincialAgencyItem ProvincialAgencies { get; set; }
    }

    public class ModeCustomeRankCustomerItem : BaseModelSimple
    {
        public IEnumerable<CustomeRankCustomerItem> ListItem { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public decimal? Total { get; set; }
        public SystemActionItem SystemActionItem { get; set; }

    }
}
