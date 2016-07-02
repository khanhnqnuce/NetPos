using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDI.Base;

namespace FDI.DA.Admin
{
    public class LogSendSMSToCustomerDA : BaseDA
    {
        #region Constructer
        public LogSendSMSToCustomerDA()
        {

        }

        public LogSendSMSToCustomerDA(string pathPaging)
        {
            this.PathPaging = pathPaging;

        }

        public LogSendSMSToCustomerDA(string pathPaging, string pathPagingExt)
        {
            this.PathPaging = pathPaging;
            this.PathPagingext = pathPagingExt;

        }
        #endregion

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="objLogSendSMSToCustomer">bản ghi cần thêm</param>
        public bool Add(LogSendSMSToCustomer objLogSendSMSToCustomer)
        {
            try
            {
                FDIDB.LogSendSMSToCustomers.Add(objLogSendSMSToCustomer);
                FDIDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

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
