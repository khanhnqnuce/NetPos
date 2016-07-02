using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class HistoryAwardItem : BaseSimple
    {
        public string Name { get; set; }
        public int? Level { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsPublish { get; set; }
		public bool? IsRank { get; set; }
        public bool? IsShow { get; set; }
        public DateTime? DateCreated { get; set; }
        public decimal? Price { get; set; }
        public int? CustomerId { get; set; }
        public int? CheckAwardkId { get; set; }
        public decimal? PricePV { get; set; }
        public string NameCustomer { get; set; }
        public string UserCustomer { get; set; }
        public string MobileCustomer { get; set; }
        public int? CycleNumber { get; set; }
        public int? CurrentCycle { get; set; }
        public int CustomerRankId { get; set; }
        public string CodeDL { get; set; }
        public string CodeDLNHH { get; set; }
        public string NameAgency { get; set; }
        public string NameAward { get; set; }
        public string Title { get; set; }
        public virtual CustomerItem Customer { get; set; }
        public virtual CheckAwardItem CheckAwards { get; set; }

        //phuocnh: thuogn xuat execl
        public bool? IsAward { get; set; }
        public  int? ActiveRank { get; set; }
        public  bool? IsPay { get; set; }
        public bool? IsPay40 { get; set; }
    }
    public class ModelHistoryAwardItem : BaseModelSimple
    {
        public IEnumerable<HistoryAwardItem> ListItem { get; set; }
		public IEnumerable<CheckAwardItem> lstCheckAward { get; set; }
        public  SystemActionItem SystemActionItem { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public decimal? Total { get; set; }
    }
}
