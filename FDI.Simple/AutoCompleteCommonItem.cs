using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDI.Simple
{
    public class AutoCompleteCommonItem
    {
        public string query { get; set; }
        public List<SuggestionsItem> suggestions { get; set; }
        public List<string> Sussgestions { get; set; }
    }
}
