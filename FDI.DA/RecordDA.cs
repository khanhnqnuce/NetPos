using System;
using System.Collections.Generic;
using System.Linq;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public partial class RecordDA : BaseDA
    {
        public List<RecordItem> GetAdminAllSimple()
        {
            try
            {
                var query = from c in FDIDB.tblRecords
                            select new RecordItem
                    {
                        CardNumber = c.CardNumber,
                        Date = (DateTime) c.Date,
                        Bonus = (int) c.Bonus,
                        Balance = (int) c.Balance,
                        Action = c.Action,
                        CardTypeCode = c.CardTypeCode,
                        BuidingCode = c.BuidingCode,
                        AreaCode = c.AreaCode,
                        UserCode = c.UserCode,
                        EventID = c.EventID,
                        ProductCode = c.ProductCode
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
