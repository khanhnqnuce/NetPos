using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA
{
    public class CardDA : BaseDA
    {
        public List<CardItem> GetAll()
        {
            try
            {
                var query = from c in FDIDB.sp_GetListCard()
                            select new CardItem
                    {
                        ID = c.Id,
                        Code = c.Code,
                        CardNumber = c.CardNumber,
                        AccountName = c.AccountName,
                        Balance = c.Balance,
                        CardTypeCode = c.NameType ?? "#",
                        IsRelease = c.IsRelease ?? false,
                        IsLockCard = c.IsLockCard ?? false,
                        IsEdit = c.IsEdit
                    };
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<CardItem>();
            }

        }

        public List<CardItem> FindCardItems(string buiding, string area, string obj, string cardType, string cardNumber, string code, string name, bool? phathanh, bool? chuaphathanh, bool? islock)
        {
            try
            {
                var query = from c in FDIDB.sp_LocCard(buiding, area, obj, cardType, cardNumber, code, name, phathanh, chuaphathanh, islock)
                            select new CardItem
                            {
                                ID = c.Id,
                                Code = c.Code,
                                CardNumber = c.CardNumber,
                                AccountName = c.AccountName,
                                Balance = c.Balance,
                                CardTypeCode = c.TypeCard ?? "#",
                                IsRelease = c.IsRelease ?? false,
                                IsLockCard = c.IsLockCard ?? false,
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

        public List<CardItem> GetDuplicateCardTypeItems()
        {
            try
            {
                var query = from c in FDIDB.sp_TheTrungNhau()
                            select new CardItem
                            {
                                CardNumber = c.CardNumber,
                                AccountName = c.AccountName,
                                Balance = c.Balance,
                                CardTypeCode = c.CardTypeCode,
                                IsRelease = c.IsRelease ?? false,
                                IsLockCard = c.IsLockCard ?? false,
                                IsEdit = c.IsEdit
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<CardItem>();
            }
        }

        public List<GiaoDichItem> GetRecord(string card)
        {
            try
            {
            var query = from c in FDIDB.sp_GiaoDichGanNhat(card)
                        select new GiaoDichItem
                        {
                            Action = c.Action,
                            Date = c.Date ?? new DateTime(),
                            Value = c.Value ?? 0,
                            Balance = c.Balance ?? 0,
                            Object = c.Object,
                            ProductCode = c.ProductCode
                        };
            return query.ToList();
            }
            catch (Exception)
            {
                return new List<GiaoDichItem>();
            }
        }

        public tblCard Get(int id)
        {
            var query = from c in FDIDB.tblCards where c.Id == id select c;
            return query.FirstOrDefault();
        }

        public CardItem Get(string card)
        {
            var query = from c in FDIDB.sp_GetCard(card)
                        select new CardItem
                            {
                                AccountName = c.AccountName,
                                CardNumber = c.CardNumber,
                                CardTypeCode = c.NameType
                            };
            return query.FirstOrDefault();
        }

        public List<AreaItem> GetArea(string code)
        {
            try
            {
                var query = from c in FDIDB.tblAreas
                            where c.BuidingCode == code
                            orderby c.Desc
                            select new AreaItem
                            {
                                Code = c.Code,
                                Desc = c.Desc
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<AreaItem>();
            }
            
        }

        public List<ObjectItem> GetObject(string code)
        {
            try
            {
                var query = from c in FDIDB.tblObjects
                            where c.AreaCode == code
                            orderby c.Desc
                            select new ObjectItem
                            {
                                Code = c.Code,
                                Name = c.Name
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<ObjectItem>();
            }
            
        }

        public List<RecordItem> ReportRevenueCard(DateTime startDate, DateTime endDate, string buiding, string area, string obj)
        {
            var query = from c in FDIDB.sp_DTBanThe(startDate, endDate, buiding, area, obj)
                        select new RecordItem
                        {
                            CardNumber = c.CardNumber,
                            Date = c.Date ?? new DateTime(),
                            Value = c.Value ?? 0,
                            Balance = c.Balance ?? 0,
                            Action = c.Action,
                            AccountName = c.AccountName,
                            CardType = c.CardType,
                            Buiding = c.Buiding,
                            Area = c.Area,
                            UserName = c.UserName,
                            //EventId = c.EventID,
                            //ProductCode = c.ProductCode
                        };
            return query.ToList();
        }
        
        public List<DTBanHangItem> ReportRevenueBuyProduct(DateTime startDate, DateTime endDate, string buiding, string area, string obj)
        {
            var query = from c in FDIDB.sp_DTBanHang(startDate, endDate, buiding, area, obj)
                        select new DTBanHangItem
                        {
                            Name = c.Name,
                            Value = c.Value ?? 0
                        };
            return query.ToList();
        }

        public List<tblCard> Get(List<int> lst)
        {
            var query = from c in FDIDB.tblCards where lst.Contains(c.Id) select c;
            return query.ToList();
        }

        public void UpdateCard(string cardOld, string cardNew)
        {
            FDIDB.sp_UpdateCard(cardNew, cardOld);
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
