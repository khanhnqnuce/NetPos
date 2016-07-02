using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA.Admin
{
    public class RegisteredAgencyDA : BaseDA
    {
        #region Constructer
        public RegisteredAgencyDA()
        {
        }

        public RegisteredAgencyDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public RegisteredAgencyDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        public List<RegisteredAgencyItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);

            var year = DateTime.Now.Year;

            var month = DateTime.Now.Month;

            if (!string.IsNullOrEmpty(httpRequest.QueryString["Year"]))
            {
                year = Convert.ToInt32(httpRequest.QueryString["Year"]);
            }

            if (!string.IsNullOrEmpty(httpRequest.QueryString["Month"]))
            {
                month = Convert.ToInt32(httpRequest.QueryString["Month"]);
            }

            var query = from o in FDIDB.RegisteredAgencies
                        where o.CreateDate.Value.Year == year && o.CreateDate.Value.Month == month
                        orderby o.CreateDate descending 
                        select new RegisteredAgencyItem()
                        {
                            ID = o.ID,
                            UserName = o.Customer.UserName,
                            AgencyName = o.ProvincialAgency.Name,
                            CreateDate = o.CreateDate,
                            Code = o.ProvincialAgency.Code,
                            IsSMS = o.IsSMS
                        };

            if (!string.IsNullOrEmpty(httpRequest.QueryString["isSMS"]))
            {
                var issms = Convert.ToBoolean(httpRequest.QueryString["isSMS"]);
                query = query.Where(c => c.IsSMS == issms);
            } 

            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        public RegisteredAgencyItem GetSystemConfigItemById(int id)
        {
            var query = from o in FDIDB.RegisteredAgencies
                        where o.ID == id
                        orderby o.ID descending
                        select new RegisteredAgencyItem()
                        {
                            ID = o.ID,
                            UserName = o.Customer.UserName,
                            AgencyName = o.ProvincialAgency.Name
                        };
            return query.FirstOrDefault();
        }

        public RegisteredAgency GetById(int id)
        {
            var query = from c in FDIDB.RegisteredAgencies where c.ID == id select c;
            return query.FirstOrDefault();
        }

        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="registeredAgency">bản ghi cần thêm</param>
        public void Add(RegisteredAgency registeredAgency)
        {
            FDIDB.RegisteredAgencies.Add(registeredAgency);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="registeredAgency">Xóa bản ghi</param>

        public void Delete(RegisteredAgency registeredAgency)
        {
            FDIDB.RegisteredAgencies.Remove(registeredAgency);
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
