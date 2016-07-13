using System;
using System.Collections.Generic;
using System.Linq;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public class CardDA : BaseDA
    {
        public List<CardItem> GetAdminAllSimple()
        {
            try
            {
                var query = from c in FDIDB.tblCards
                            select new CardItem
                    {
                        CardNumber = c.CardNumber,
                        AccountName = c.AccountName,
                        Balance = c.Balance,
                        CardTypeCode = c.CardTypeCode,
                        IsRelease = c.IsRelease??false,
                        IsLockCard = c.IsLockCard??false,
                        IsEdit = c.IsEdit
                    };
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<CardItem>();
            }
            
        }

        public List<CardTypeItem> GetTypeCard()
        {
            try
            {
                var query = from c in FDIDB.tblCardTypes
                            select new CardTypeItem
                            {
                                Name = c.Name,
                                Code = c.Code
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<CardTypeItem>();
            }
        } 

        public void Add(tblCard item)
        {
            FDIDB.tblCards.Add(item);
        }

        public void Delete(tblCard item)
        {
            FDIDB.tblCards.Remove(item);
        }
        
        public void Save()
        {

            FDIDB.SaveChanges();
        }
       
    }
}
