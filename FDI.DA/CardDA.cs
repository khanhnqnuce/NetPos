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
                //ObjectParameter name = new ObjectParameter("Name", typeof(String));
                //context.GetDepartmentName(1, name);
                //Console.WriteLine(name.Value);

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
