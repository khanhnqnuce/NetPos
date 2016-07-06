using FDI.Base;

namespace FDI.DA
{
    public partial class BaseDA : FDI.BaseDA
    {
        protected FDIEntities _FDIdb = new FDIEntities();
        public FDIEntities FDIDB
        {
            get
            {
                return _FDIdb;
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
