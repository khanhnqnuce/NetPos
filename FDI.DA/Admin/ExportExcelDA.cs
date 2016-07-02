using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.DA.Admin
{
    public class ExportExcelDA:BaseDA
    {
        #region Constructer
        public ExportExcelDA()
        {
        }

        public ExportExcelDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public ExportExcelDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion
    }
}
