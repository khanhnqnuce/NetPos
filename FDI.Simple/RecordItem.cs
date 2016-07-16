using System;

namespace FDI.Simple
{
    public class RecordItem : BaseSimple
    {
        public DateTime Date { get; set; }
        public string CardNumber { get; set; }
        //public string MID { get; set; }
        //public string FID { get; set; }
        public int Value { get; set; }
        public int Balance { get; set; }
        public int Bonus { get; set; }
        public string Action { get; set; }
        public string EventCode { get; set; }
        public string BuidingCode { get; set; }
        //public string PCCode { get; set; }
        //public string LineCode { get; set; }
        public string AreaCode { get; set; }
        public string ObjectCode { get; set; }
        public string CardTypeCode { get; set; }
        public string ShiftCode { get; set; }
        public string UserCode { get; set; }
        //public bool IsServer1 { get; set; }
        //public bool IsServer2 { get; set; }
        public string EventID { get; set; }
        public string ProductCode { get; set; }
        //public int CardDeposit { get; set; }
        //public int ReturnVal { get; set; }
    }
}
