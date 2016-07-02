using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FDI.Base;
using FDI.DA;
using FDI.DA.Admin;
using FDI.Simple;

namespace FDI.DA.Admin
{
    public partial class Customer_PaymentMethodDA : BaseDA
    {
        #region Constructer
        public Customer_PaymentMethodDA()
        {
        }

        public Customer_PaymentMethodDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public Customer_PaymentMethodDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy toàn bộ danh sách bảng ghi
        /// </summary>
        /// <returns></returns>
        public List<Payment_Method> GetAllList()
        {
            var query = from c in FDIDB.Payment_Method orderby c.Name ascending select c;
            return query.ToList();
        }

        /// <summary>
        /// Lấy về kiểu đơn giản, phân trang
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public List<CustomerPaymentMethodItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);
            var query = from t in FDIDB.Payment_Method
                        select new CustomerPaymentMethodItem
                                   {
                                       ID = t.ID,
                                       Name = t.Name,
                                       Descripton = t.Description
                                   };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<Payment_Method> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.Payment_Method where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }


        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="paymentID">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public Payment_Method GetById(int paymentID)
        {
            var query = from c in FDIDB.Payment_Method where c.ID == paymentID select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="paymentID">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public CustomerPaymentMethodItem GetPaymentMethodItemById(int paymentID)
        {
            var query = from c in FDIDB.Payment_Method
                        where c.ID == paymentID
                        select new CustomerPaymentMethodItem
                                   {
                                       ID = c.ID,
                                       Name = c.Name,
                                       Descripton = c.Description
                                   };
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="paymentMethod"> </param>
        public void Add(Payment_Method paymentMethod)
        {
            FDIDB.Payment_Method.Add(paymentMethod);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="paymentMethod"> </param>
        public void Delete(Payment_Method paymentMethod)
        {
            FDIDB.Payment_Method.Remove(paymentMethod);
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
