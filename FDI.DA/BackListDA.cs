using System;
using System.Collections.Generic;
using System.Linq;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public class BackListDA : BaseDA
    {
        public List<BackListItem> GetAll()
        {
            try
            {
                var query = from c in FDIDB.tblBlackLists
                            select new BackListItem
                            {
                                Date = c.Date ?? new DateTime(),
                                MemoryID = c.MemoryID??0,
                                CardNumber = c.CardNumber,
                                ToObjects = c.ToObjects,
                                IsInActive = c.IsInActive??false,
                                Desc = c.Desc
                            };

                return query.ToList();
            }
            catch (Exception)
            {
                return new List<BackListItem>();
            }

        }

        public tblBlackList Get(string card)
        {
            var query = from c in FDIDB.tblBlackLists where  c.CardNumber == card select c;
            return query.FirstOrDefault();
        }

        public void Add(tblBlackList item)
        {
            FDIDB.tblBlackLists.Add(item);
        }

        public int Count()
        {
            return FDIDB.tblBlackLists.Count();
        }

        public void Delete(tblBlackList item)
        {
            FDIDB.tblBlackLists.Remove(item);
        }

        public void Save()
        {

            FDIDB.SaveChanges();
        }

    }
}
