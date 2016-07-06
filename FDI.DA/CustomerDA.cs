using System;
using System.Collections.Generic;
using System.Linq;
using FDI.Base;

namespace FDI.DA
{
    public partial class CustomerDA : BaseDA
    {
        public List<tblUser> GetAdminAllSimple()
        {
            try
            {
                var query = from c in FDIDB.tblUsers
                            select c;
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
