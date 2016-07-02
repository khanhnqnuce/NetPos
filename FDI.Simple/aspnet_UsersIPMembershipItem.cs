using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class aspnet_UsersIPMembershipItem:BaseSimple
    {
        public Guid? UserID { get; set; }
        public string IP { get; set; }
        public bool? IsActive { get; set; }
        public string UserName { get; set; }
        public virtual aspnet_UsersItem aspnet_Users { get; set; }
    }
}
