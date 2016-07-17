using System;

namespace FDI.Simple
{
    public class EventAlarmItem : BaseSimple
    {
        public long RowNumber { get; set; }
        public DateTime Date { get; set; }
        public string BuidingCode { get; set; }
        public string Object { get; set; }
        public string EventCode { get; set; }
    }
}
