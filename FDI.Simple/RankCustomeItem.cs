using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class RankCustomeItem : BaseSimple
    {
        public string Name { get; set; }
        public int? OrderBy { get; set; }
        public int? Type { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsShow { get; set; }
        public int? Percent { get; set; }
        public string Color { get; set; }
        public int? Time { get; set; }
        public decimal? Price { get; set; }
        public decimal? PricePV { get; set; }

        public virtual ICollection<CustomeRankCustomerItem> Custome_RankCustomer { get; set; }
    }

    public class ModeRankCustomeItem
    {
        public List<RankCustomeItem> ListItem { get; set; }
        public SystemActionItem SystemActionItem { get; set; }
        public string PageHtml { get; set; }
    }
}
