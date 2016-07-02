using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using FDI.Utils;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA.Admin
{
    public class HistoryAwaysMaRoiDA : BaseDA
    {
        #region Constructer
        public HistoryAwaysMaRoiDA()
        {
        }

        public HistoryAwaysMaRoiDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

		public HistoryAwaysMaRoiDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy về kiểu đơn giản, phân trang
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
		public List<HistoryAwaysMaRoiItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);
			var query = from c in FDIDB.HistoryAwaysMaRois
						orderby c.ID descending
						where c.IsDeleted == false
						select new HistoryAwaysMaRoiItem
                                   {
                                       ID = c.ID,
                                       CustomerId = c.CustomerId,
									   CustomeRankCustomerId = c.CustomeRankCustomerId ?? 0,
									   UserName = c.Customer.UserName,
									   DateCreated = c.DateCreated,
									   FullName = c.Customer.FullName,
									   //Customer = new Customer()
									   //{
									   //	UserName = c.Customer.UserName,
									   //	FirstName = c.Customer.FirstName,
									   //	LastName = c.Customer.LastName,
									   //},
									   IsDeleted = c.IsDeleted
                                   };
			if (!string.IsNullOrEmpty(httpRequest.QueryString["fromCreateDate"]))
			{
				var formDate = FDI.Utils.MyDateTime.ToDate(httpRequest.QueryString["fromCreateDate"]);
				query = query.Where(c => c.DateCreated > formDate);
			}

			if (!string.IsNullOrEmpty(httpRequest.QueryString["toCreateDate"]))
			{
				var toDate = FDI.Utils.MyDateTime.ToDate(httpRequest.QueryString["toCreateDate"]).AddDays(1);
				query = query.Where(c => c.DateCreated < toDate);
			}
			//if (!string.IsNullOrEmpty(httpRequest.QueryString["Keyword"]))
			//{
			//	var keyword = httpRequest.QueryString["Keyword"];
			//	if (!string.IsNullOrEmpty(httpRequest.QueryString["SearchIn"]))
			//	{
			//		var searchIn = httpRequest.QueryString["SearchIn"];
			//		query = searchIn == "UserName" ? query.Where(c => c.Customer.UserName.Equals(keyword)) : querynew.Where(c => c.ProvincialAgenciesCode.Equals(keyword));
			//	}
			//}
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

		public List<HistoryAwaysMaRoiItem> GetByAll()
        {
			var query = from c in FDIDB.HistoryAwaysMaRois
						select new HistoryAwaysMaRoiItem
                        {
							ID = c.ID,
							CustomerId = c.CustomerId,
							CustomeRankCustomerId = c.CustomeRankCustomerId ?? 0,
                        };
            return query.ToList();
        }

		public List<HistoryAwaysMaRoiItem> GetByCustomerID(int IdCustomer)
		{
			var query = from c in FDIDB.HistoryAwaysMaRois
						where c.CustomerId == IdCustomer
						select new HistoryAwaysMaRoiItem
						{
							ID = c.ID,
							DateCreated = c.DateCreated,
							FullName = c.Customer.FullName,
						};
			return query.ToList();
		}

		public HistoryAwaysMaRoi GetById(int id)
        {
			var query = from c in FDIDB.HistoryAwaysMaRois
                        where c.ID == id
                        select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <returns>Bản ghi</returns>
		public HistoryAwaysMaRoiItem GetRoleItemById(int id)
        {
			var query = from c in FDIDB.HistoryAwaysMaRois
                        where c.ID == id
						select new HistoryAwaysMaRoiItem
                        {
							ID = c.ID,
							CustomerId = c.CustomerId,
							CustomeRankCustomerId = c.CustomeRankCustomerId,
							Customer = new Customer
							{
								ID = c.ID,
								UserName = c.Customer.UserName,
								FullName = c.Customer.FullName,
							},
							IsDeleted = c.IsDeleted
                        };
            var result = query.FirstOrDefault();
            return result;
        }

		public List<HistoryAwaysMaRoiItem> GetAll()
        {
			var query = from c in FDIDB.HistoryAwaysMaRois
						select new HistoryAwaysMaRoiItem
                                   {
									   ID = c.ID,
									   CustomerId = c.CustomerId,
									   CustomeRankCustomerId = c.CustomeRankCustomerId,
                                   };
            return query.ToList();
        }

	    /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
		public List<HistoryAwaysMaRoi> GetListByArrID(List<int> ltsArrID)
        {
			var query = from c in FDIDB.HistoryAwaysMaRois where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="activeRole">bản ghi cần thêm</param>
		public void Add(HistoryAwaysMaRoi historyAwaysMaRoi)
        {
			FDIDB.HistoryAwaysMaRois.Add(historyAwaysMaRoi);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
		public void Delete(HistoryAwaysMaRoi historyAwaysMaRoi)
        {
			FDIDB.HistoryAwaysMaRois.Remove(historyAwaysMaRoi);
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
