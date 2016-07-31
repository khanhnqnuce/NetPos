using System;

namespace FDI.Simple
{
    public class GiaoDichItem : BaseSimple
    {
        public string Event { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Object { get; set; }
    }
}
