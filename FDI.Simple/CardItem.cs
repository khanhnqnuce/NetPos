namespace FDI.Simple
{
    public class CardItem:BaseSimple
    {
        public string Code { get; set; }
        public string CardNumber { get; set; }
        public string AccountName { get; set; }
        public int Balance { get; set; }
        public string CardTypeCode { get; set; }
        public bool IsRelease { get; set; }
        public bool IsLockCard { get; set; }
        public bool IsEdit { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}