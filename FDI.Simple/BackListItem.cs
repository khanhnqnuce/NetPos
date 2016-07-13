using System;

namespace FDI.Simple
{
    public class BackListItem : BaseSimple
    {
        public DateTime Date { get; set; }
        public int MemoryID { get; set; }
        public string CardNumber { get; set; }
        public string ToObjects { get; set; }
        public bool IsInActive { get; set; }
        public string Desc { get; set; }
    }
}