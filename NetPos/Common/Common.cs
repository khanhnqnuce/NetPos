using System.Configuration;

namespace NetPos
{
    class Common
    {
        public static string ConnectString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        public static string UserName = ConfigurationManager.AppSettings["UserName"];
    }
}
