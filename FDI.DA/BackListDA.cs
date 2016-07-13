using System;
using System.Collections.Generic;
using System.Linq;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public class BackListDA : BaseDA
    {
        public List<BackListItem> GetAdminAllSimple()
        {
            try
            {
                var query = from c in FDIDB.tblBlackLists
                            select new BackListItem
                            {
                                Date = c.Date??new DateTime(),
                                MemoryID = c.MemoryID,
                                CardNumber = c.CardNumber,
                                ToObjects = c.ToObjects,
                                IsInActive = c.IsInActive,
                                Desc = c.Desc
                            };

                return query.ToList();
            }
            catch (Exception)
            {
                return new List<BackListItem>();
            }

        }

    }
}
