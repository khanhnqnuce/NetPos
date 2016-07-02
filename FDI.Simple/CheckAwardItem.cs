using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class CheckAwardItem : BaseSimple
    {
        public string Name { get; set; }
        public int? Time { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal? Price { get; set; }
        public bool? IsShow { get; set; }
        public bool? IsDay { get; set; }
        public int? Percent { get; set; }
        public decimal? PricePV { get; set; }
        public int? Type { get; set; }

        public virtual IEnumerable<HistoryAwardItem> HistoryAwards { get; set; }
    }

    public class ModeCheckAwardItem
    {
        public List<CheckAwardItem> ListItem { get; set; }
        public SystemActionItem SystemActionItem { get; set; }
        public  string PageHtml { get; set; }
    }
}
