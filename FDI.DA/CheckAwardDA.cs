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
    public class CheckAwardDA : BaseDA
    {
        #region Constructer
        public CheckAwardDA()
        {
        }

        public CheckAwardDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public CheckAwardDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public List<CheckAwardItem> GetAllListSimple()
        {
            var query = from c in FDIDB.CheckAwards
                        where c.IsDeleted == false
                        orderby c.ID descending
                        select new CheckAwardItem
                        {
                            ID = c.ID,
                            Name = c.Name
                        };
            return query.ToList();
        }

        public List<CheckAwardItem> GetListSimpleByType(int type)
        {
            var query = from c in FDIDB.CheckAwards
                        where c.IsDeleted == false && c.Type == type
                        orderby c.ID descending
                        select new CheckAwardItem
                        {
                            ID = c.ID,
                            Name = c.Name,
                            Time = c.Time,
                            };
            return query.ToList();
        }

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <param name="isShow">Kiểm tra hiển thị</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<CheckAwardItem> GetListSimpleAll(bool isShow)
        {
            var query = from c in FDIDB.CheckAwards
                        where c.IsShow == isShow && c.IsDeleted == false
                        orderby c.Time
                        select new CheckAwardItem
                        {
                            ID = c.ID,
							Time = c.Time,
                            Name = c.Name,
                            Type = c.Type
                        };
            return query.ToList();
        }

        /// <summary>
        /// Lấy về dưới dạng Autocomplete
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="showLimit"></param>
        /// <returns></returns>
        public List<CheckAwardItem> GetListSimpleByAutoComplete(string keyword, int showLimit)
        {
            var query = from c in FDIDB.CheckAwards

                        where c.Name.StartsWith(keyword) && c.IsShow == true && c.IsDeleted == false
                        orderby c.ID descending
                        select new CheckAwardItem
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
        public List<CheckAwardItem> GetListSimpleByAutoComplete(string keyword, int showLimit, bool isShow)
        {
            var query = from c in FDIDB.CheckAwards
                        orderby c.ID descending
                        where c.IsShow == isShow
                        && c.Name.StartsWith(keyword) && c.IsDeleted == false

                        select new CheckAwardItem
                        {
                            ID = c.ID,
                            Name = c.Name
                        };
            return query.Take(showLimit).ToList();
        }

        public List<CheckAwardItem> Getlistsimple(bool isshow)
        {
            var query = from c in FDIDB.CheckAwards
                        orderby c.Name
                        select new CheckAwardItem
                        {
                            ID = c.ID,
                            Name = c.Name,
                        };
            return query.ToList();
        }


        public List<CheckAwardItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);

            var query = from o in FDIDB.CheckAwards
                        where o.IsDeleted == false
                        select new CheckAwardItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow,
                            Time = o.Time

                        };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();

        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="ltsArrID"></param>
        /// <returns></returns>
        public List<CheckAwardItem> GetListSimpleByArrID(List<int> ltsArrID)
        {
            var query = from o in FDIDB.CheckAwards
                        where ltsArrID.Contains(o.ID) && !o.IsDeleted.Value
                        orderby o.ID descending
                        select new CheckAwardItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow
                        };

            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        public CheckAwardItem GetSimpleByArrID(int id)
        {
            var query = from o in FDIDB.CheckAwards
                        where o.ID == id && !o.IsDeleted.Value
                        orderby o.ID descending
                        select new CheckAwardItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow,
                           
                        };
            return query.FirstOrDefault();
        }


        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="advertisingID">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public CheckAward GetById(int advertisingID)
        {
            var query = from c in FDIDB.CheckAwards where c.ID == advertisingID  select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<CheckAward> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.CheckAwards where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }


        /// <summary>
        /// Kiểm tra bản ghi đã tồn tại hay chưa
        /// </summary>
        /// <param name="ad">Đối tượng kiểm tra</param>
        /// <returns>Trạng thái tồn tại</returns>
        public bool CheckExits(CheckAward ad)
        {
            var query = from c in FDIDB.CheckAwards where ((c.Name == ad.Name) && (c.ID != ad.ID)) select c;
            return query.Any();
        }

        /// <summary>
        /// Lấy về bản ghi qua tên
        /// </summary>
        /// <param name="adName">Tên bản ghi</param>
        /// <returns>Bản ghi</returns>
        public CheckAward GetByName(string adName)
        {
            var query = from c in FDIDB.CheckAwards where ((c.Name == adName)) select c;
            return query.FirstOrDefault();
        }



        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="checkAward">bản ghi cần thêm</param>
        public void Add(CheckAward checkAward)
        {
            FDIDB.CheckAwards.Add(checkAward);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="checkAward">Xóa bản ghi</param>
        public void Delete(CheckAward checkAward)
        {
            FDIDB.CheckAwards.Remove(checkAward);
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
