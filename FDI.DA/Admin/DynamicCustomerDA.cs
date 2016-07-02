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
    public class DynamicCustomerDA : BaseDA
    {
        #region Constructer
        public DynamicCustomerDA()
        {
        }

        public DynamicCustomerDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public DynamicCustomerDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public List<DynamicCustomerItem> GetAllListSimple()
        {
            var query = from c in FDIDB.DynamicCustomers
                        where c.IsDeleted == false
                        orderby c.ID
                        select new DynamicCustomerItem
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
        public List<DynamicCustomerItem> GetListSimpleAll(bool isShow)
        {
            var query = from c in FDIDB.DynamicCustomers
                        where c.IsShow == isShow && c.IsDeleted == false
                        orderby c.ID descending
                        select new DynamicCustomerItem
                        {
                            ID = c.ID,
                            Name = c.Name
                        };
            return query.ToList();
        }


        public List<DynamicCustomerItem> Getlistsimple(bool isshow)
        {
            var query = from c in FDIDB.DynamicCustomers
                        //orderby c.Name
                        select new DynamicCustomerItem
                        {
                            ID = c.ID,
                            //Name = c.Name,
                        };
            return query.ToList();
        }


        public List<DynamicCustomerItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);
            var datetime = DateTime.Now;
            var query = from o in FDIDB.Customers
                        where o.IsDelete == false && o.IsActive == true && (datetime.Year - o.CreatedOnUtc.Value.Year) * 12 + (datetime.Month - o.CreatedOnUtc.Value.Month) < 7 && (datetime.Year - o.CreatedOnUtc.Value.Year) * 12 + (datetime.Month - o.CreatedOnUtc.Value.Month) < o.Custome_RankCustomer.Where(m => m.PricePV > 0).Sum(m => m.PricePV)/200
                        select new DynamicCustomerItem
                        {
                            ID = o.ID,
                            Name = o.UserName,
                            PricePV = (datetime.Year - o.CreatedOnUtc.Value.Year) * 12 + (datetime.Month - o.CreatedOnUtc.Value.Month) * 200 - o.Custome_RankCustomer.Where(m => m.PricePV > 0).Sum(m => m.PricePV)
                        };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();

        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="ltsArrID"></param>
        /// <returns></returns>
        public List<DynamicCustomerItem> GetListSimpleByArrID(List<int> ltsArrID)
        {
            var query = from o in FDIDB.DynamicCustomers
                        where ltsArrID.Contains(o.ID) && !o.IsDeleted.Value
                        orderby o.ID descending
                        select new DynamicCustomerItem
                        {
                            ID = o.ID,
                            //Name = o.Name,
                            IsShow = o.IsShow
                        };

            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        public DynamicCustomerItem GetSimpleByArrID(int id)
        {
            var query = from o in FDIDB.DynamicCustomers
                        where o.ID == id && !o.IsDeleted.Value
                        orderby o.ID descending
                        select new DynamicCustomerItem
                        {
                            ID = o.ID,
                            //Name = o.Name,
                            IsShow = o.IsShow,
                            Price = o.Price,
                            PricePV = o.PricePV,
                        };
            return query.FirstOrDefault();
        }


        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="advertisingID">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public DynamicCustomer GetById(int advertisingID)
        {
            var query = from c in FDIDB.DynamicCustomers where c.ID == advertisingID select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<DynamicCustomer> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.DynamicCustomers where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }


        /// <summary>
        /// Kiểm tra bản ghi đã tồn tại hay chưa
        /// </summary>
        /// <param name="ad">Đối tượng kiểm tra</param>
        /// <returns>Trạng thái tồn tại</returns>
        public bool CheckExits(DynamicCustomer ad)
        {
            var query = from c in FDIDB.DynamicCustomers where (c.ID != ad.ID) select c;
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
        /// <param name="dynamicCustomer">bản ghi cần thêm</param>
        public void Add(DynamicCustomer dynamicCustomer)
        {
            FDIDB.DynamicCustomers.Add(dynamicCustomer);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="dynamicCustomer">Xóa bản ghi</param>
        public void Delete(DynamicCustomer dynamicCustomer)
        {
            FDIDB.DynamicCustomers.Remove(dynamicCustomer);
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
