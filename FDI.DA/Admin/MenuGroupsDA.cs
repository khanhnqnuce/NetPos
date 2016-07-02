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
    public class MenuGroupsDa : BaseDA
    {
        #region Constructer
        public MenuGroupsDa()
        {
        }

        public MenuGroupsDa(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public MenuGroupsDa(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public List<MenuGroupsItem> GetListSimpleAll()
        {
            var query = from c in FDIDB.MenuGroups
                        orderby c.Name
                        select new MenuGroupsItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       Des = c.Des,
                                       Sort = c.Sort,
                                       IsShow = c.IsShow,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId
                                   };
            return query.ToList();
        }

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <param name="isShow">Kiểm tra hiển thị</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<MenuGroupsItem> GetListSimpleAll(bool isShow)
        {
            var query = from c in FDIDB.MenuGroups
                        orderby c.Name
                        select new MenuGroupsItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       Des = c.Des,
                                       Sort = c.Sort,
                                       IsShow = c.IsShow,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId
                                   };
            return query.ToList();
        }

        /// <summary>
        /// Lấy về dưới dạng Autocomplete
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="showLimit"></param>
        /// <returns></returns>
        public List<MenuGroupsItem> GetListSimpleByAutoComplete(string keyword, int showLimit)
        {
            var query = from c in FDIDB.MenuGroups
                        orderby c.Name
                        where c.Name.StartsWith(keyword) 
                        select new MenuGroupsItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       Des = c.Des,
                                       Sort = c.Sort,
                                       IsShow = c.IsShow,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId
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
        public List<MenuGroupsItem> GetListSimpleByAutoComplete(string keyword, int showLimit, bool isShow)
        {
            var query = from c in FDIDB.MenuGroups
                        orderby c.Name
                        where c.Name.StartsWith(keyword)
                        select new MenuGroupsItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       Des = c.Des,
                                       Sort = c.Sort,
                                       IsShow = c.IsShow,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId
                                   };
            return query.Take(showLimit).ToList();
        }

        /// <summary>
        /// Lấy về kiểu đơn giản, phân trang
        /// </summary>
        /// <param name="httpRequest"> </param>
        /// <returns>Danh sách bản ghi</returns>
        public List<MenuGroupsItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);
            var query = from c in FDIDB.MenuGroups
                        select new MenuGroupsItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       Des = c.Des,
                                       Sort = c.Sort,
                                       IsShow = c.IsShow,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId

                                   };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="ltsArrID"></param>
        /// <returns></returns>
        public List<MenuGroupsItem> GetListSimpleByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.MenuGroups
                        where ltsArrID.Contains(c.Id) 
                        orderby c.Id descending
                        select new MenuGroupsItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       Des = c.Des,
                                       Sort = c.Sort,
                                       IsShow = c.IsShow,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId
                                   };
            TotalRecord = query.Count();
            return query.ToList();
        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MenuGroupsItem GetMenuGroupsItemById(int id)
        {
            var query = from c in FDIDB.MenuGroups
                        where c.Id == id 
                        orderby c.Id descending
                        select new MenuGroupsItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       Des = c.Des,
                                       Sort = c.Sort,
                                       IsShow = c.IsShow,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId
                                   };
            return query.FirstOrDefault();
        }

        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public MenuGroup GetById(int id)
        {
            var query = from c in FDIDB.MenuGroups where c.Id == id select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<MenuGroup> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.MenuGroups where ltsArrID.Contains(c.Id) select c;
            return query.ToList();
        }

        /// <summary>
        /// Kiểm tra bản ghi đã tồn tại hay chưa
        /// </summary>
        /// <param name="systemConfig">Đối tượng kiểm tra</param>
        /// <returns>Trạng thái tồn tại</returns>
        public bool CheckExits(MenuGroup menuGroup)
        {
            var query = from c in FDIDB.MenuGroups where ((c.Name == menuGroup.Name) && (c.Id != menuGroup.Id)) select c;
            return query.Any();
        }

        /// <summary>
        /// Lấy về bản ghi qua tên
        /// </summary>
        /// <param name="name">Tên bản ghi</param>
        /// <returns>Bản ghi</returns>
        public MenuGroup GetByName(string name)
        {
            var query = from c in FDIDB.MenuGroups where ((c.Name == name)) select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="systemConfig"> bản ghi cần thêm</param>
        public void Add(MenuGroup menuGroup)
        {
            FDIDB.MenuGroups.Add(menuGroup);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="systemConfig">Xóa bản ghi</param>
        public void Delete(MenuGroup menuGroup)
        {
            FDIDB.MenuGroups.Remove(menuGroup);
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
