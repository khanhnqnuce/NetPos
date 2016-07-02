using System.Text;
using FDI.Base;
using FDI.DA;
using FDI.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FDI.DA.Admin
{
    public class HistoryUpRankDA : BaseDA
    {
        #region Constructer
        public HistoryUpRankDA()
        {

        }

        public HistoryUpRankDA(string pathPaging)
        {
            PathPaging = pathPaging;

        }

        public HistoryUpRankDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;

        }
        #endregion

        public List<CustomerItem> GetAllAdmin()
        {
            //var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var query = from c in FDIDB.Customers
                        where c.HistoryUpRanks.Any()
                        select new CustomerItem
                        {
                            ID = c.ID,
                            UserName = c.UserName,
                            FullName = c.FullName,
                            HistoryUpRankItem = c.HistoryUpRanks.OrderByDescending(m => m.DateCreated).Select(m => new HistoryUpRankItem
                            {
                                //IsPlay = m.IsPlay,
                                DateCreated = m.DateCreated,
                                LevelRank = m.LevelRank,
                                //PVNow = m.PVNow,
                                //PVNow1 = m.PVNow1,
                                //PVAward = m.PVAward
                            }).FirstOrDefault(),

                        };
            return query.ToList();
        }

        public HistoryUpRank GetById(int customerId)
        {
            var query = from c in FDIDB.HistoryUpRanks where c.CustomerID == customerId select c;
            return query.FirstOrDefault();
        }

        //phuocnh
        //lay historyuprank theo customerid, name historyuprank
        public HistoryUpRankItem GetHistoryUpRankByCustomerIdNam(int customerid, string name)
        {
            var query = from c in FDIDB.HistoryUpRanks where c.CustomerID == customerid && c.Name == name select new HistoryUpRankItem()
            {
                ID = c.ID,
                Name = c.Name,
                CustomerID = c.CustomerID
            };
            return query.FirstOrDefault();
        }

        public IEnumerable<HistoryUpRankItem> GetRankByLevelAndDate(HttpRequestBase httpRequest, out int? monthout, out int? yearout, out decimal? total)
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
            yearout = year;
            monthout = month;
            string allLevel = "Pro,Silver,Gold,Leader";
            if ((httpRequest.QueryString["Level"]!=null))
            {
                var level = httpRequest.QueryString["Level"].ToString();
                var query = from c in FDIDB.HistoryUpRanks
                            where c.IsDeleted == false && c.Name == level && c.DateCreated.Value.Month==month&&c.DateCreated.Value.Year==year
                            select new HistoryUpRankItem()
                            {
                                ID = c.ID,
                                Name = c.Name,
                                CustomerID = c.CustomerID,
                                UserName = c.Customer.UserName,
                                Customer = new CustomerItem
                                {
                                    ID = c.CustomerID.Value,
                                    UserName = c.Customer.UserName,
                                    FullName = c.Customer.FullName,
                                },
                                DateCreated = c.DateCreated,
                              
                            };
                query = query.SelectByRequest(Request, ref TotalRecord);

                //total = query.Sum(c => c.PVNow);
                total = TotalRecord;

                return query.ToList();
            }
            else
            {
                var query = from c in FDIDB.HistoryUpRanks
                            where c.IsDeleted == false && allLevel.Contains(c.Name) && c.DateCreated.Value.Month == month && c.DateCreated.Value.Year == year
                            select new HistoryUpRankItem()
                            {
                                ID = c.ID,
                                Name = c.Name,
                                CustomerID = c.CustomerID,
                                UserName = c.Customer.UserName,
                                Customer = new CustomerItem
                                {
                                    ID = c.CustomerID.Value,
                                    UserName = c.Customer.UserName,
                                    FullName = c.Customer.FullName,
                                },
                                DateCreated = c.DateCreated,
                               
                            };
               // total = query.Sum(c => c.PVNow);
                query = query.SelectByRequest(Request, ref TotalRecord);
                total = TotalRecord;

                return query.ToList();
            }   
        }

        public void Add(HistoryUpRank historyUpRank)
        {
            FDIDB.HistoryUpRanks.Add(historyUpRank);
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<HistoryUpRank> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.HistoryUpRanks where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }

        public void Save()
        {

            FDIDB.SaveChanges();
        }
    }
}
