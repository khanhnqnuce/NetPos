namespace FDI.Simple
{
    public class UserItem : BaseSimple
    {
        public string Code { get; set; }
        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Right1 { get; set; }
        public bool IsLockUser { get; set; }
    }
}
