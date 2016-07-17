using System;
using System;
using System.Collections.Generic;
using System.Linq;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public partial class ThongKeTheDA : BaseDA
    {
        public List<ThongKeTheItem> GetAdminAllSimple()
        {
            try
            {
                var query = from c in FDIDB.sp_ThongKeThe()
                            select new ThongKeTheItem
                    {
                        NameType = c.NameType,
                        TotalCard = c.TotalCard ?? 0,
                        TotalUsed = c.TotalUsed ?? 0,
                        TotalNotUsed = c.TotalNotUsed ?? 0,
                        TotalBalance = c.TotalBalance ?? 0
                    };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
