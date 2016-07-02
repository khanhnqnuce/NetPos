using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class HistoryUpRankItem : BaseSimple
    {

        public string Name { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int? CustomerID { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? Coefficient { get; set; }
        public bool? IsPlay { get; set; }
        public bool? IsDeleted { get; set; }
        public int? LevelRank { get; set; }
        public decimal? PVNow { get; set; }
        public decimal? PVNow1 { get; set; }
        public decimal? Percent { get; set; }
        public decimal? PVAward { get; set; }

        public virtual CustomerItem Customer { get; set; }
    }

    public class ModelHistoryUpRankItem : BaseModelSimple
    {
        public virtual CustomerItem Customer { get; set; }
        public virtual IEnumerable<HistoryUpRankItem> ListItem { get; set; }
        public decimal? Total { get; set; }
    }
}
