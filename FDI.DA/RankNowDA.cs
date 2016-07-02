using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FDI.Base;
using FDI.Simple;
using FDI.Utils;

namespace FDI.DA.Admin
{
    public class RankNowDA : BaseDA
    {
        #region Constructer
        public RankNowDA()
        {

        }

        public RankNowDA(string pathPaging)
        {
            PathPaging = pathPaging;

        }

        public RankNowDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;

        }
        #endregion

        public List<RankNowItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);

            var query = from o in FDIDB.RankNows
                        select new RankNowItem
                        {
                            ID = o.ID,
                            CustomerID = o.CustomerID,
                            UserName = o.Customer.UserName,
							CycleNumber = o.CycleNumber,
                            Customer = new CustomerItem()
                                      {
                                          UserName = o.Customer.UserName,
                                          FullName = o.Customer.FullName,
                                          Title = o.Customer.Title,
                                          ProvincialAgencyID = o.Customer.ProvincialAgencyID
                                      },

                            PricePVUser = o.PricePVUser,
                            PricePVUser1 = o.PricePVUser1,
                            PVMonth = o.PVMonth,
                            PVMonth1 = o.PVMonth1,
                            LevelId = o.Rank.Name
                        };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();

        }


		public RankNow GetRankNowByCustomerId(int Id)
		{
			var query = from c in FDIDB.RankNows where c.CustomerID == Id select c;
			return query.FirstOrDefault();
		}

		public List<RankNowItem> GetListCustomerProvincialAgencies(int id)
		{
			var lst = GetAllListSimple().Where(m => m.Customer.ProvincialAgencyID == id).ToList();
			return lst;
		}

		public List<RankNowItem> GetAllListSimple()
		{
			var lst = from c in FDIDB.RankNows
				select new RankNowItem
				{
					Customer = new CustomerItem()
					{
						UserName = c.Customer.UserName,
					},
                    LevelId = c.Rank.Name,
				};
			return lst.ToList();
		}

        public RankNow GetRankNowById(int Id)
        {
            var query = from c in FDIDB.RankNows where c.ID == Id select c;
            return query.FirstOrDefault();
        }

        public RankNow GetById(int customerId)
        {
            var query = from c in FDIDB.RankNows where c.CustomerID == customerId select c;
            return query.FirstOrDefault();
        }

        public RankNowItem GetItemById(int customerId)
        {
            var query = from c in FDIDB.RankNows
                        where c.CustomerID == customerId
                        select new RankNowItem
            {
                PVUser = c.PVUser,
                PVUser1 = c.PVUser1,
				ID = c.ID,
                //PricePVUser = c.PricePVUser,
                //PricePVUser1 = c.PricePVUser1,
                PVMonth = c.PVMonth,
                PVMonth1 = c.PVMonth1,
                LevelId = c.Rank.Name
            };
            return query.FirstOrDefault();
        }

		public List<RankNowItem> RankNowPage(int currentPage, int rowPerPage, List<RankNowItem> listNewsItem)
		{
			return GetPageBySPQuery2(listNewsItem, currentPage, rowPerPage);
		}
		public static int TongSoBanGhiSauKhiQuery { get; set; }
		public List<RankNowItem> GetPageBySPQuery2(List<RankNowItem> query, int currentPage, int rowPerPage)
		{
			#region lấy về bảng tạm & danh sách ID

			var ltsNewsItem = query; //Lấy về tất cả
			var ltsIdSelect = new List<int>();
			if (ltsNewsItem.Any())
			{
				TongSoBanGhiSauKhiQuery = ltsNewsItem.Count(); // Tổng số lấy về        
				int intBeginFor = (currentPage - 1) * rowPerPage; //index Bản ghi đầu tiên cần lấy trong bảng
				int intEndFor = (currentPage * rowPerPage) - 1; ; //index bản ghi cuối
				intEndFor = (intEndFor > (TongSoBanGhiSauKhiQuery - 1)) ? (TongSoBanGhiSauKhiQuery - 1) : intEndFor; //nếu vượt biên lấy row cuối

				for (int rowIndex = intBeginFor; rowIndex <= intEndFor; rowIndex++)
				{
					ltsIdSelect.Add(Convert.ToInt32(ltsNewsItem[rowIndex].ID));
				}

			}
			else
				TongSoBanGhiSauKhiQuery = 0;
			#endregion
			//Query listItem theo listID
			var iquery = from c in ltsNewsItem
						 where ltsIdSelect.Contains(c.ID)

						 select c;

			return iquery.ToList();
		}
        public void Add(RankNow rankNow)
        {
            FDIDB.RankNows.Add(rankNow);
        }
        public void Save()
        {

            FDIDB.SaveChanges();
        }
    }
}
