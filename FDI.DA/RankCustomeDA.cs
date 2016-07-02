using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA.Admin
{
    public class RankCustomeDA : BaseDA
    {
        #region Constructer
        public RankCustomeDA()
        {
        }

        public RankCustomeDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public RankCustomeDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public List<RankCustomeItem> GetAllListSimple()
        {
            var query = from c in FDIDB.RankCustomes
                        where c.IsDeleted == false
                        orderby c.OrderBy
                        select new RankCustomeItem
                        {
                            ID = c.ID,
                            Name = c.Name
                        };
            return query.ToList();
        }

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <param name="isShow">Kiểm tra hiển thị</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<RankCustomeItem> GetListSimpleAll(bool isShow)
        {
            var query = from c in FDIDB.RankCustomes
                        where c.IsShow == isShow && c.IsDeleted == false
                        orderby c.ID descending
                        select new RankCustomeItem
                        {
                            ID = c.ID,
                            Name = c.Name
                        };
            return query.ToList();
        }

        public List<RankCustomeItem> GetListByType(int type, bool check)
        {
            if (check)
            {
                var query = from c in FDIDB.RankCustomes
                            where c.Type == type && c.IsDeleted == false && c.PricePV > 0
                            orderby c.OrderBy
                            select new RankCustomeItem
                            {
                                ID = c.ID,
                                Name = c.Name,
                                PricePV = c.PricePV
                            };
                return query.ToList();
            }
            else
            {
                var query = from c in FDIDB.RankCustomes
                            where c.Type == type && c.IsDeleted == false && c.PricePV > 0
                            orderby c.OrderBy
                            select new RankCustomeItem
                            {
                                ID = c.ID,
                                Name = c.Name
                            };
                return query.ToList();
            }
        }

        /// <summary>
        /// Lấy về dưới dạng Autocomplete
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="showLimit"></param>
        /// <returns></returns>
        public List<RankCustomeItem> GetListSimpleByAutoComplete(string keyword, int showLimit)
        {
            var query = from c in FDIDB.RankCustomes

                        where c.Name.StartsWith(keyword) && c.IsShow == true && c.IsDeleted == false
                        orderby c.ID descending
                        select new RankCustomeItem
                        {
                            ID = c.ID,
                            Name = c.Name

                        };
            return query.Take(showLimit).ToList();
        }

        /// <summary>
        /// Lấy về dưới dạng Autocomplete
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="showLimit"></param>
        /// <param name="isShow"> </param>
        /// <returns></returns>
        public List<RankCustomeItem> GetListSimpleByAutoComplete(string keyword, int showLimit, bool isShow)
        {
            var query = from c in FDIDB.RankCustomes
                        orderby c.ID descending
                        where c.IsShow == isShow
                        && c.Name.StartsWith(keyword) && c.IsDeleted == false

                        select new RankCustomeItem
                        {
                            ID = c.ID,
                            Name = c.Name
                        };
            return query.Take(showLimit).ToList();
        }

        public List<RankCustomeItem> Getlistsimple(bool isshow)
        {
            var query = from c in FDIDB.RankCustomes
                        orderby c.Name
                        select new RankCustomeItem
                        {
                            ID = c.ID,
                            Name = c.Name,
                        };
            return query.ToList();
        }


        public List<RankCustomeItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);
            var query = from o in FDIDB.RankCustomes
                        where o.IsDeleted == false
                        orderby o.OrderBy
                        select new RankCustomeItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow,
                            PricePV = o.PricePV,
                            Percent = o.Percent,
                            Time = o.Time,
                            Color = o.Color,
                            OrderBy = o.OrderBy,
                            Type = o.Type
                        };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.OrderBy(m => m.Type).ThenBy(m => m.OrderBy).ToList();

        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="ltsArrID"></param>
        /// <returns></returns>
        public List<RankCustomeItem> GetListSimpleByArrID(List<int> ltsArrID)
        {
            var query = from o in FDIDB.RankCustomes
                        where ltsArrID.Contains(o.ID) && !o.IsDeleted.Value
                        orderby o.ID descending
                        select new RankCustomeItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow
                        };

            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        public RankCustomeItem GetSimpleByArrID(int id)
        {
            var query = from o in FDIDB.RankCustomes
                        where o.ID == id && !o.IsDeleted.Value
                        orderby o.ID descending
                        select new RankCustomeItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow,
                            Description = o.Description
                        };
            return query.FirstOrDefault();
        }


        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="advertisingID">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public RankCustomeItem GetBySimpleId(int id)
        {
            var query = from c in FDIDB.RankCustomes
                        where c.ID == id
                        select new RankCustomeItem
                               {
                                   ID = c.ID,
                                   PricePV = c.PricePV,
                                   Name = c.Name
                               };
            return query.FirstOrDefault();
        }

        public RankCustome GetById(int advertisingID)
        {
            var query = from c in FDIDB.RankCustomes where c.ID == advertisingID select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<RankCustome> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.RankCustomes where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }


        /// <summary>
        /// Kiểm tra bản ghi đã tồn tại hay chưa
        /// </summary>
        /// <param name="ad">Đối tượng kiểm tra</param>
        /// <returns>Trạng thái tồn tại</returns>
        public bool CheckExits(RankCustome ad)
        {
            var query = from c in FDIDB.RankCustomes where ((c.Name == ad.Name) && (c.ID != ad.ID)) select c;
            return query.Any();
        }

        /// <summary>
        /// Lấy về bản ghi qua tên
        /// </summary>
        /// <param name="adName">Tên bản ghi</param>
        /// <returns>Bản ghi</returns>
        public RankCustome GetByName(string adName)
        {
            var query = from c in FDIDB.RankCustomes where ((c.Name == adName)) select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="rankCustome">bản ghi cần thêm</param>
        public void Add(RankCustome rankCustome)
        {
            FDIDB.RankCustomes.Add(rankCustome);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="rankCustome">Xóa bản ghi</param>
        public void Delete(RankCustome rankCustome)
        {
            FDIDB.RankCustomes.Remove(rankCustome);
        }

        /// <summary>
        /// save bản ghi vào DB
        /// </summary>
        public void Save()
        {
            FDIDB.SaveChanges();
        }
        #endregion
    }
}
