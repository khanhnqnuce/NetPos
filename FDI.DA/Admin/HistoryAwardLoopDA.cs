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
    public class HistoryAwardLoopDA : BaseDA
    {
        #region Constructer
        public HistoryAwardLoopDA()
        {
        }

        public HistoryAwardLoopDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

		public HistoryAwardLoopDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy về kiểu đơn giản, phân trang
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
		public List<HistoryAwardLoopItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);
			var query = from c in FDIDB.HistoryAwardLoops
						orderby c.ID descending
						where c.IsDeleted == false
						select new HistoryAwardLoopItem
                                   {
                                       ID = c.ID,
                                       CustomerID = c.CustomerID,
									   CustomerRankID = c.CustomerRankID,
									   UserName = c.Customer.UserName,
									   DateCreated = c.DateCreated,
									   FullName = c.Customer.FullName,									  
									   IsDeleted = c.IsDeleted
                                   };
			if (!string.IsNullOrEmpty(httpRequest.QueryString["fromCreateDate"]))
			{
				var formDate = MyDateTime.ToDate(httpRequest.QueryString["fromCreateDate"]);
				query = query.Where(c => c.DateCreated > formDate);
			}

			if (!string.IsNullOrEmpty(httpRequest.QueryString["toCreateDate"]))
			{
				var toDate = MyDateTime.ToDate(httpRequest.QueryString["toCreateDate"]).AddDays(1);
				query = query.Where(c => c.DateCreated < toDate);
			}
			
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

		public List<HistoryAwardLoopItem> GetByAll()
        {
			var query = from c in FDIDB.HistoryAwardLoops
						select new HistoryAwardLoopItem
                        {
							ID = c.ID,
							CustomerID = c.CustomerID,
							CustomerRankID = c.CustomerRankID,
                        };
            return query.ToList();
        }

		public List<HistoryAwardLoopItem> GetByCustomerID(int IdCustomer)
		{
			var query = from c in FDIDB.HistoryAwardLoops
						where c.CustomerID == IdCustomer
						select new HistoryAwardLoopItem
						{
							ID = c.ID,
							DateCreated = c.DateCreated,
						};
			return query.ToList();
		}

		public int GetMaxTriAn()
		{
			var query = from c in FDIDB.HistoryAwardLoops
						orderby c.ID descending
						select c.ID;
			return query.FirstOrDefault();
		}

        public HistoryAwardLoop GetById(int id)
        {
            var query = from c in FDIDB.HistoryAwardLoops
                        where c.ID == id
                        select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <returns>Bản ghi</returns>
		public HistoryAwardLoopItem GetRoleItemById(int id)
        {
			var query = from c in FDIDB.HistoryAwardLoops
                        where c.ID == id
						select new HistoryAwardLoopItem
                        {
							ID = c.ID,
							CustomerID = c.CustomerID,
							CustomerRankID = c.CustomerRankID,
							Customer = new Customer()
							{
								ID = c.ID,
								UserName = c.Customer.UserName,
								FullName = c.Customer.FullName
							},
							IsDeleted = c.IsDeleted
                        };
            var result = query.FirstOrDefault();
            return result;
        }

		public List<HistoryAwardLoopItem> GetAll()
        {
			var query = from c in FDIDB.HistoryAwardLoops
						select new HistoryAwardLoopItem
                                   {
									   ID = c.ID,
									   CustomerID = c.CustomerID,
									   CustomerRankID = c.CustomerRankID,
                                   };
            return query.ToList();
        }

       
	    /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
		public List<HistoryAwardLoop> GetListByArrID(List<int> ltsArrID)
        {
			var query = from c in FDIDB.HistoryAwardLoops where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="activeRole">bản ghi cần thêm</param>
		public void Add(HistoryAwardLoop historyAwardLoop)
        {
			FDIDB.HistoryAwardLoops.Add(historyAwardLoop);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
		public void Delete(HistoryAwardLoop historyAwardLoop)
        {
			FDIDB.HistoryAwardLoops.Remove(historyAwardLoop);
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
