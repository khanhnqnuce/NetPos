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
                return query.Take(10).ToList();
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

        public List<RecordItem> FindRecordItems(DateTime? StartDate, DateTime? EndDate, string Buiding, string Area, string PC, string Object, string Function, string EventCode, string TypeCard, string CardNumber, string User)
        {
            try
            {
                var query = from c in FDIDB.sp_Record()
                            where c.Date >= StartDate && c.Date <= EndDate && c.BuidingCode.Contains(Buiding) && c.AreaCode.Contains(Area) && c.PCCode.Contains(PC) && c.ObjectCode.Contains(Object) && c.FID.Contains(Function) && c.EventCode.Contains(EventCode) && c.CardTypeCode.Contains(TypeCard) && c.CardNumber.Contains(CardNumber) && c.UserCode.Contains(User)
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

        public List<BuidingItem> GetBuidingItems()
        {
            try
            {
                var query = from c in FDIDB.tblBuidings
                            select new BuidingItem
                            {
                                Code = c.Code,
                                Name = c.Name
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<AreaItem> GetAreaItems()
        {
            try
            {
                var query = from c in FDIDB.tblAreas
                            select new AreaItem
                            {
                                Code = c.Code,
                                Desc = c.Desc
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<PCItem> GetPCItems()
        {
            try
            {
                var query = from c in FDIDB.tblPCs
                            select new PCItem
                            {
                                Code = c.Code,
                                Name = c.Name
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<ObjectItem> GetObjectItems()
        {
            try
            {
                var query = from c in FDIDB.tblObjects
                            select new ObjectItem
                            {
                                Code = c.Code,
                                Name = c.Name
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<FunctionItem> GetFunctionItems()
        {
            try
            {
                var query = from c in FDIDB.tblFunctions
                            select new FunctionItem
                            {
                                FID = c.FID,
                                Desc = c.Desc
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<EventCodeItem> GetEventCodeItems()
        {
            try
            {
                var query = from c in FDIDB.tblEventCodes where c.Name != ""
                            select new EventCodeItem
                            {
                                Code = c.Code,
                                Name = c.Name
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<UserItem> GetUserItems()
        {
            try
            {
                var query = from c in FDIDB.tblUsers
                            select new UserItem
                            {
                                Code = c.Code,
                                FullName = c.FullName
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
