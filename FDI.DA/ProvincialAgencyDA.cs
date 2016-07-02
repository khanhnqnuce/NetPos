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
    public class ProvincialAgencyDA : BaseDA
    {
        #region Constructer
        public ProvincialAgencyDA()
        {
        }

        public ProvincialAgencyDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public ProvincialAgencyDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public List<ProvincialAgencyItem> GetAllListSimple()
        {
            var query = from c in FDIDB.ProvincialAgencies
                        where c.IsDeleted == false
                        orderby c.OrderBy
                        select new ProvincialAgencyItem
                        {
                            ID = c.ID,
                            Name = c.Name
                        };
            return query.ToList();
        }

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <param name="isShow">Kiểm tra hiển thị</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<ProvincialAgencyItem> GetListSimpleAll(bool isShow)
        {
            var query = from c in FDIDB.ProvincialAgencies
                        where c.IsShow == isShow && c.IsDeleted == false
                        orderby c.OrderBy 
                        select new ProvincialAgencyItem
                        {
                            ID = c.ID,
                            Name = c.Name,
							FullName = c.Code + " : " + c.Name
                        };
            return query.ToList();
        }

        public ProvincialAgenciesItem GetItemByName(string name)
        {
            var query = from o in FDIDB.ProvincialAgencies
                        where o.UserName == name && !o.IsDeleted.Value
                        select new ProvincialAgenciesItem
                        {
                            ID=o.ID,
                            Name=o.Name,
                            UserName=o.UserName,
                            Code=o.Code,
                        };
            return query.FirstOrDefault();
        }

        public List<ProvincialAgencyItem> Getlistsimple(bool isshow)
        {
            var query = from c in FDIDB.ProvincialAgencies
                        orderby c.Name
                        select new ProvincialAgencyItem
                        {
                            ID = c.ID,
                            Name = c.Name,
                        };
            return query.ToList();
        }

        public ProvincialAgencyItem GetSimpleByCode(string code)
        {
            var query = from o in FDIDB.ProvincialAgencies
                        where o.Code == code && !o.IsDeleted.Value
                        orderby o.ID descending
                        select new ProvincialAgencyItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow,
                            Mobile = o.Mobile,
                        };
            return query.FirstOrDefault();
        }

        public string GetCode()
        {
            const int maxCodeLength = 3;
            int countProduct = FDIDB.ProvincialAgencies.Count();
            string newCode = "";
            int nextNumber = countProduct + 1;
            for (int i = 0; i < maxCodeLength - countProduct.ToString().Length; i++)
            {
                newCode += "0";
            }
            return string.Concat(newCode, nextNumber.ToString());

        }

        public List<ProvincialAgencyItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);

            var query = from o in FDIDB.ProvincialAgencies
                        where o.IsDeleted == false
                        select new ProvincialAgencyItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow,
                            Code = o.Code,
                            Email = o.Email,
                            Mobile = o.Mobile,
                            Fax = o.Fax
                        };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.OrderBy(m=>m.Code).ToList();

        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="ltsArrID"></param>
        /// <returns></returns>
        public List<ProvincialAgencyItem> GetListSimpleByArrID(List<int> ltsArrID)
        {
            var query = from o in FDIDB.ProvincialAgencies
                        where ltsArrID.Contains(o.ID) && !o.IsDeleted.Value
                        orderby o.ID descending
                        select new ProvincialAgencyItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow
                        };

            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        public ProvincialAgencyItem GetSimpleByArrID(int id)
        {
            var query = from o in FDIDB.ProvincialAgencies
                        where o.ID == id && !o.IsDeleted.Value
                        orderby o.ID descending
                        select new ProvincialAgencyItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow,
                            //Description = o.Description
                        };
            return query.FirstOrDefault();
        }


        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public ProvincialAgency GetById(int id)
        {
            var query = from c in FDIDB.ProvincialAgencies where c.ID == id select c;
            return query.FirstOrDefault();
        }

        public bool CheckExitsUserName(string username, int id)
        {
            var queryc = (from c in FDIDB.Customers where c.UserName.ToLower().Equals(username.ToLower()) select c.ID).FirstOrDefault();

            var query = from c in FDIDB.ProvincialAgencies where c.CustomerId == queryc && c.ID != id select c;
            return query.Any();
        }
        
        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<ProvincialAgency> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.ProvincialAgencies where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }


        /// <summary>
        /// Kiểm tra bản ghi đã tồn tại hay chưa
        /// </summary>
        /// <param name="ad">Đối tượng kiểm tra</param>
        /// <returns>Trạng thái tồn tại</returns>
        public bool CheckExits(ProvincialAgency ad)
        {
            var query = from c in FDIDB.ProvincialAgencies where (c.ID != ad.ID) select c;
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
        /// <param name="provincialAgency">bản ghi cần thêm</param>
		public void Add(ProvincialAgency provincialAgency)
        {
            FDIDB.ProvincialAgencies.Add(provincialAgency);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="provincialAgency">Xóa bản ghi</param>

        public void Delete(ProvincialAgency provincialAgency)
        {
            FDIDB.ProvincialAgencies.Remove(provincialAgency);
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
