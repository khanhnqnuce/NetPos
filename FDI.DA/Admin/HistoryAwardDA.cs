using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA.Admin
{
    public class HistoryAwardDA : BaseDA
    {
        #region Constructer
        public HistoryAwardDA()
        {
        }

        public HistoryAwardDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public HistoryAwardDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        public List<CustomerItem> GetlistsimpleSum(HttpRequestBase httpRequest, bool isPulish, bool isrank, out int monthout, out int yearout)
        {

            Request = new ParramRequest(httpRequest);
            int month = 0, year = 0;
            if (!string.IsNullOrEmpty(httpRequest.QueryString["Month"]))
            {
                month = Convert.ToInt16(httpRequest.QueryString["Month"]);
            }

            if (!string.IsNullOrEmpty(httpRequest.QueryString["Year"]))
            {
                year = Convert.ToInt16(httpRequest.QueryString["Year"]);
            }

            if (!string.IsNullOrEmpty(httpRequest.QueryString["Keyword"]) && !string.IsNullOrEmpty(httpRequest.QueryString["SearchIn"]) && ((httpRequest.QueryString["SearchIn"] == "UserCustomer") || (httpRequest.QueryString["SearchIn"] == "CustomerRankId")))
            {

                var tk = httpRequest.QueryString["Keyword"].ToLower();
                var query = from o in FDIDB.Customers
                            where o.IsDelete == false && o.IsActive == true && o.HistoryAwards.Any(m => m.DateCreated.Value.Month == month && m.DateCreated.Value.Year == year && m.IsRank == true)
                            && (o.PeoplesIdentity.ToLower().Equals(tk)) // ẩn đi id = 1
                            orderby o.ID descending
                            select new CustomerItem
                            {
                                ID = o.ID,
                                FullName = o.FullName,
                                PeoplesIdentity = o.PeoplesIdentity,
                                Mobile = o.Mobile,
                                Address = o.Address,
                                TaxCode = o.TaxCode,
                                NameCompany = o.NameCompany,
                                TotalPricePv = o.HistoryAwards.Where(m => m.DateCreated.Value.Month == month && m.DateCreated.Value.Year == year && m.IsRank == true).Sum(m => m.PricePV)
                            };
                monthout = month;
                yearout = year;
                return query.ToList();

            }

            var querynew = from o in FDIDB.Customers
                           where o.IsDelete == false && o.IsActive == true && o.HistoryAwards.Any(m => m.DateCreated.Value.Month == month && m.DateCreated.Value.Year == year && m.IsRank == true)
                           orderby o.ID descending
                           select new CustomerItem
                           {
                               ID = o.ID,
                               FullName = o.FullName,
                               PeoplesIdentity = o.PeoplesIdentity,
                               Mobile = o.Mobile,
                               Address = o.Address,
                               TaxCode = o.TaxCode,
                               NameCompany = o.NameCompany,
                               TotalPricePv = o.HistoryAwards.Where(m => m.DateCreated.Value.Month == month && m.DateCreated.Value.Year == year && m.IsRank == true).Sum(m => m.PricePV)

                           };
            monthout = month;
            yearout = year;
            return querynew.ToList();
        }

        public List<HistoryAwardItem> GetListSimpleByRequest(HttpRequestBase httpRequest, out decimal? total, bool isrank)
        {
            Request = new ParramRequest(httpRequest);
            if (!string.IsNullOrEmpty(httpRequest.QueryString["Keyword"]) && !string.IsNullOrEmpty(httpRequest.QueryString["SearchIn"]) && (httpRequest.QueryString["SearchIn"] == "UserCustomer"))
            {
                var tk = httpRequest.QueryString["Keyword"].ToLower();
                var query = from o in FDIDB.HistoryAwards
                            where o.IsDeleted == false && o.IsRank == isrank && o.CustomerId != 1 && o.Customer != null && o.Customer.UserName.ToLower().Equals(tk)// ẩn đi id = 1
                            orderby o.ID descending
                            select new HistoryAwardItem
                            {
                                ID = o.ID,
                                Name = o.Name,
                                IsShow = o.IsShow,
                                PricePV = o.PricePV,
                                CheckAwardkId = o.CheckAwardkId,
                                NameCustomer = o.Customer.FullName,
                                UserCustomer = o.Customer.UserName,
                                MobileCustomer = o.Customer.Mobile,
                                DateCreated = o.DateCreated
                            };
                if (!string.IsNullOrEmpty(httpRequest.QueryString["KeywordAward"]))
                {
                    try
                    {
                        var tknew = Convert.ToInt32(httpRequest.QueryString["KeywordAward"].ToLower());
                        query = query.Where(m => m.CheckAwardkId == tknew);
                    }
                    catch (Exception)
                    {
                    }

                }
                //var a = query.Count();
                if (!string.IsNullOrEmpty(httpRequest.QueryString["fromCreateDate"]))
                {
                    var formDate = Convert.ToDateTime(httpRequest.QueryString["fromCreateDate"]);
                    query = query.Where(c => c.DateCreated > formDate);
                }

                if (!string.IsNullOrEmpty(httpRequest.QueryString["toCreateDate"]))
                {
                    var toDate = Convert.ToDateTime(httpRequest.QueryString["toCreateDate"]).AddDays(1);
                    query = query.Where(c => c.DateCreated < toDate);
                }
                total = query.Sum(m => m.PricePV);
                query = query.SelectByRequest(Request, ref TotalRecord);
                return query.ToList();
            }
            var querynew = from o in FDIDB.HistoryAwards
                           where o.IsDeleted == false && o.IsRank == isrank && o.CustomerId != 1 // ẩn đi id = 1
                           orderby o.ID descending
                           select new HistoryAwardItem
                           {
                               ID = o.ID,
                               Name = o.Name,
                               IsShow = o.IsShow,
                               PricePV = o.PricePV,
                               NameCustomer = o.Customer.FullName,
                               UserCustomer = o.Customer.UserName,
                               MobileCustomer = o.Customer.Mobile,
                               DateCreated = o.DateCreated
                           };
            if (!string.IsNullOrEmpty(httpRequest.QueryString["fromCreateDate"]))
            {
                var formDate = Convert.ToDateTime(httpRequest.QueryString["fromCreateDate"]);
                querynew = querynew.Where(c => c.DateCreated > formDate);
            }

            if (!string.IsNullOrEmpty(httpRequest.QueryString["toCreateDate"]))
            {
                var toDate = Convert.ToDateTime(httpRequest.QueryString["toCreateDate"]).AddDays(1);
                querynew = querynew.Where(c => c.DateCreated < toDate);
            }
            total = querynew.Sum(m => m.PricePV);
            querynew = querynew.SelectByRequest(Request, ref TotalRecord);

            return querynew.ToList();

        }

        public List<CustomerItem> GetListSimpleByRequest(HttpRequestBase httpRequest, out decimal? total, bool isPulish, bool isrank, int month, int year)
        {
            Request = new ParramRequest(httpRequest);
            var query = from o in FDIDB.Customers


                        where o.IsDelete == false && o.IsActive == true && o.HistoryAwards.Any(m => m.IsRank == isrank && m.IsPublish == isPulish)
                        orderby o.ID descending
                        select new CustomerItem
                        {
                            ID = o.ID,
                            FullName = o.FullName,
                            UserName = o.UserName,
                            CodeDL = o.ProvincialAgency.Code,
                            HistoryAwardItem = o.HistoryAwards.Where(m => m.IsRank == isrank && m.IsPublish == isPulish).Select(m => new HistoryAwardItem
                                                                         {
                                                                             PricePV = m.PricePV,
                                                                             DateCreated = m.DateCreated,
                                                                             CheckAwardkId = m.CheckAwardkId
                                                                         }),
                            TotalPricePv = o.HistoryAwards.Where(m => m.IsRank == isrank && m.IsPublish == isPulish).Sum(m => m.PricePV)
                        };
            var key = httpRequest.QueryString["KeywordAward"];
            if (!string.IsNullOrEmpty(key))
                try
                {
                    int checkid = Convert.ToInt16(key);
                    query = query.Where(o => o.HistoryAwardItem.Any(m => m.CheckAwardkId == checkid)).Select(o => new CustomerItem
                                              {
                                                  ID = o.ID,
                                                  FullName = o.FullName,
                                                  UserName = o.UserName,
                                                  CodeDL = o.CodeDL,
                                                  HistoryAwardItem = o.HistoryAwardItem.Where(m => m.CheckAwardkId == checkid).Select(m => new HistoryAwardItem
                                                  {
                                                      PricePV = m.PricePV,
                                                      DateCreated = m.DateCreated,
                                                      CheckAwardkId = m.CheckAwardkId
                                                  }),
                                                  TotalPricePv = o.HistoryAwardItem.Where(m => m.CheckAwardkId == checkid).Sum(m => m.PricePV)
                                              });
                }
                catch (Exception)
                {

                }

            if (year > 0)
            {
                query = query.Where(o => o.HistoryAwardItem.Any(m => m.DateCreated.Value.Year == year)).Select(o => new CustomerItem
                {
                    ID = o.ID,
                    FullName = o.FullName,
                    UserName = o.UserName,
                    CodeDL = o.CodeDL,
                    HistoryAwardItem = o.HistoryAwardItem.Where(m => m.DateCreated.Value.Year == year).Select(m => new HistoryAwardItem
                    {
                        PricePV = m.PricePV,
                        DateCreated = m.DateCreated,
                        CheckAwardkId = m.CheckAwardkId
                    }),
                    TotalPricePv = o.HistoryAwardItem.Where(m => m.DateCreated.Value.Year == year).Sum(m => m.PricePV)
                });
                if (month > 0)
                {
                    query = query.Where(o => o.HistoryAwardItem.Any(m => m.DateCreated.Value.Month == month)).Select(o => new CustomerItem
                    {
                        ID = o.ID,
                        FullName = o.FullName,
                        UserName = o.UserName,
                        CodeDL = o.CodeDL,
                        HistoryAwardItem = o.HistoryAwardItem.Where(m => m.DateCreated.Value.Month == month).Select(m => new HistoryAwardItem
                        {
                            PricePV = m.PricePV,
                            DateCreated = m.DateCreated,
                            CheckAwardkId = m.CheckAwardkId
                        }),
                        TotalPricePv = o.HistoryAwardItem.Where(m => m.DateCreated.Value.Month == month).Sum(m => m.PricePV)
                    });
                }
            }

            total = query.Sum(m => m.TotalPricePv);
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();

        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="ltsArrID"></param>
        /// <returns></returns>
        public List<HistoryAwardItem> GetListSimpleByArrID(List<int> ltsArrID)
        {
            var query = from o in FDIDB.HistoryAwards
                        where ltsArrID.Contains(o.ID) && !o.IsDeleted.Value
                        orderby o.ID descending
                        select new HistoryAwardItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow
                        };

            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        public decimal? GetSumPVByID(int id)
        {
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
            var query = from o in FDIDB.HistoryAwards
                        where o.CustomerId == id && o.DateCreated > date
                        orderby o.ID descending
                        select new HistoryAwardItem
                        {
                            ID = o.ID,
                            PricePV = o.PricePV
                        };
            return query.Sum(m => m.PricePV);
        }

        public List<HistoryAwardItem> GetSimpleByArrID(int id, int year, int month)
        {
            var query = from o in FDIDB.HistoryAwards
                        where o.CustomerId == id && o.IsRank == true
                        orderby o.ID descending
                        select new HistoryAwardItem
                        {
                            ID = o.ID,
                            Name = o.CheckAward.Name,
                            PricePV = o.PricePV,
                            IsPublish = o.IsPublish,
                            DateCreated = o.DateCreated
                        };
            if(year>0)
            {
                query = query.Where(m => m.DateCreated.Value.Year == year);
                if(month>0)
                {
                    query = query.Where(m => m.DateCreated.Value.Month == month);
                }
            }
            return query.ToList();
        }

        public List<HistoryAwardItem> StatisticCommissionByMonth(HttpRequestBase httpRequest, out decimal? totalpv, out int? monthout, out int? yearout)
        {
            Request = new ParramRequest(httpRequest);

            var date = DateTime.Now.AddMonths(-1);
            var year = date.Year;

            var month = date.Month;

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
            var query = from o in FDIDB.Customers
                        where o.HistoryAwards.Any(m => m.DateCreated.Value.Year == year && m.IsRank == true && m.DateCreated.Value.Month == month)
                        orderby o.ID descending
                        select new HistoryAwardItem
                        {
                            ID = o.ID,
                            PricePV = o.HistoryAwards.Where(m => m.DateCreated.Value.Year == year && m.IsPublish == false && m.IsRank == true && m.DateCreated.Value.Month == month).Sum(m => m.PricePV),
                            UserCustomer = o.UserName,
                            Customer = new CustomerItem
                            {
                                FullName = o.FullName,
                                PeoplesIdentity = o.PeoplesIdentity,
                                Address = o.Address,
                                Email = o.Email,
                                TaxCode = o.TaxCode,
                                NameCompany = o.NameCompany,
                            },
                            Title = o.RankNow_BackUp.FirstOrDefault().Rank.Name,
                            CodeDL = o.ProvincialAgency.Code,
                           NameAgency = o.ProvincialAgency.Name
                        };

            //var coun1 = query.Where(s => string.IsNullOrEmpty(s.CodeDLNHH) == false);

            totalpv = query.Sum(m => m.PricePV);
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        //lay du lieu xuat execl
        public List<sp_ExeclStatisticCommissionByMonth_Result> GetListExecl(int year, int month, string CodeHH, string UserName, string Code)
        {
            return FDIDB.sp_ExeclStatisticCommissionByMonth(year, month, UserName, Code).ToList();
        }

        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="advertisingID">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public HistoryAward GetById(int advertisingID)
        {
            var query = from c in FDIDB.HistoryAwards where c.ID == advertisingID select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<HistoryAward> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.HistoryAwards where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }

        public bool CheckAward(int customerid, int checkawardid)
        {
            var dateMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var query = from c in FDIDB.HistoryAwards where c.IsDeleted == false && c.CustomerId == customerid && c.CheckAwardkId == checkawardid && c.DateCreated > dateMonth select c.ID;
            return query.Any();
        }

        public bool CheckAwardDate(int customerid, int checkawardid)
        {

            var query = from c in FDIDB.HistoryAwards where c.IsDeleted == false && c.CustomerId == customerid && c.CheckAwardkId == checkawardid select c.ID;
            return query.Any();
        }


        public bool CheckAward(int customerid, int checkawardid, int rankid)
        {
            var dateMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var query = from c in FDIDB.HistoryAwards where c.IsDeleted == false && c.CustomerId == customerid && c.CheckAwardkId == checkawardid && c.DateCreated > dateMonth select c.ID;
            return query.Any();
        }

        /// <summary>
        /// Kiểm tra bản ghi đã tồn tại hay chưa
        /// </summary>
        /// <param name="ad">Đối tượng kiểm tra</param>
        /// <returns>Trạng thái tồn tại</returns>
        public bool CheckExits(HistoryAward ad)
        {
            var query = from c in FDIDB.HistoryAwards where ((c.Name == ad.Name) && (c.ID != ad.ID)) select c;
            return query.Any();
        }

        /// <summary>
        /// Lấy về bản ghi qua tên
        /// </summary>
        /// <param name="adName">Tên bản ghi</param>
        /// <returns>Bản ghi</returns>
        public HistoryAward GetByName(string adName)
        {
            var query = from c in FDIDB.HistoryAwards where ((c.Name == adName)) select c;
            return query.FirstOrDefault();
        }



        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="checkAward">bản ghi cần thêm</param>
        public void Add(HistoryAward checkAward)
        {
            FDIDB.HistoryAwards.Add(checkAward);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="checkAward">Xóa bản ghi</param>
        public void Delete(HistoryAward checkAward)
        {
            FDIDB.HistoryAwards.Remove(checkAward);
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
