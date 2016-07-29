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
                var query = from c in FDIDB.sp_Login(user,pass)
                            select new UserItem
                            {
                                ID = c.Id,
                                UserName = c.UserName,
                                FullName = c.FullName,
                                Code = c.Code,
                                Right1 = c.Right1,
                                AreaCode = c.AreaCode,
                                BuidingCode = c.BuidingCode,
                                Password = c.Password
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
