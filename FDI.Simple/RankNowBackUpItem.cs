using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class RankNowBackUpItem : BaseSimple
    {
        public int ID { get; set; }
        public int? CustomerId { get; set; }
        public int? CycleNumber { get; set; }
        public string LevelId { get; set; }
        public string UserName { get; set; }
        public string Fullname { get; set; }

        public int? UserId { get; set; }
        public decimal? PricePvUser { get; set; }
        public int? UserId1 { get; set; }
        public decimal? PricePvUser1 { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? Level { get; set; }
        public decimal? PvUser { get; set; }
        public decimal? PvMonthPvUser1 { get; set; }
        public int? ActiveRank { get; set; }
        public decimal? PvMonth { get; set; }
        public decimal? PvMonth1 { get; set; }
        public bool? IsAward { get; set; }
        public int? CheckLimit { get; set; }
        public bool? IsNew { get; set; }
        public int? CustomerRankId { get; set; }
        public decimal? PricePvx { get; set; }
        public decimal? PricePvNow { get; set; }
        public int AwardLeader { get; set; }
        public bool? IsPay { get; set; }
        public bool? IsPay40 { get; set; }

        public CustomerItem CustomerItem { get; set; }
    }

    public class ModelRankNowBackUpItem : BaseModelSimple
    {
        public IEnumerable<RankNowBackUpItem> ListItem { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int? Total { get; set; }
    }
}
