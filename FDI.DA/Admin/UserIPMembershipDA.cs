using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA.Admin
{
    public class UserIPMembershipDA : BaseDA
    {
        #region Constructer
        public UserIPMembershipDA()
        {
        }

        public UserIPMembershipDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public UserIPMembershipDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        public List<aspnet_UsersIPMembershipItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);
            var query = from c in FDIDB.aspnet_UsersIPMembership
                        select new aspnet_UsersIPMembershipItem
                               {
                                   ID = c.ID,
                                   IP = c.IP,
                                   UserID = c.UserID,
                                   IsActive = c.IsActive,
                                   UserName = c.aspnet_Users.UserName,
                                   aspnet_Users = new aspnet_UsersItem
                                                  {
                                                      UserName = c.aspnet_Users.UserName
                                                  }
                               };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        public bool CheckIpMembership(string userName, string ip)
        {
            var query = from c in FDIDB.aspnet_UsersIPMembership 
                        where c.aspnet_Users.UserName.ToLower() == userName && c.IP == ip 
                        select c;
            var boola = query.Any();
            return boola;
            //return query.Any();
        }

        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public aspnet_UsersIPMembership GetById(int id)
        {
            var query = from c in FDIDB.aspnet_UsersIPMembership where c.ID == id select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<aspnet_UsersIPMembership> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.aspnet_UsersIPMembership where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }




        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="systemConfig"> bản ghi cần thêm</param>
        public void Add(aspnet_UsersIPMembership systemConfig)
        {
            FDIDB.aspnet_UsersIPMembership.Add(systemConfig);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="systemConfig">Xóa bản ghi</param>
        public void Delete(aspnet_UsersIPMembership systemConfig)
        {
            FDIDB.aspnet_UsersIPMembership.Remove(systemConfig);
        }

        /// <summary>
        /// save bản ghi vào DB
        /// </summary>
        public void Save()
        {
            FDIDB.SaveChanges();
        }
        #endregion
    }
}
