using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    [Serializable]
    public class MenuGroupsItem : BaseSimple
    {
        public string Name { get; set; }
        public string Des { get; set; }
        public int? Sort { get; set; }
        public string LanguageId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UserCreate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UserUpdate { get; set; }
        public int? PortalId { get; set; }
        public bool? IsShow { get; set; }
     
    }
    public class ModelMenuGroupsItem : BaseModelSimple
    {
        public IEnumerable<MenuGroupsItem> ListItem { get; set; }
    }
}

