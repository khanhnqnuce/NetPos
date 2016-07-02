using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class aspnet_UsersItem
    {
        public Guid ApplicationId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string LoweredUserName { get; set; }
        public string MobileAlias { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime LastActivityDate { get; set; }
        public virtual IEnumerable<UserModuleActiveItem> User_ModuleActive { get; set; }
        //public virtual aspnet_Applications aspnet_Applications { get; set; }
        //public virtual aspnet_Membership aspnet_Membership { get; set; }
        //public virtual ICollection<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
        //public virtual aspnet_Profile aspnet_Profile { get; set; }
        public virtual IEnumerable<aspnet_RolesItem> aspnet_Roles { get; set; }
        public virtual IEnumerable<ModuleItem> Modules { get; set; }
    }
}
