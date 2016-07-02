using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    [Serializable]
    public class MenusItem : BaseSimple
    {
        public string Name { get; set; }
        public int? GroupId { get; set; }
        public int? ParentId { get; set; }
        public int? PageId { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int? IsLevel { get; set; }
        public bool? IsNewTab { get; set; }
        public bool? IsShow { get; set; }
        public int? Sort { get; set; }
        public int? Type { get; set; }
        public string LanguageId { get; set; }
        public int? PortalId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UserCreate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UserUpdate { get; set; }
        public bool? Active { get; set; }

    }
    public class ModelMenusItem : BaseModelSimple
    {
        public IEnumerable<MenusItem> ListItem { get; set; }
        public IEnumerable<MenuGroupsItem> ListMenuGroupsItem { get; set; }
    }
}

