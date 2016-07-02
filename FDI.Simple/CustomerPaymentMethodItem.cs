using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    [Serializable]
    public class CustomerPaymentMethodItem : BaseSimple
    {
        public string Name { get; set; }
        public string Descripton { get; set; }
    }
}
