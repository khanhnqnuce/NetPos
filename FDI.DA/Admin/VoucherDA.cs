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
    public class VoucherDA : BaseDA
    {
        #region Constructer
        public VoucherDA()
        {
        }

        public VoucherDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public VoucherDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public List<VoucherItem> GetListSimpleAll()
        {
            var query = from c in FDIDB.Vouchers
                        orderby c.Name
                        select new VoucherItem
                                   {
                                       ID = c.ID,
                                       Name = c.Name.Trim()
                                   };
            return query.ToList();
        }

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <param name="isShow">Kiểm tra hiển thị</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<VoucherItem> GetListSimpleAll(bool isShow)
        {
            var query = from c in FDIDB.Vouchers
                        where (c.IsShow == isShow)
                        orderby c.Name
                        select new VoucherItem
                                   {
                                       ID = c.ID,
                                       Name = c.Name.Trim()
                                   };
            return query.ToList();
        }

        //#region tạo số đơn hàng
        //public string GetCodeVoucher()
        //{
        //    const int maxCodeLength = 6;
        //    int countProduct = FDIDB.Vouchers.Count();
        //    string newCode = "";
        //    int nextNumber = countProduct + 1;
        //    for (int i = 0; i < maxCodeLength - countProduct.ToString().Length; i++)
        //    {
        //        newCode += "0";
        //    }
        //    return string.Concat(newCode, nextNumber.ToString());

        //}
        //#endregion

        /// <summary>
        /// Lấy về dưới dạng Autocomplete
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="showLimit"></param>
        /// <returns></returns>
        public List<VoucherItem> GetListSimpleByAutoComplete(string keyword, int showLimit)
        {
            var query = from c in FDIDB.Vouchers
                        orderby c.Name
                        where c.Code.StartsWith(keyword)
                        select new VoucherItem
                                   {
                                       ID = c.ID,
                                       Code = c.Code.Trim()
                                   };
            return query.Take(showLimit).ToList();
        }

        /// <summary>
        /// Lấy về dưới dạng Autocomplete
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="showLimit"></param>
        /// <param name="isShow"> </param>
        /// <returns></returns>
        public List<VoucherItem> GetListSimpleByAutoComplete(string keyword, int showLimit, bool isShow)
        {
            var query = from c in FDIDB.Vouchers
                        orderby c.Name
                        where c.IsShow == isShow
                        && c.Name.StartsWith(keyword)
                        select new VoucherItem
                                   {
                                       ID = c.ID,
                                       Name = c.Name.Trim()
                                   };
            return query.Take(showLimit).ToList();
        }

        /// <summary>
        /// Lấy về kiểu đơn giản, phân trang
        /// </summary>
        /// <param name="httpRequest"> </param>
        /// <returns>Danh sách bản ghi</returns>
        public List<VoucherItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);
            var query = from o in FDIDB.Vouchers 
                        select new VoucherItem
                                   {
                                       ID = o.ID,
                                       Name = o.Name.Trim(),
                                       Code = o.Code,
                                       CustomerUserName = o.CustomerUserName,
                                       ExpirationDate = o.ExpirationDate,
                                       //TotalCount = o.TotalCount,
                                       IsShow = o.IsShow
                                   };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

     

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="ltsArrID"></param>
        /// <returns></returns>
        public List<VoucherItem> GetListSimpleByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.System_Config
                        where ltsArrID.Contains(c.ID)
                        orderby c.ID descending
                        select new VoucherItem
                                   {
                                       Name = c.Name,
                                   };
            TotalRecord = query.Count();
            return query.ToList();
        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VoucherItem GetSystemConfigItemById(int id)
        {
            var query = from c in FDIDB.Vouchers
                        where c.ID == id
                        orderby c.ID descending
                        select new VoucherItem
                                   {
                                       Name = c.Name,
                                       Code = c.Code
                                   };
            return query.FirstOrDefault();
        }



        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public Voucher GetById(int id)
        {
            var query = from c in FDIDB.Vouchers where c.ID == id select c;
            return query.FirstOrDefault();
        }


        public Voucher GetByCode(string code)
        {
            var query = from c in FDIDB.Vouchers where c.Code.ToLower() == code.ToLower()&& c.IsShow == true select c;
            return query.FirstOrDefault();
        }
        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<Voucher> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.Vouchers where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }

        /// <summary>
        /// Kiểm tra bản ghi đã tồn tại hay chưa
        /// </summary>
        /// <param name="voucher">Đối tượng kiểm tra</param>
        /// <returns>Trạng thái tồn tại</returns>
        public bool CheckExits(Voucher voucher)
        {
            var query = from c in FDIDB.Vouchers where ((c.Name == voucher.Name) && (c.ID != voucher.ID)) select c;
            return query.Any();
        }

        /// <summary>
        /// Lấy về bản ghi qua tên
        /// </summary>
        /// <param name="name">Tên bản ghi</param>
        /// <returns>Bản ghi</returns>
        public Voucher GetByName(string name)
        {
            var query = from c in FDIDB.Vouchers where ((c.Name == name)) select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="voucher"> bản ghi cần thêm</param>
        public void Add(Voucher voucher)
        {
            FDIDB.Vouchers.Add(voucher);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="systemConfig">Xóa bản ghi</param>
        public void Delete(Voucher voucher)
        {
            FDIDB.Vouchers.Remove(voucher);
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
