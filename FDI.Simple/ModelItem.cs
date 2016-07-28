using System;

namespace FDI.Simple
{
    public class ModelItem
    {

        public DateTime StartDate
        {
            get
            {
                var date = DateTime.Now;
                return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
            }
            set { }
        }

        public DateTime EndDate
        {
            get
            {
                var date = DateTime.Now;
                return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
            }
            set { }
        }
        public string BuidingCode { get; set; }
        public string AreaCode { get; set; }
        public string ObjectCode { get; set; }
    }
}
