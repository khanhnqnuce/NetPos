using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    [Serializable]
    public class PictureItem : BaseSimple
    {
        public int? AlbumID { get; set; }
        public int? CategoryID { get; set; }
        public int? ModuleType { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsShow { get; set; }
        public bool? IsDeleted { get; set; }
        public int? SourceID { get; set; }
        public string Folder { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        //public CategoryItem Category { get; set; }
    }
    public class ModelPictureItem : BaseModelSimple
    {
        public string Container { get; set; }
        public int Type { get; set; }
        public int CategoryID { get; set; }
        public string Action { get; set; }
        public IEnumerable<PictureItem> ListItem { get; set; }

    }
}
