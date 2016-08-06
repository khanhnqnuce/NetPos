﻿using System;
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
                return new List<RecordItem>();
                //var query = from c in FDIDB.sp_Record()
                //            select new RecordItem
                //    {
                //        CardNumber = c.CardNumber,
                //        Date = c.Date?? new DateTime(),
                //        Value = c.Value??0,
                //        Balance = c.Balance??0,
                //        Action = c.Action,
                //        AccountName = c.AccountName,
                //        CardType = c.CardType,
                //        Buiding = c.Buiding,
                //        Area = c.Area,
                //        UserName = c.UserName,
                //        EventId = c.EventID,
                //        ProductCode = c.ProductCode
                //    };
                //return query.ToList();
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
                                CountValue = c.CountValue == null ? (decimal)0 : (decimal)(0 - c.CountValue)
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<EventItem> FindRecordItems(DateTime startDate, DateTime endDate, string buiding, string area, string ob)
        {
            try
            {
                var query = from c in FDIDB.sp_TatCaGiaoDich(startDate, endDate, buiding, area, ob)
                            orderby c.Date descending
                            select new EventItem
                            {
                                Date = c.Date ?? new DateTime(),
                                CardNumber = c.CardNumber,
                                EventCode = c.EventCode,
                                Event = c.Event,
                                Value = (c.Value > 0) ? (decimal)c.Value : (decimal)(0 - c.Value),
                                Object = c.Object,
                                Area = c.Area
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<EventItem> FindDetailRecordItems(DateTime startDate, DateTime endDate, string buiding, string area, string ob)
        {
            try
            {
                var query = from c in FDIDB.sp_DTBanThe(startDate, endDate, buiding, area, ob)
                            orderby c.Date descending
                            select new EventItem
                            {
                                Date = c.Date ?? new DateTime(),
                                CardNumber = c.CardNumber,
                                EventCode = c.EventCode,
                                Event = c.Event,
                                Balance = c.Balance ?? 0,
                                Value = (c.Value > 0) ? (decimal)c.Value : (decimal)(0 - c.Value),
                                Object = c.Object,
                                Area = c.Area
                            };
                return query.ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<EventItem> FindDetailEventItems(DateTime startDate, DateTime endDate, string buiding, string area, string ob)
        {
            try
            {
                var query = from c in FDIDB.sp_DTBanHang(startDate, endDate, buiding, area, ob)
                            orderby c.Date descending
                            select new EventItem
                            {
                                Date = c.Date ?? new DateTime(),
                                CardNumber = c.CardNumber,
                                EventCode = c.EventCode,
                                Event = c.Event,
                                Balance = c.Balance ?? 0,
                                Value = (c.Value > 0) ? (decimal)c.Value : (decimal)(0 - c.Value),
                                Object = c.Object,
                                Area = c.Area
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
                            orderby c.Name
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
                var query = from c in FDIDB.tblEventCodes
                            where c.Name != ""
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
