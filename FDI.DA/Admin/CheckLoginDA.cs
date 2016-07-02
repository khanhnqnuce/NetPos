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
    public class CheckLoginDA : BaseDA
    {
        #region Constructer
        public CheckLoginDA()
        {

        }

        public CheckLoginDA(string pathPaging)
        {
            PathPaging = pathPaging;

        }

        public CheckLoginDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;

        }
        #endregion


        public List<CheckLoginItem> GetCustomerLeader(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);
            var query = from c in FDIDB.CheckLogins
                        select new CheckLoginItem
                        {
                            ID = c.ID,
                          
                        };
            return query.ToList();


        }
        public CheckLoginItem GetItemByCode(string code)
        {
            var date = DateTime.Now;
            var query = from c in FDIDB.CheckLogins
                        where c.Code == code && c.IsLogin == true && c.DateEnd > date
                        select new CheckLoginItem
                        {
                            ID=c.ID,
                            Code=c.Code,
                            CustomerID = c.CustomerID,
                            IpAddress=c.IpAddress,
                            IsLogin=c.IsLogin,
                            DateCreated=c.DateCreated,
                            DateEnd=c.DateEnd,
                            Customer = new CustomerItem
                            {
                                ID=c.Customer.ID,
                                Title=c.Customer.Title,
                                UserName=c.Customer.UserName,
								FullName = c.Customer.FullName,
                                //IsAdmin=c.Customer.IsAdmin,
                            }
                        };
            return query.FirstOrDefault();

        }

        public CheckLogin GetByCode(string code)
        {
            var query = from c in FDIDB.CheckLogins where c.Code == code select c;
            return query.FirstOrDefault();
        }

        public CheckLogin GetByID(int id)
        {
            var query = from c in FDIDB.CheckLogins
                        where c.ID == id
                        select c;
            return query.FirstOrDefault();

        }

		public List<CheckLogin> CheckLoginByCustomerID(int CustomerID)
		{
			var date = DateTime.Now;
			var query = from c in FDIDB.CheckLogins
						where c.CustomerID == CustomerID
						select c;
			return query.ToList();
		}

        public CheckLoginItem CheckLoginByUserName(string userName)
        {
            var date = DateTime.Now;
            var query = from c in FDIDB.CheckLogins
                        where c.Customer.UserName == userName && c.IsLogin == true && c.DateEnd > date
                        select new CheckLoginItem
                        {
                            Code = c.Code,
                            IsLogin = c.IsLogin,
                            CustomerID = c.CustomerID,
                            IpAddress=c.IpAddress,
                            Customer = new CustomerItem { 
                                
                            }
                        };
            return query.FirstOrDefault();
        }
        
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="checkLogin"> </param>
        public void Add(CheckLogin checkLogin)
        {            
            FDIDB.CheckLogins.Add(checkLogin);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        public void Delete(CheckLogin checkLogin)
        {
            FDIDB.CheckLogins.Remove(checkLogin);
        }

        /// <summary>
        /// save bản ghi vào DB
        /// </summary>
        public void Save()
        {

            FDIDB.SaveChanges();
        }
    }
}
