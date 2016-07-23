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
                var query = from c in FDIDB.sp_Record()
                            select new RecordItem
                    {
                        CardNumber = c.CardNumber,
                        Date = c.Date?? new DateTime(),
                        Value = c.Value??0,
                        Balance = c.Balance??0,
                        Action = c.Action,
                        AccountName = c.AccountName,
                        CardType = c.CardType,
                        Buiding = c.Buiding,
                        Area = c.Area,
                        UserName = c.UserName,
                        EventId = c.EventID,
                        ProductCode = c.ProductCode
                    };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public List<BCKhuVucItem> GetBcKhuVucItems()
        {
            try
            {
                var query = from c in FDIDB.sp_BCTheoKhuVuc()
                            select new BCKhuVucItem
                            {
                                Area = c.Area,
                                CountValue = c.CountValue ?? 0
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
