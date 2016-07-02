using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class RankNowItem:BaseSimple
    {
        public int? CustomerID { get; set; }
        public int? CycleNumber { get; set; }
        public decimal? CycleNumberHome { get; set; }

        public string UserName { get; set; }
        public string LevelId { get; set; }
        public int? UserId { get; set; }
        public decimal? PricePVUser { get; set; }
        public int? UserId1 { get; set; }
        public decimal? PricePVUser1 { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? Level { get; set; }
        public decimal? PVUser { get; set; }
        public decimal? PVUser1 { get; set; }
        public int? ActiveRank { get; set; }
        public bool? IsAward { get; set; }
        public decimal? rnPVUser { get; set; }
        public decimal? rnPVUser1 { get; set; }
        public decimal? PVMonth { get; set; }
        public decimal? PVMonth1 { get; set; }
        public decimal? PVOld { get; set; }
        public decimal? PVOld1 { get; set; }
        public int? CheckLimit { get; set; }
        public bool? IsNew { get; set; }
        public int? CustomerRankId { get; set; }
        public decimal? PricePVX { get; set; }
        public decimal? PricePVNow { get; set; }
        public bool? IsPay { get; set; }
        public bool? IsPay40 { get; set; }
        public int? dh20 { get; set; }
        public int? dh40 { get; set; }

        public  DateTime CreatedOnUtc { get; set; }
        public virtual CustomerItem Customer { get; set; }
    }
    public class ModelRankNowItem : BaseModelSimple
    {
        public string PageHtml { get; set; }
        public IEnumerable<RankNowItem> ListRankNowItem { get; set; }
        public IEnumerable<RankNowItem> Listcus20 { get; set; }
        public IEnumerable<RankNowItem> Listcus40 { get; set; }
        public IEnumerable<RankNowItem> Listcus60 { get; set; }
       
    }
}
