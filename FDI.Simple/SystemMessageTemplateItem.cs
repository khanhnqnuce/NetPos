using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class SystemMessageTemplateItem : BaseSimple
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public string BodyContent { get; set; }
        public string BccEmail { get; set; }
        public bool? IsActive { get; set; }
        public int? EmailAccountId { get; set; }
        public bool? IsDeleted { get; set; }

    }
    public class ModelSystemMessageTemplateItem : BaseModelSimple
    {
        public IEnumerable<SystemMessageTemplateItem> ListItem { get; set; }
    }
}
