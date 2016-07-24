using System;
using System.Linq;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public partial class UserDA : BaseDA
    {
        public UserItem Login(string user, string pass)
        {
            try
            {
                var query = from c in FDIDB.tblUsers
                            where c.UserName == user && c.Password == pass
                            select new UserItem
                            {
                                UserName = c.UserName,
                                FullName = c.FullName,
                                CardNumber = c.CardNumber,
                                Code = c.Code,
                                Right1 = c.Right1 ?? -1,
                                IsLockUser = c.IsLockUser
                            };
                return query.FirstOrDefault();
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
