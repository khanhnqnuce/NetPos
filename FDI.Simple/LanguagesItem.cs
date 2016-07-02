using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    [Serializable]
    public class LanguagesItem : BaseSimple
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string FallbackCulture { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Icon { get; set; }
        public bool? IsShow { get; set; }

        public PictureItem PictureItem { get; set; }

    }

    public class ModelLanguagesItem : BaseModelSimple
    {
        public IEnumerable<LanguagesItem> ListItem { get; set; }
    }
}
