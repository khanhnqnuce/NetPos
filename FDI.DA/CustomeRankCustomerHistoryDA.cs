using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public class CustomeRankCustomerHistoryDA : BaseDA
    {
        #region Constructer
        public CustomeRankCustomerHistoryDA()
        {
        }

        public CustomeRankCustomerHistoryDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public CustomeRankCustomerHistoryDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public List<CustomeRankCustomerItem> GetAllListSimple(int mont, int year)
        {
            var query = from c in FDIDB.Custome_RankCustomer
                        where c.IsDeleted == false && c.DateCreated.Value.Month == mont && c.DateCreated.Value.Year == year && c.PricePV > 0
                        select new CustomeRankCustomerItem
                        {
                            ID = c.ID,
                            CustomerId = c.CustomerId,
                            DateCreated = c.DateCreated,
                            PricePV = c.PricePV
                        };
            return query.ToList();
        }

        public CustomerItem GetCustomerByUserName(string name)
        {
            var query = from c in FDIDB.Customers
                        where c.UserName.ToLower().Equals(name.ToLower())
                        select new CustomerItem
                        {
                            ID = c.ID,
                            UserName = c.UserName,
                            Mobile = c.Mobile,
                            CustomerID = c.CustomerID,
                            ParentID = c.ParentID,
                            IsActive = c.IsActive,
                            RankUser = c.RankNows.FirstOrDefault() != null ? c.RankNows.FirstOrDefault().Rank.Name : null,
                            LevelId = c.RankNows.FirstOrDefault().Level,
                            ListCustomerId = c.ListCustomerId,
                            TotalPricePv = c.Custome_RankCustomer.Sum(p => p.PricePV).HasValue ? c.Custome_RankCustomer.Sum(p => p.PricePV).Value : 0,
                            NameCustomerID = (from u in FDIDB.Customers
                                              where u.ID == c.CustomerID && u.IsPublish == false && c.IsActive == true && c.IsDelete == false
                                              select c.UserName
                                                                                                         ).FirstOrDefault()
                        };
            return query.FirstOrDefault();
        }

        public CustomerItem GetCustomerById(int id)
        {
            var query = from c in FDIDB.Customers
                        where c.ID == id
                        select new CustomerItem
                        {
                            ID = c.ID,
                            UserName = c.UserName,
                            Mobile = c.Mobile,
                            CustomerID = c.CustomerID,
                            ParentID = c.ParentID,
                            IsActive = c.IsActive,
                            RankUser = c.RankNows.FirstOrDefault() != null ? c.RankNows.FirstOrDefault().Rank.Name : null,
                            LevelId = c.RankNows.FirstOrDefault().Level,
                            ListCustomerId = c.ListCustomerId,
                            TotalPricePv = c.Custome_RankCustomer.Sum(p => p.PricePV).HasValue ? c.Custome_RankCustomer.Sum(p => p.PricePV).Value : 0,
                            NameCustomerID = (from u in FDIDB.Customers
                                              where u.ID == c.CustomerID && u.IsPublish == false && c.IsActive == true && c.IsDelete == false
                                              select c.UserName
                                                                                                         ).FirstOrDefault()
                        };
            return query.FirstOrDefault();
        }


        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <param name="isShow">Kiểm tra hiển thị</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<CustomeRankCustomerItem> GetListSimpleAll(bool isShow)
        {
            var query = from c in FDIDB.Custome_RankCustomer
                        where c.IsShow == isShow && c.IsDeleted == false
                        orderby c.ID descending
                        select new CustomeRankCustomerItem
                        {
                            ID = c.ID,
                            //Name = c.Name
                        };
            return query.ToList();
        }

        public List<CustomeRankCustomerItem> StatisticByRank(HttpRequestBase httpRequest, out decimal? totalpv, out int? monthout, out int? yearout)
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
            var query = from o in FDIDB.RankCustomes
                        where o.Custome_RankCustomer.Any(m => m.DateCreated.Value.Year == year && m.DateCreated.Value.Month == month)
                        orderby o.PricePV
                        select new CustomeRankCustomerItem
                        {
                            ID = o.ID,
                            CustomerId = 0,
                            PricePV = o.Custome_RankCustomer.Where(m => m.DateCreated.Value.Year == year && m.DateCreated.Value.Month == month).Sum(m => m.PricePV),
                            Name = o.Name,
                            TotelCustomerID = o.Custome_RankCustomer.Count(m => m.DateCreated.Value.Year == year && m.DateCreated.Value.Month == month)

                        };

            totalpv = query.Sum(m => m.PricePV);
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        public List<CustomeRankCustomerItem> GetListAgencyReports(HttpRequestBase httpRequest, out decimal? total, out int? monthout, out int? yearout)
        {
            Request = new ParramRequest(httpRequest);

            var year = DateTime.Now.Year;

            var month = DateTime.Now.Month - 1;

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

            var query = from c in FDIDB.ProvincialAgencies
                        where c.Custome_RankCustomer.Any(m => m.DateCreated.HasValue && m.DateCreated.Value.Month == month && m.DateCreated.Value.Year == year)
                        orderby c.ID
                        select new CustomeRankCustomerItem
                        {
                            ID = c.ID,
                            CustomerId = c.CustomerId,
                            ProvincialAgenciesName = c.Name,
                            ProvincialAgenciesCode = c.Code,
                            PricePV = c.Custome_RankCustomer.Where(m => m.DateCreated.HasValue && m.DateCreated.Value.Month == month && m.DateCreated.Value.Year == year).Sum(m => m.PricePV),

                        };
            if (!string.IsNullOrEmpty(httpRequest.QueryString["ProvincialAgenciesCode"]))
            {
                var provincialAgenciesCode = httpRequest.QueryString["ProvincialAgenciesCode"];
                query = query.Where(m => m.ProvincialAgenciesCode == provincialAgenciesCode);
            }
            total = query.Sum(m => m.PricePV);
            query = query.SelectByRequest(Request, ref TotalRecord);
            //total = TotalRecord;
            //query = query.Where(m => m.PricePV > 0);            
            return query.ToList();
        }

        public List<CustomeRankCustomerItem> GetListAgencyReportsByYear(HttpRequestBase httpRequest, out decimal? total, out int? yearout, int month)
        {
            Request = new ParramRequest(httpRequest);

            var year = DateTime.Now.Year;

            //var month = DateTime.Now.Month - 1;

            if (!string.IsNullOrEmpty(httpRequest.QueryString["Year"]))
            {
                year = Convert.ToInt32(httpRequest.QueryString["Year"]);

            }

            //if (!string.IsNullOrEmpty(httpRequest.QueryString["Month"]))
            //{
            //    month = Convert.ToInt32(httpRequest.QueryString["Month"]);

            //}
            yearout = year;           

            var query = from c in FDIDB.ProvincialAgencies                           
                        where c.Custome_RankCustomer.Any(m => m.DateCreated.HasValue && m.DateCreated.Value.Month==month  && m.DateCreated.Value.Year == year)                         
                        orderby c.ID
                        select new CustomeRankCustomerItem
                        {
                            ProvincialAgenciesName = c.Name,
                            ProvincialAgenciesCode = c.Code,
                            DateCreated=c.DateCreated,
                            Month=month,
                            PricePV = c.Custome_RankCustomer.Where(m => m.DateCreated.HasValue && m.DateCreated.Value.Month==month && m.DateCreated.Value.Year == year).Sum(m => m.PricePV),

                        };
            if (!string.IsNullOrEmpty(httpRequest.QueryString["ProvincialAgenciesCode"]))
            {
                var provincialAgenciesCode = httpRequest.QueryString["ProvincialAgenciesCode"];
                query = query.Where(m => m.ProvincialAgenciesCode == provincialAgenciesCode);
            }
            query = query.Where(m => m.PricePV > 0);
            total = query.Sum(m => m.PricePV);
            //totalmonth = new decimal?[12];
            //for (int i = 0; i < 12; i++)
            //{
            //    totalmonth[i] = query.Where(m=>m.DateCreated.Value.Month==i+1).Sum(m => m.PricePV);
            //}
            return query.ToList();
        }

        //lay pv dai ly
        public List<ProvincialAgenciesItem> GetProvincialAgenciesItems( int id)
        {
            var query = from c in FDIDB.ProvincialAgencies
                        select new ProvincialAgenciesItem
                                   {
                            Name = c.Name,
                            Code = c.Code,
                            DateCreated = c.DateCreated,
                            TotalPV = c.Custome_RankCustomer.Where(m=>m.ProvincialAgencyID==id).Sum(m => m.PricePV),

                        };
            return query.ToList();
        }
        public CustomeRankCustomerItem GetListAgencyReportsCustomerId(HttpRequestBase httpRequest, int customerID, out decimal? total,  int monthout,  int yearout)
        {
            Request = new ParramRequest(httpRequest);
            var date = DateTime.Now.AddMonths(-1);
            var year = date.Year;

            var month = date.Month;

            //if (!string.IsNullOrEmpty(httpRequest.QueryString["Year"]))
            //{
            //    year = Convert.ToInt32(httpRequest.QueryString["Year"]);

            //}

            //if (!string.IsNullOrEmpty(httpRequest.QueryString["Month"]))
            //{
            //    month = Convert.ToInt32(httpRequest.QueryString["Month"]);

            //}
          year=  yearout ;
          month=  monthout ;

            var query = from c in FDIDB.ProvincialAgencies
                        where c.Custome_RankCustomer.Any(m =>m.Customer.ProvincialAgencyID==customerID && m.DateCreated.HasValue && m.DateCreated.Value.Month == month && m.DateCreated.Value.Year == year)
                        orderby c.ID
                        select new CustomeRankCustomerItem
                        {
                            CustomerId = c.CustomerId,
                            ProvincialAgenciesName = c.Name,
                            ProvincialAgenciesCode = c.Code,
                            PricePV = c.Custome_RankCustomer.Where(m => m.ProvincialAgencyID==customerID && m.DateCreated.HasValue && m.DateCreated.Value.Month == month && m.DateCreated.Value.Year == year).Sum(m => m.PricePV),

                        };


            total = query.Sum(m => m.PricePV);
            return query.Where(m => m.PricePV > 0).FirstOrDefault();
        }

        public List<CustomeRankCustomerItem> StatisticCommissionByRank(HttpRequestBase httpRequest, out decimal? total, out int? monthout, out int? yearout)
        {
            Request = new ParramRequest(httpRequest);

            var year = DateTime.Now.Year;

            var month = DateTime.Now.Month - 1;

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
            var query = from c in FDIDB.ProvincialAgencies
                        where c.Custome_RankCustomer.Any(m => m.DateCreated.HasValue && m.DateCreated.Value.Month == month && m.DateCreated.Value.Year == year)
                        orderby c.ID
                        select new CustomeRankCustomerItem
                        {
                            ProvincialAgenciesName = c.Name,
                            ProvincialAgenciesCode = c.Code,
                            PricePV = c.Custome_RankCustomer.Where(m => m.DateCreated.HasValue && m.DateCreated.Value.Month == month && m.DateCreated.Value.Year == year).Sum(m => m.PricePV),

                        };
            if (!string.IsNullOrEmpty(httpRequest.QueryString["ProvincialAgenciesCode"]))
            {
                var provincialAgenciesCode = httpRequest.QueryString["ProvincialAgenciesCode"];
                query = query.Where(m => m.ProvincialAgenciesCode == provincialAgenciesCode);
            }

            total = query.Sum(m => m.PricePV);
            return query.Where(m => m.PricePV > 0).ToList();
        }

        public List<CustomeRankCustomerItem> StatisticCommissionByMonthex(HttpRequestBase httpRequest, out decimal? total, out int? monthout, out int? yearout)
        {
            Request = new ParramRequest(httpRequest);

            var year = DateTime.Now.Year;

            var month = DateTime.Now.Month - 1;

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
            var query = from c in FDIDB.ProvincialAgencies
                        where c.Custome_RankCustomer.Any(m => m.DateCreated.HasValue && m.DateCreated.Value.Month == month && m.DateCreated.Value.Year == year)
                        orderby c.ID
                        select new CustomeRankCustomerItem
                        {
                            ProvincialAgenciesName = c.Name,
                            ProvincialAgenciesCode = c.Code,
                            PricePV = c.Custome_RankCustomer.Where(m => m.DateCreated.HasValue && m.DateCreated.Value.Month == month && m.DateCreated.Value.Year == year).Sum(m => m.PricePV),

                        };
            if (!string.IsNullOrEmpty(httpRequest.QueryString["ProvincialAgenciesCode"]))
            {
                var provincialAgenciesCode = httpRequest.QueryString["ProvincialAgenciesCode"];
                query = query.Where(m => m.ProvincialAgenciesCode == provincialAgenciesCode);
            }

            total = query.Sum(m => m.PricePV);
            return query.Where(m => m.PricePV > 0).ToList();
        }


        public void DeleteAwardByRankId(int id)
        {
            FDIDB.DeleteAwardsByRankID(id);
        }

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <param name="isShow">Kiểm tra hiển thị</param>
        /// <returns>Danh sách bản ghi</returns>
        public decimal? SumTotal()
        {
            var query = from c in FDIDB.Custome_RankCustomer
                        where c.IsShow == true && c.IsDeleted == false
                        orderby c.ID descending
                        select new CustomeRankCustomerItem
                        {
                            ID = c.ID,
                            PricePV = c.PricePV
                        };
            return query.Sum(m => m.PricePV);
        }

        public bool CheckRank(int id)
        {
            var query = from c in FDIDB.Custome_RankCustomer
                        where c.CustomerId == id
                        select new CustomeRankCustomerItem
                        {
                            ID = c.ID,
                            CustomerId = c.CustomerId,
                        };
            return query.Any();
        }
        public List<CustomeRankCustomerItem> Getlistsimple(bool isshow)
        {
            var query = from c in FDIDB.Custome_RankCustomer
                        //orderby c.Name
                        select new CustomeRankCustomerItem
                        {
                            ID = c.ID,
                            //Name = c.Name,
                        };
            return query.ToList();
        }


        public List<CustomeRankCustomerItem> GetListSimpleByRequest(HttpRequestBase httpRequest, int type, out decimal? totalpv)
        {
            Request = new ParramRequest(httpRequest);
            if (type == 0)
            {
				var query = from o in FDIDB.Custome_RankCustomerHistory
                            where o.IsDeleted == false && o.IsShow == true && o.RankCustome.Type != type
                            orderby o.DateCreated descending
                            select new CustomeRankCustomerItem
                            {
                                ID = o.ID,
                                //Name = o.Name,
                                IsShow = o.IsShow,
                                Price = o.Price,
                                PricePV = o.PricePV,
                                NameCustomer = o.Customer.FullName,
                                UserCustomer = o.Customer.UserName,
                                MobileCustomer = o.Customer.Mobile,
                                ProvincialAgenciesName = o.ProvincialAgency.Name,
                                ProvincialAgenciesCode = o.ProvincialAgency.Code,
                                CustomerId = o.CustomerId,
                                DateCreated = o.DateCreated

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
	            if (string.IsNullOrEmpty(Request.FieldSort))
	            {
		            Request.FieldSort = "DateCreated";
		            Request.TypeSort = true;
	            }
	            query = query.SelectByRequest(Request, ref TotalRecord);
                totalpv = query.Sum(m => m.PricePV);
                return query.ToList();
            }
            var querynew = from o in FDIDB.Custome_RankCustomer
                           where o.IsDeleted == false && o.RankCustome.Type == type
                           orderby o.DateCreated descending
                           select new CustomeRankCustomerItem
                           {
                               ID = o.ID,
                               //Name = o.Name,
                               IsShow = o.IsShow,
                               PricePV = o.PricePV,
                               NameCustomer = o.Customer.FullName,
                               UserCustomer = o.Customer.UserName,
                               MobileCustomer = o.Customer.Mobile,
                               CustomerId = o.CustomerId,
                               DateCreated = o.DateCreated
                           };

            if (!string.IsNullOrEmpty(httpRequest.QueryString["fromCreateDate"]))
            {
                var formDate = FDI.Utils.MyDateTime.ToDate(httpRequest.QueryString["fromCreateDate"]);
                querynew = querynew.Where(c => c.DateCreated > formDate);
            }

            if (!string.IsNullOrEmpty(httpRequest.QueryString["toCreateDate"]))
            {
                var toDate = FDI.Utils.MyDateTime.ToDate(httpRequest.QueryString["toCreateDate"]).AddDays(1);
                querynew = querynew.Where(c => c.DateCreated < toDate);
            }

            querynew = querynew.SelectByRequest(Request, ref TotalRecord);
            totalpv = querynew.Sum(m => m.PricePV);
            return querynew.ToList();

        }

        public List<CustomeRankCustomerItem> GetListSimpleByRequestnew(HttpRequestBase httpRequest, int type, out decimal? totalpv)
        {
            Request = new ParramRequest(httpRequest);
            if (type == 0)
            {
                var query = from o in FDIDB.Custome_RankCustomer
                            where o.IsDeleted == false && o.IsShow == true && o.RankCustome.Type != type
                            && (o.RankCustomerId == 4 || o.RankCustomerId == 9 || o.RankCustomerId == 10 || o.RankCustomerId == 17)
                            orderby o.DateCreated descending
                            select new CustomeRankCustomerItem
                            {
                                ID = o.ID,
                                IsShow = o.IsShow,
                                PricePV = o.PricePV,
                                NameCustomer = o.Customer.FullName,
                                UserCustomer = o.Customer.UserName,
                                MobileCustomer = o.Customer.Mobile,
                                ProvincialAgenciesName = o.ProvincialAgency.Name,
                                ProvincialAgenciesCode = o.ProvincialAgency.Code,
                                CustomerId = o.CustomerId,
                                DateCreated = o.DateCreated,
                                TotalAgency = o.RankCustomerId ==17?7:1
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

                query = query.SelectByRequest(Request, ref TotalRecord);
                totalpv = query.Sum(m => m.PricePV);
                return query.ToList();
            }
            var querynew = from o in FDIDB.Custome_RankCustomer
                           where o.IsDeleted == false && o.RankCustome.Type == type
                           && (o.RankCustomerId == 4 || o.RankCustomerId == 9 || o.RankCustomerId == 10 || o.RankCustomerId == 17)
                           orderby o.DateCreated descending
                           select new CustomeRankCustomerItem
                           {
                               ID = o.ID,
                               //Name = o.Name,
                               IsShow = o.IsShow,
                               PricePV = o.PricePV,
                               NameCustomer = o.Customer.FullName,
                               UserCustomer = o.Customer.UserName,
                               MobileCustomer = o.Customer.Mobile,
                               CustomerId = o.CustomerId,
                               DateCreated = o.DateCreated,
                               TotalAgency = o.RankCustomerId ==17?7:1
                           };

            if (!string.IsNullOrEmpty(httpRequest.QueryString["fromCreateDate"]))
            {
                var formDate = FDI.Utils.MyDateTime.ToDate(httpRequest.QueryString["fromCreateDate"]);
                querynew = querynew.Where(c => c.DateCreated > formDate);
            }

            if (!string.IsNullOrEmpty(httpRequest.QueryString["toCreateDate"]))
            {
                var toDate = FDI.Utils.MyDateTime.ToDate(httpRequest.QueryString["toCreateDate"]).AddDays(1);
                querynew = querynew.Where(c => c.DateCreated < toDate);
            }

            querynew = querynew.SelectByRequest(Request, ref TotalRecord);
            totalpv = querynew.Sum(m => m.PricePV);
            return querynew.ToList();

        }

        public List<CustomeRankCustomerItem> GetListSimpleByRequestexcel(HttpRequestBase httpRequest, int type)
        {
            Request = new ParramRequest(httpRequest);
            if (type == 0)
            {
                var query = from o in FDIDB.Custome_RankCustomer
                            where o.IsDeleted == false && o.IsShow == true && o.RankCustome.Type != type
                            orderby o.DateCreated descending
                            select new CustomeRankCustomerItem
                            {
                                ID = o.ID,
                                //Name = o.Name,
                                IsShow = o.IsShow,
                                PricePV = o.PricePV,
                                NameCustomer = o.Customer.FullName,
                                UserCustomer = o.Customer.UserName,
                                MobileCustomer = o.Customer.Mobile,
                                ProvincialAgenciesName = o.ProvincialAgency.Name,
                                ProvincialAgenciesCode = o.ProvincialAgency.Code,
                                CustomerId = o.CustomerId,
                                DateCreated = o.DateCreated

                            };

                if (!string.IsNullOrEmpty(httpRequest.QueryString["fromCreateDate"]))
                {
                    var formDate = FDI.Utils.MyDateTime.ToDate  (httpRequest.QueryString["fromCreateDate"]);
                    query = query.Where(c => c.DateCreated > formDate);
                }

                if (!string.IsNullOrEmpty(httpRequest.QueryString["toCreateDate"]))
                {
                    var toDate = FDI.Utils.MyDateTime.ToDate(httpRequest.QueryString["toCreateDate"]).AddDays(1);
                    query = query.Where(c => c.DateCreated < toDate);
                }

                if (!string.IsNullOrEmpty(httpRequest.QueryString["Keyword"]))
                {
                    var keyword = httpRequest.QueryString["Keyword"];
                    if (!string.IsNullOrEmpty(httpRequest.QueryString["SearchIn"]))
                    {
                        var searchIn = httpRequest.QueryString["SearchIn"];
                        query = searchIn == "UserCustomer" ? query.Where(c => c.UserCustomer.Equals(keyword)) : query.Where(c => c.ProvincialAgenciesCode.Equals(keyword));
                    }
                }


                return query.ToList();
            }
            var querynew = from o in FDIDB.Custome_RankCustomer
                           where o.IsDeleted == false && o.RankCustome.Type == type
                           orderby o.DateCreated descending
                           select new CustomeRankCustomerItem
                           {
                               ID = o.ID,
                               //Name = o.Name,
                               IsShow = o.IsShow,
                               PricePV = o.PricePV,
                               NameCustomer = o.Customer.FullName,
                               UserCustomer = o.Customer.UserName,
                               MobileCustomer = o.Customer.Mobile,
                               CustomerId = o.CustomerId,
                               DateCreated = o.DateCreated
                           };

            if (!string.IsNullOrEmpty(httpRequest.QueryString["fromCreateDate"]))
            {
                var formDate = FDI.Utils.MyDateTime.ToDate(httpRequest.QueryString["fromCreateDate"]);
                querynew = querynew.Where(c => c.DateCreated > formDate);
            }

            if (!string.IsNullOrEmpty(httpRequest.QueryString["toCreateDate"]))
            {
                var toDate = FDI.Utils.MyDateTime.ToDate(httpRequest.QueryString["toCreateDate"]).AddDays(1);
                querynew = querynew.Where(c => c.DateCreated < toDate);
            }
            if (!string.IsNullOrEmpty(httpRequest.QueryString["Keyword"]))
            {
                var keyword = httpRequest.QueryString["Keyword"];
                if (!string.IsNullOrEmpty(httpRequest.QueryString["SearchIn"]))
                {
                    var searchIn = httpRequest.QueryString["SearchIn"];
                    querynew = searchIn == "UserCustomer" ? querynew.Where(c => c.UserCustomer.Equals(keyword)) : querynew.Where(c => c.ProvincialAgenciesCode.Equals(keyword));
                }
            }

            return querynew.ToList();

        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="ltsArrID"></param>
        /// <returns></returns>
        public List<CustomeRankCustomerItem> GetListSimpleByArrID(List<int> ltsArrID)
        {
            var query = from o in FDIDB.Custome_RankCustomer
                        where ltsArrID.Contains(o.ID) && !o.IsDeleted.Value
                        orderby o.ID descending
                        select new CustomeRankCustomerItem
                        {
                            ID = o.ID,
                            //Name = o.Name,
                            IsShow = o.IsShow
                        };

            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        public CustomeRankCustomerItem GetSimpleByArrID(int id)
        {
            var query = from o in FDIDB.Custome_RankCustomer
                        where o.ID == id && !o.IsDeleted.Value
                        orderby o.ID descending
                        select new CustomeRankCustomerItem
                        {
                            ID = o.ID,
                            //Name = o.Name,
                            IsShow = o.IsShow,
                            //Description = o.Description
                        };
            return query.FirstOrDefault();
        }


        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="advertisingID">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public Custome_RankCustomer GetById(int advertisingID)
        {
            var query = from c in FDIDB.Custome_RankCustomer where c.ID == advertisingID select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<Custome_RankCustomerHistory> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.Custome_RankCustomerHistory where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }


        /// <summary>
        /// Kiểm tra bản ghi đã tồn tại hay chưa
        /// </summary>
        /// <param name="ad">Đối tượng kiểm tra</param>
        /// <returns>Trạng thái tồn tại</returns>
        public bool CheckExits(Custome_RankCustomer ad)
        {
            var query = from c in FDIDB.HistoryAwards where (c.ID != ad.ID) select c;
            return query.Any();
        }

        public bool CheckExitsByUserZero(int cusid, int rankid)
        {
            var query = from c in FDIDB.Custome_RankCustomer where (c.CustomerId == cusid && c.RankCustomerId == rankid) select c;
            return query.Any();
        }

        ///// <summary>
        ///// Lấy về bản ghi qua tên
        ///// </summary>
        ///// <param name="adName">Tên bản ghi</param>
        ///// <returns>Bản ghi</returns>
        //public Custome_RankCustomer GetByName(string adName)
        //{
        //    var query = from c in FDIDB.Custome_RankCustomer where ((c.Name == adName)) select c;
        //    return query.FirstOrDefault();
        //}



        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="customeRankCustomer">bản ghi cần thêm</param>
        public void Add(Custome_RankCustomerHistory customeRankCustomer)
        {
            FDIDB.Custome_RankCustomerHistory.Add(customeRankCustomer);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="Custome_RankCustomer">Xóa bản ghi</param>
        public void Delete(Custome_RankCustomerHistory customeRankCustomer)
        {
           FDIDB.Custome_RankCustomerHistory.Remove(customeRankCustomer);
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
