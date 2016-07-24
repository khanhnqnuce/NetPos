using System.Windows.Forms;

namespace NetPos.FrmCtrl
{
    public partial class BaseControl : UserControl
    {
        protected readonly object LockTotal = new object();
        public delegate void CustomHandler(object sender, string msg);
        public event CustomHandler ShowDialog = null;
        protected virtual void OnShowDialog(string msg)
        {
            var handler = ShowDialog;
            if (handler != null) handler(this, msg);
        }

        public delegate void CustomHandler1(object sender);
        public event CustomHandler1 CloseDialog = null;
        protected virtual void OnCloseDialog()
        {
            var handler = CloseDialog;
            if (handler != null) handler(this);
        }

        public delegate void CustomHandler2(object sender, string msg);
        public event CustomHandler2 UpdateDialog = null;
        protected virtual void OnUpdateDialog(string msg)
        {
            var handler = UpdateDialog;
            if (handler != null) handler(this, msg);
        }
        
    }
}
