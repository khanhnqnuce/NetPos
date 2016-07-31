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
        public List<CardItem> GetAll(int id = 0)
        {
            try
            {
                var query = from c in FDIDB.sp_GetListCard(id)
                            select new CardItem
                    {
                        ID = c.id,
                        Balance = c.Balance,
                        CardStatus = c.CardStatus,
                        CardNumber = c.CardNumber,
                        CardType = c.CardType,
                        CustomerID = c.CustomerID,
                        CustomerName = c.CustomerName,
                        DateIssue = c.DateIssue??new DateTime(),
                    };
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<CardItem>();
            }

        }

        public List<CardItem> FindCardItems(string buiding, string area, string obj, string cardType, string cardNumber, string code, string name, string status)
        {
            try
            {
                var query = from c in FDIDB.sp_LocCard(buiding, area, obj, cardType, cardNumber, code, name, status)
                            select new CardItem
                            {
                                ID = c.id,
                                Balance = c.Balance,
                                CardStatus = c.CardStatus,
                                CardNumber = c.CardNumber,
                                CardType = c.CardType,
                                CustomerID = c.CustomerID,
                                CustomerName = c.CustomerName,
                                DateIssue = c.DateIssue ?? new DateTime(),
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
                                ID = c.id,
                                Balance = c.Balance,
                                CardStatus = c.CardStatus,
                                CardNumber = c.CardNumber,
                                CardType = c.CardType,
                                CustomerID = c.CustomerID,
                                CustomerName = c.CustomerName,
                                DateIssue = c.DateIssue ?? new DateTime(),
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<CardItem>();
            }
        }

        public List<GiaoDichItem> GiaoDichGanNhat(string card)
        {
            try
            {
            var query = from c in FDIDB.sp_GiaoDichGanNhat(card)
                        orderby c.Date descending 
                        select new GiaoDichItem
                        {
                            Event = c.Event,
                            Date = c.Date ?? new DateTime(),
                            Value = c.Value ?? 0,
                            Object = c.Name,
                        };
            return query.ToList();
            }
            catch (Exception)
            {
                return new List<GiaoDichItem>();
            }
        }

        public CustomerItem GetCustomer(int id)
        {
            var query = from c in FDIDB.sp_GetListCard(id)
                        select new CustomerItem
                        {
                            ID = c.id,
                            Balance = c.Balance,
                            CardStatus = c.CardStatus,
                            CardNumber = c.CardNumber,
                            CardType = c.CardType,
                            CustomerID = c.CustomerID,
                            CustomerName = c.CustomerName,
                            DateIssue = c.DateIssue ?? new DateTime(),
                            BirthDate = c.BirthDate??new DateTime(),
                            CustomerClass = c.CustomerClass??0,
                            SchoolYear = c.SchoolYear
                        };
            return query.FirstOrDefault();
        }

        public CardItem Get(string card)
        {
            var query = from c in FDIDB.sp_GetCard(card)
                        select new CardItem
                            {
                                //AccountName = c.AccountName,
                                CardNumber = c.CardNumber,
                                //CardTypeCode = c.NameType
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
            try
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
                                UserName = c.UserName
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<RecordItem>();
            }
            
        }

        public List<RecordItem> ReportRevenueBuyProduct(DateTime startDate, DateTime endDate, string buiding, string area, string obj)
        {
            try
            {
                var query = from c in FDIDB.sp_DTBanHang(startDate, endDate, buiding, area, obj)
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
                                UserName = c.UserName
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<RecordItem>();
            }
            
        }

        public List<ThongKeItem> DTBanTheTongHop(DateTime startDate, DateTime endDate, string buiding, string area, string obj)
        {
            try
            {
                var query = from c in FDIDB.sp_DTBanTheTongHop(startDate, endDate, buiding, area, obj)
                            select new ThongKeItem
                            {
                                Name = c.Name,
                                Value = c.Value ?? 0
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<ThongKeItem>();
            }

        }

        public List<ThongKeItem> DTBanHangTongHop(DateTime startDate, DateTime endDate, string buiding, string area, string obj)
        {
            try
            {
                var query = from c in FDIDB.sp_DTBanHangTongHop(startDate, endDate, buiding, area, obj)
                            select new ThongKeItem
                            {
                                Name = c.Name,
                                Value = c.Value ?? 0
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return new List<ThongKeItem>();
            }

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
