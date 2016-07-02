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
    public class LanguagesDA : BaseDA
    {
        #region Constructer
        public LanguagesDA()
        {
        }

        public LanguagesDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public LanguagesDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public List<LanguagesItem> GetListSimpleAll()
        {
            var query = from c in FDIDB.Languages
                        orderby c.Name
                        select new LanguagesItem
                                   {
                                       ID = c.Id,
                                       Code = c.Code.Trim(),
                                       Name = c.Name.Trim(),
                                       FallbackCulture = c.FallbackCulture,
                                       CreatedDate = c.CreatedDate
                                   };
            return query.ToList();
        }

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <param name="isShow">Kiểm tra hiển thị</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<LanguagesItem> GetListSimpleAll(bool isShow)
        {
            var query = from c in FDIDB.Languages
                        where (c.IsShow == isShow)
                        orderby c.Name
                        select new LanguagesItem
                        {
                            ID = c.Id,
                            Code = c.Code.Trim(),
                            Name = c.Name.Trim(),
                            FallbackCulture = c.FallbackCulture,
                            CreatedDate = c.CreatedDate,
                            IsShow = c.IsShow,
                            Icon = c.Gallery_Picture.Folder + c.Gallery_Picture.Url
                        };
            return query.ToList();
        }

        /// <summary>
        /// Lấy về dưới dạng Autocomplete
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="showLimit"></param>
        /// <returns></returns>
        public List<LanguagesItem> GetListSimpleByAutoComplete(string keyword, int showLimit)
        {
            var query = from c in FDIDB.Languages
                        orderby c.Name
                        where c.Name.StartsWith(keyword)
                        select new LanguagesItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim()
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
        public List<LanguagesItem> GetListSimpleByAutoComplete(string keyword, int showLimit, bool isShow)
        {
            var query = from c in FDIDB.Languages
                        orderby c.Name
                        where c.IsShow == isShow 
                        && c.Name.StartsWith(keyword)
                        select new LanguagesItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim()
                                   };
            return query.Take(showLimit).ToList();
        }

        /// <summary>
        /// Lấy về kiểu đơn giản, phân trang
        /// </summary>
        /// <param name="httpRequest"> </param>
        /// <returns>Danh sách bản ghi</returns>
        public List<LanguagesItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);
            var query = from o in FDIDB.Languages 
                        select new LanguagesItem
                                   {
                                       ID = o.Id,
                                       Name = o.Name.Trim(),
                                       Code = o.Code,
                                       FallbackCulture = o.FallbackCulture,
                                       CreatedDate = o.CreatedDate,
                                       IsShow = o.IsShow
                                   };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="ltsArrID"></param>
        /// <returns></returns>
        public List<LanguagesItem> GetListSimpleByArrID(List<int> ltsArrID)
        {
            var query = from o in FDIDB.Languages
                        where ltsArrID.Contains(o.Id)
                        orderby o.Id descending
                        select new LanguagesItem
                        {
                            ID = o.Id,
                            Name = o.Name.Trim(),
                            Code = o.Code,
                            FallbackCulture = o.FallbackCulture,
                            CreatedDate = o.CreatedDate
                        };
            TotalRecord = query.Count();
            return query.ToList();
        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LanguagesItem GetSystemConfigItemById(int id)
        {
            var query = from o in FDIDB.Languages
                        where o.Id == id
                        orderby o.Id descending
                        select new LanguagesItem
                        {
                            ID = o.Id,
                            Name = o.Name.Trim(),
                            Code = o.Code,
                            FallbackCulture = o.FallbackCulture,
                            CreatedDate = o.CreatedDate
                        };
            return query.FirstOrDefault();
        }

        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public Language GetById(int id)
        {
            var query = from c in FDIDB.Languages where c.Id == id select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<Language> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.Languages where ltsArrID.Contains(c.Id) select c;
            return query.ToList();
        }

        /// <summary>
        /// Kiểm tra bản ghi đã tồn tại hay chưa
        /// </summary>
        /// <param name="systemConfig">Đối tượng kiểm tra</param>
        /// <returns>Trạng thái tồn tại</returns>
        public bool CheckExits(Language language)
        {
            var query = from c in FDIDB.Languages where ((c.Name == language.Name) && (c.Id != language.Id)) select c;
            return query.Any();
        }

        /// <summary>
        /// Lấy về bản ghi qua tên
        /// </summary>
        /// <param name="name">Tên bản ghi</param>
        /// <returns>Bản ghi</returns>
        public Language GetByName(string name)
        {
            var query = from c in FDIDB.Languages where ((c.Name == name)) select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="Language"> bản ghi cần thêm</param>
        public void Add(Language language)
        {
            FDIDB.Languages.Add(language);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="systemConfig">Xóa bản ghi</param>
        public void Delete(Language language)
        {
            FDIDB.Languages.Remove(language);
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
