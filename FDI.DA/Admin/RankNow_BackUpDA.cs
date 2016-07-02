using System;
using System.Web;
using FDI.Base;
using System.Collections.Generic;
using System.Linq;
using FDI.Simple;

namespace FDI.DA.Admin
{
    public partial class RankNowBackUpDA : BaseDA
    {
        #region Constructer
        public RankNowBackUpDA()
        {
        }

        public RankNowBackUpDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public RankNowBackUpDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public List<RankNowBackUpItem> GetAllListSimple()
        {
            var query = from c in FDIDB.RankNow_BackUp
                        select new RankNowBackUpItem
                                   {
                                       ID = c.ID,
                                       CustomerId = c.CustomerID,
                                       UserId = c.UserId,
                                       PricePvUser = c.PricePVUser,
                                       UserId1 = c.UserId1,
                                       PvUser = c.PVUser,
                                       PvMonthPvUser1 = c.PVUser1,
                                       PvMonth = c.PVMonth,
                                       PvMonth1 = c.PVMonth1,
                                       ActiveRank = c.ActiveRank,
                                       IsAward = c.IsAward,
                                       CheckLimit = c.CheckLimit,
                                   };
            return query.ToList();
        }

        public List<RankNowBackUpItem> GetListSimpleByRequest(HttpRequestBase httpRequest, out int? monthout, out int? yearout, out int? total)
        {
            var year = DateTime.Now.AddMonths(-1).Year;
            var month = DateTime.Now.AddMonths(-1).Month;
            //if (!string.IsNullOrEmpty(httpRequest.QueryString["Year"]))
            //{
            //    year = Convert.ToInt32(httpRequest.QueryString["Year"]);
            //}
            if (!string.IsNullOrEmpty(httpRequest.QueryString["Month"]))
            {
                month = Convert.ToInt32(httpRequest.QueryString["Month"]);
            }
            yearout = year;
            monthout = month;
            Request = new ParramRequest(httpRequest);
            //var query = new ;
            if (month > 0 && year > 0)
            {

                if (month == 12)
                {
                    month = 1;
                    year++;
                }
                else
                {
                    month++;
                }

                var query = from c in FDIDB.RankNow_BackUp
                            where c.DateCreated.Value.Month == month && c.Level > 0 && c.DateCreated.Value.Year == year && ((c.ActiveRank == 1 && c.IsAward != true) || c.ActiveRank == 2)
                            select new RankNowBackUpItem
                            {
                                ID = c.ID,
                                CustomerId = c.CustomerID,
                                UserName = c.Customer.UserName,
                                Fullname = c.Customer.FullName,
                                UserId = c.UserId,
                                PricePvUser = c.PricePVUser,
                                PricePvUser1 = c.PricePVUser1,
                                UserId1 = c.UserId1,
                                PvUser = c.PVUser,
                                PvMonthPvUser1 = c.PVUser1,
                                PvMonth = c.PVMonth,
                                PvMonth1 = c.PVMonth1,
                                ActiveRank = c.ActiveRank,
                                IsAward = c.IsAward,
                                CheckLimit = c.CheckLimit,
                                PricePvNow = c.PricePVNow,
                                AwardLeader = 0,
                                //DateCreated = c.DateCreated,
                                IsPay = c.IsPay,
                                IsPay40 = c.IsPay40
                            };

                var query3 = query.Where(c => c.ActiveRank == 2 && c.IsAward != true).Select(c => new RankNowBackUpItem
                {
                    ID = c.ID,
                    CustomerId = c.CustomerId,
                    UserName = c.UserName,
                    Fullname = c.Fullname,
                    UserId = c.UserId,
                    PricePvUser = c.PricePvUser,
                    PricePvUser1 = c.PricePvUser1,
                    UserId1 = c.UserId1,
                    PvUser = c.PvUser,
                    PvMonthPvUser1 = c.PvMonthPvUser1,
                    PvMonth = c.PvMonth,
                    PvMonth1 = c.PvMonth1,
                    ActiveRank = 1,
                    IsAward = c.IsAward,
                    CheckLimit = c.CheckLimit,
                    PricePvNow = c.PricePvNow,
                    AwardLeader = 0,
                    IsPay = c.IsPay,
                    IsPay40 = c.IsPay40
                });

                query = query.Concat(query3);
                total = query.Count(m => m.ActiveRank == 1) * 20;
                total = total + query.Count(m => m.ActiveRank == 2) * 40;
                query = query.SelectByRequest(Request, ref TotalRecord);
                return query.ToList();
            }
            else
            {
                var query = from c in FDIDB.RankNow_BackUp
                            where ((c.ActiveRank == 1 && c.IsAward != true) || c.ActiveRank == 2)
                            select new RankNowBackUpItem
                            {
                                ID = c.ID,
                                CustomerId = c.CustomerID,
                                UserName = c.Customer.UserName,
                                Fullname = c.Customer.FullName,
                                UserId = c.UserId,
                                PricePvUser = c.PricePVUser,
                                PricePvUser1 = c.PricePVUser1,
                                UserId1 = c.UserId1,
                                PvUser = c.PVUser,
                                PvMonthPvUser1 = c.PVUser1,
                                PvMonth = c.PVMonth,
                                PvMonth1 = c.PVMonth1,
                                ActiveRank = c.ActiveRank,
                                IsAward = c.IsAward,
                                CheckLimit = c.CheckLimit,
                                PricePvNow = c.PricePVNow,
                                AwardLeader = 0,
                                IsPay = c.IsPay,
                                IsPay40 = c.IsPay40
                            };

                var query3 = query.Where(c => c.ActiveRank == 2 && c.IsAward != true).Select(c => new RankNowBackUpItem
                {
                    ID = c.ID,
                    CustomerId = c.CustomerId,
                    UserName = c.UserName,
                    Fullname = c.Fullname,
                    UserId = c.UserId,
                    PricePvUser = c.PricePvUser,
                    PricePvUser1 = c.PricePvUser1,
                    UserId1 = c.UserId1,
                    PvUser = c.PvUser,
                    PvMonthPvUser1 = c.PvMonthPvUser1,
                    PvMonth = c.PvMonth,
                    PvMonth1 = c.PvMonth1,
                    ActiveRank = 1,
                    IsAward = c.IsAward,
                    CheckLimit = c.CheckLimit,
                    PricePvNow = c.PricePvNow,
                    AwardLeader = 0,
                    IsPay = c.IsPay,
                    IsPay40 = c.IsPay40
                });

                query = query.Concat(query3);
                total = query.Count(m => m.ActiveRank == 1) * 20;
                total = total + query.Count(m => m.ActiveRank == 2) * 40;
                query = query.SelectByRequest(Request, ref TotalRecord);
                return query.ToList();
            }
        }
        public List<RankNowBackUpItem> StatisticCommissionByMonthex(HttpRequestBase httpRequest, out int? monthout, out int? yearout)
        {
            var year = DateTime.Now.AddMonths(-1).Year;
            var month = DateTime.Now.AddMonths(-1).Month;
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
            if (month == 12)
            {
                month = 1;
                year++;
            }
            else
            {
                month++;
            }
            Request = new ParramRequest(httpRequest);
            var query = from c in FDIDB.RankNow_BackUp
                        where c.DateCreated.Value.Year == year && c.DateCreated.Value.Month == month && ((c.ActiveRank == 1 && c.IsAward != true) || c.ActiveRank == 2)
                        select new RankNowBackUpItem
                        {
                            ID = c.ID,
                            CustomerId = c.CustomerID,
                            CustomerItem = (from o in FDIDB.Customers
                                            where o.ID == c.CustomerID
                                            select new CustomerItem
                                            {
                                                UserName = o.UserName,
                                                FullName = o.FullName
                                            }).FirstOrDefault(),
                            UserId = c.UserId,
                            PricePvUser = c.PricePVUser,
                            PricePvUser1 = c.PricePVUser1,
                            UserId1 = c.UserId1,
                            PvUser = c.PVUser,
                            PvMonthPvUser1 = c.PVUser1,
                            PvMonth = c.PVMonth,
                            PvMonth1 = c.PVMonth1,
                            ActiveRank = c.ActiveRank,
                            IsAward = c.IsAward,
                            CheckLimit = c.CheckLimit,
                            PricePvNow = c.PricePVNow,
                            AwardLeader = 0,
                            IsPay = c.IsPay,
                            IsPay40 = c.IsPay40
                        };

            var query3 = query.Where(c => c.ActiveRank == 2 && c.IsAward != true).Select(c => new RankNowBackUpItem
            {
                ID = c.ID,
                CustomerId = c.CustomerId,
                CustomerItem = c.CustomerItem,
                UserId = c.UserId,
                PricePvUser = c.PricePvUser,
                PricePvUser1 = c.PricePvUser1,
                UserId1 = c.UserId1,
                PvUser = c.PvUser,
                PvMonthPvUser1 = c.PvMonthPvUser1,
                PvMonth = c.PvMonth,
                PvMonth1 = c.PvMonth1,
                ActiveRank = 1,
                IsAward = c.IsAward,
                CheckLimit = c.CheckLimit,
                PricePvNow = c.PricePvNow,
                AwardLeader = 0,
                IsPay = c.IsPay,
                IsPay40 = c.IsPay40
            });
            query = query.Concat(query3);
            if (!string.IsNullOrEmpty(httpRequest.QueryString["Keyword"]) && !string.IsNullOrEmpty(httpRequest.QueryString["SearchIn"]) && httpRequest.QueryString["SearchIn"].ToLower() == "username")
            {
                var userName = httpRequest.QueryString["Keyword"];
                query = query.Where(m => m.CustomerItem.UserName.ToLower().Equals(userName.ToLower()));
            }
            return query.ToList();
        }

        public RankNow GetRankNowById(int id)
        {
            var query = from c in FDIDB.RankNows where c.ID == id select c;
            return query.FirstOrDefault();
        }
        public RankNow_BackUp GetRankNowByCustomerId(int id, int month)
        {
            var query = from c in FDIDB.RankNow_BackUp where c.CustomerID == id && c.DateCreated.Value.Month==month select c;
            return query.FirstOrDefault();
        }
        public RankNowItem GetItemById(int customerId)
        {
            var query = from c in FDIDB.RankNow_BackUp
                        where c.CustomerID == customerId
                        select new RankNowItem
                        {
                            PVUser = c.PricePVUser + c.PVMonth,
                            PVUser1 = c.PricePVUser1 + c.PVMonth1
                        };
            return query.FirstOrDefault();
        }
        public RankNow_BackUp GetRankNowBackupById(int id)
        {
            var query = from c in FDIDB.RankNow_BackUp where c.ID == id select c;
            return query.FirstOrDefault();
        }

        public List<RankNow> GetListRankNowByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.RankNows where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }

        public List<RankNow_BackUp> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.RankNow_BackUp where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }

        public void Save()
        {

            FDIDB.SaveChanges();
        }
    }
}
