using System;
using System.Collections.Generic;
using System.Linq;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public partial class UserDA : BaseDA
    {
        public List<UserItem> GetAdminAllSimple()
        {
            try
            {
                var query = from c in FDIDB.tblUsers
                    select new UserItem
                    {
                        UserName = c.UserName,
                        FullName = c.FullName
                    };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }
            
        }
       
        public void Add(tblUser item)
        {
            FDIDB.tblUsers.Add(item);
        }

        public void Delete(tblUser item)
        {
            FDIDB.tblUsers.Remove(item);
        }
        
        public void Save()
        {

            FDIDB.SaveChanges();
        }
       
    }
}
