using System;

namespace FDI.Simple
{
    public class GiaoDichItem : BaseSimple
    {
        public string Action { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public int Balance { get; set; }
        public string Object { get; set; }
        public string ProductCode { get; set; }
    }
}
