using FDI.Base;
using FDI.Simple;
using FDI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.SqlClient;

namespace FDI.DA
{
    public partial class BaseDA : FDI.BaseDA
    {
        public BaseDA()
        {
        }

        protected FDIEntities _FDIdb = new FDIEntities();
        public FDIEntities FDIDB
        {
            get
            {
                return _FDIdb;
            }
        }

        public string LanguageId
        {
            get
            {
                var obj = HttpContext.Current.Request.Cookies["AdminLanguageId"];
                return obj == null ? "vi" : obj.Value;
            }
        }

        //Implement dispose to free resources
        protected override void Dispose(bool disposedStatus)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                _FDIdb.Dispose(); // Released unmanaged Resources
                if (disposedStatus)
                {
                    // Released managed Resources
                }
            }
        }

        
    }
}
