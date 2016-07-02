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
    public class MenuDa : BaseDA
    {
        #region Constructer
        public MenuDa()
        {
        }

        public MenuDa(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public MenuDa(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        #region các function lấy đệ quy

        /// <summary>
        /// Lấy tất cả menu con theo parentId và theo groupId 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="parentId">Danh mục cha</param>
        /// <returns></returns>
        public List<MenusItem> GetChildByParentId(int groupId, int parentId = 1)
        {
            var cate = from c in FDIDB.Menu_GetChildByParentId(groupId, parentId, LanguageId)
                       select new MenusItem
                       {
                           ID = c.Id,
                           ParentId = c.ParentId,
                           Name = c.Name
                       };
            var re = cate.ToList();
            return re;
        }

        /// <summary>
        /// Hàm build ra treeview chứa danh sách menu
        /// </summary>
        /// <param name="ltsSource"></param>
        /// <param name="menuID"></param>
        /// <param name="checkShow"></param>
        /// <param name="treeViewHtml"></param>
        /// <param name="add"></param>
        /// <param name="delete"></param>
        /// <param name="edit"></param>
        /// <param name="show"></param>
        /// <param name="order"></param>

        public void BuildTreeView(List<MenusItem> ltsSource, int menuID, bool checkShow, ref StringBuilder treeViewHtml, bool add, bool delete, bool edit, bool show, bool order)
        {
            var tempMenu = ltsSource.Where(m => m.ParentId == menuID && m.ID > 1);
            if (checkShow)
                tempMenu = tempMenu.Where(m => m.IsShow == checkShow);

            foreach (var menu in tempMenu)
            {
                var countQuery = ltsSource.Where(m => m.ParentId == menu.ID && m.ID > 1);
                if (checkShow)
                    countQuery = countQuery.Where(m => m.IsShow == checkShow);
                int totalChild = countQuery.Count();
                if (totalChild > 0)
                {
                    treeViewHtml.Append("<li class=\"unselect\" id=\"" + menu.ID.ToString() + "\"><span class=\"folder\"><a class=\"tool\" href=\"javascript:;\">");
                    if (menu.IsShow == false)
                        treeViewHtml.Append("<strike>" + HttpContext.Current.Server.HtmlEncode(menu.Name) + "</strike>");
                    else
                        treeViewHtml.Append(HttpContext.Current.Server.HtmlEncode(menu.Name));
                    treeViewHtml.Append("</a>\r\n");
                    treeViewHtml.AppendFormat(" <i>({0})</i>\r\n", totalChild);
                    treeViewHtml.Append(buildEditToolByID(menu, add, delete, edit, show, order) + "\r\n");
                    treeViewHtml.Append("</span>\r\n");
                    treeViewHtml.Append("<ul>\r\n");
                    BuildTreeView(ltsSource, menu.ID, checkShow, ref treeViewHtml, add, delete, edit, show, order);
                    treeViewHtml.Append("</ul>\r\n");
                    treeViewHtml.Append("</li>\r\n");
                }
                else
                {
                    treeViewHtml.Append("<li  class=\"unselect\" id=\"" + menu.ID.ToString() + "\"><span class=\"file\"><a class=\"tool\" href=\"javascript:;\">");
                    if (menu.IsShow == false)
                        treeViewHtml.Append("<strike>" + HttpContext.Current.Server.HtmlEncode(menu.Name) + "</strike>");
                    else
                        treeViewHtml.Append(HttpContext.Current.Server.HtmlEncode(menu.Name));
                    treeViewHtml.Append("</a> <i>(0)</i>" + buildEditToolByID(menu, add, delete, edit, show, order) + "</span></li>\r\n");
                }
            }
        }

        /// Replace for upper function
        /// <summary>
        /// Build ra editor cho từng menuitem
        /// </summary>
        /// <param name="menuItem"> </param>
        /// <param name="add"> </param>
        /// <param name="delete"> </param>
        /// <param name="edit"> </param>
        /// <param name="show"> </param>
        /// <param name="order"> </param>
        /// <returns></returns>
        private string buildEditToolByID(MenusItem menuItem, bool add, bool delete, bool edit, bool show, bool order)
        {
            var strTool = new StringBuilder();
            strTool.Append("<div class=\"quickTool\">\r\n");

            if (add)
            {
                strTool.AppendFormat("    <a title=\"Thêm mới menu: {1}\" data-event=\"addMenu\" data-groupId=" + menuItem.GroupId + "   href=\"#{0}\">\r\n ", menuItem.ID, menuItem.Name);
                strTool.Append("       <i class=\"fa fa-plus\"></i>");
                strTool.Append("    </a>");
            }
            if (edit)
            {
                strTool.AppendFormat("    <a title=\"Chỉnh sửa: {1}\" data-event=\"editMenu\" data-groupId=" + menuItem.GroupId + " href=\"#{0}\">\r\n", menuItem.ID, menuItem.Name);
                strTool.Append("       <i class=\"fa fa-pencil-square-o\"></i>");
                strTool.Append("    </a>");
            }

            if (show)
            {
                if (menuItem.IsShow == true)
                {
                    strTool.AppendFormat("    <a title=\"Ẩn: {1}\" href=\"#{0}\" data-event=\"hide\">\r\n", menuItem.ID, menuItem.Name);
                    strTool.Append("       <i class=\"fa fa-minus-circle\"></i>");
                    strTool.Append("    </a>\r\n");
                }
                else
                {
                    strTool.AppendFormat("    <a title=\"Hiển thị: {1}\" href=\"#{0}\" data-event=\"show\">\r\n", menuItem.ID, menuItem.Name);
                    strTool.Append("       <i class=\"fa fa-eye\"></i>");
                    strTool.Append("    </a>\r\n");
                }
            }
            if (delete)
            {
                strTool.AppendFormat("    <a title=\"Xóa: {1}\" href=\"#{0}\" data-url='groupId={2}' data-event=\"deleteurl\">\r\n", menuItem.ID, menuItem.Name, menuItem.GroupId);
                strTool.Append("       <i class=\"fa fa-trash-o\"></i>");
                strTool.Append("    </a>\r\n");
            }

            if (order)
            {
                strTool.AppendFormat("    <a title=\"Sắp xếp các menu con: {1}\" href=\"#{0}\" rel=" + menuItem.GroupId + " data-event=\"sortMenu\">\r\n", menuItem.ParentId, menuItem.Name);
                strTool.Append("       <i class=\"fa fa-sort\"></i>");
                strTool.Append("    </a>\r\n");
            }


            strTool.Append("</div>\r\n");
            return strTool.ToString();
        }
        #endregion

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public List<MenusItem> GetListSimpleAll()
        {
            var query = from c in FDIDB.Menus
                        where c.IsDeleted == false && c.LanguageId.ToLower().Equals(LanguageId)
                        orderby c.Name
                        select new MenusItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       GroupId = c.GroupId,
                                       ParentId = c.ParentId,
                                       IsLevel = c.IsLevel,
                                       IsNewTab = c.IsNewTab,
                                       Type = c.Type,
                                       Sort = c.Sort,
                                       Url = c.Url,
                                       IsShow = c.IsShow,
                                       Icon = c.Icon,
                                       LanguageId = c.LanguageId,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId,
                                       Active = c.Active
                                   };
            return query.ToList();
        }

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public MenusItem GetListBySlug(string url)
        {
            var query = from c in FDIDB.Menus
                        where c.IsDeleted == false && c.Url.ToLower().Equals(url.ToLower()) && c.LanguageId.ToLower().Equals(LanguageId)
                        orderby c.Name
                        select new MenusItem
                        {
                            ID = c.Id,
                            Name = c.Name.Trim(),
                            GroupId = c.GroupId,
                            ParentId = c.ParentId,
                            IsLevel = c.IsLevel,
                            IsNewTab = c.IsNewTab,
                            Type = c.Type,
                            Sort = c.Sort,
                            Url = c.Url,
                            IsShow = c.IsShow,
                            Icon = c.Icon,
                            LanguageId = c.LanguageId,
                            CreatedDate = c.CreatedDate,
                            UserCreate = c.UserCreate,
                            UpdatedDate = c.UpdatedDate,
                            UserUpdate = c.UserUpdate,
                            PortalId = c.PortalId,
                            Active = c.Active

                        };
            return query.FirstOrDefault();
        }


        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <param name="isShow">Kiểm tra hiển thị</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<MenusItem> GetListSimpleAll(bool isShow)
        {
            var query = from c in FDIDB.Menus
                        where c.LanguageId.ToLower().Equals(LanguageId)
                        orderby c.Name
                        select new MenusItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       GroupId = c.GroupId,
                                       ParentId = c.ParentId,
                                       IsLevel = c.IsLevel,
                                       IsNewTab = c.IsNewTab,
                                       Type = c.Type,
                                       Sort = c.Sort,
                                       Url = c.Url,
                                       Icon = c.Icon,
                                       LanguageId = c.LanguageId,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId,
                                       Active = c.Active
                                   };
            return query.ToList();
        }

        /// <summary>
        /// Lấy về dưới dạng Autocomplete
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="showLimit"></param>
        /// <returns></returns>
        public List<MenusItem> GetListSimpleByAutoComplete(string keyword, int showLimit)
        {
            var query = from c in FDIDB.Menus
                        orderby c.Name
                        where c.Name.StartsWith(keyword) && c.LanguageId.ToLower().Equals(LanguageId)
                        select new MenusItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       GroupId = c.GroupId,
                                       ParentId = c.ParentId,
                                       IsLevel = c.IsLevel,
                                       IsNewTab = c.IsNewTab,
                                       Type = c.Type,
                                       Sort = c.Sort,
                                       Url = c.Url,
                                       Icon = c.Icon,
                                       LanguageId = c.LanguageId,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId,
                                       Active = c.Active
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
        public List<MenusItem> GetListSimpleByAutoComplete(string keyword, int showLimit, bool isShow)
        {
            var query = from c in FDIDB.Menus
                        orderby c.Name
                        where c.LanguageId.ToLower().Equals(LanguageId)
                        && c.Name.StartsWith(keyword)
                        select new MenusItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       GroupId = c.GroupId,
                                       ParentId = c.ParentId,
                                       IsLevel = c.IsLevel,
                                       IsNewTab = c.IsNewTab,
                                       Type = c.Type,
                                       Sort = c.Sort,
                                       Url = c.Url,
                                       Icon = c.Icon,
                                       LanguageId = c.LanguageId,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId,
                                       Active = c.Active
                                   };
            return query.Take(showLimit).ToList();
        }

        /// <summary>
        /// Lấy về kiểu đơn giản, phân trang
        /// </summary>
        /// <param name="httpRequest"> </param>
        /// <returns>Danh sách bản ghi</returns>
        public List<MenusItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);
            var query = from c in FDIDB.Menus
                        where c.LanguageId.ToLower().Equals(LanguageId.ToLower())
                        select c;


            #region GroupId
            if (!string.IsNullOrEmpty(httpRequest["GroupId"]))
            {
                var groupId = int.Parse(httpRequest["GroupId"]);
                query = query.Where(m => m.GroupId == groupId);
            }
            else
                query = query.Where(m => m.GroupId == 0);
            #endregion

            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.Select(c => new MenusItem
            {
                ID = c.Id,
                Name = c.Name.Trim(),
                GroupId = c.GroupId,
                ParentId = c.ParentId,
                IsShow = c.IsShow,
                IsLevel = c.IsLevel,
                IsNewTab = c.IsNewTab,
                Type = c.Type,
                Sort = c.Sort,
                Url = c.Url,
                Icon = c.Icon,
                LanguageId = c.LanguageId,
                CreatedDate = c.CreatedDate,
                UserCreate = c.UserCreate,
                UpdatedDate = c.UpdatedDate,
                UserUpdate = c.UserUpdate,
                PortalId = c.PortalId,
                Active = c.Active
            }).OrderBy(m => m.Sort).ToList();
        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="ltsArrID"></param>
        /// <returns></returns>
        public List<MenusItem> GetListSimpleByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.Menus
                        where ltsArrID.Contains(c.Id) && c.LanguageId.ToLower().Equals(LanguageId)
                        orderby c.Id descending
                        select new MenusItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       GroupId = c.GroupId,
                                       ParentId = c.ParentId,
                                       IsLevel = c.IsLevel,
                                       IsNewTab = c.IsNewTab,
                                       Type = c.Type,
                                       Sort = c.Sort,
                                       Url = c.Url,
                                       Icon = c.Icon,
                                       LanguageId = c.LanguageId,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId,
                                       Active = c.Active
                                   };
            TotalRecord = query.Count();
            return query.ToList();
        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<MenusItem> GetMenuGroupsItemById(int id)
        {
            var query = from c in FDIDB.Menus
                        where c.Id == id && c.LanguageId.ToLower().Equals(LanguageId)
                        orderby c.Id descending
                        select new MenusItem
                                   {
                                       ID = c.Id,
                                       Name = c.Name.Trim(),
                                       GroupId = c.GroupId,
                                       ParentId = c.ParentId,
                                       IsLevel = c.IsLevel,
                                       IsNewTab = c.IsNewTab,
                                       Type = c.Type,
                                       Sort = c.Sort,
                                       Url = c.Url,
                                       Icon = c.Icon,
                                       LanguageId = c.LanguageId,
                                       CreatedDate = c.CreatedDate,
                                       UserCreate = c.UserCreate,
                                       UpdatedDate = c.UpdatedDate,
                                       UserUpdate = c.UserUpdate,
                                       PortalId = c.PortalId,
                                       Active = c.Active
                                   };
            return query.ToList();
        }

        public List<MenusItem> GetMenuItemByGroupId(int groupId)
        {
            var query = from c in FDIDB.Menus
                        where c.IsDeleted == false && c.GroupId == groupId && c.IsDeleted == false && c.LanguageId == LanguageId
                        orderby c.Sort
                        select new MenusItem
                        {
                            ID = c.Id,
                            Name = c.Name.Trim(),
                            GroupId = c.GroupId,
                            ParentId = c.ParentId,
                            IsShow = c.IsShow,
                            IsLevel = c.IsLevel,
                            IsNewTab = c.IsNewTab,
                            Type = c.Type,
                            Sort = c.Sort,
                            Url = c.Url,
                            Icon = c.Icon,
                            LanguageId = c.LanguageId,
                            CreatedDate = c.CreatedDate,
                            UserCreate = c.UserCreate,
                            UpdatedDate = c.UpdatedDate,
                            UserUpdate = c.UserUpdate,
                            PortalId = c.PortalId,
                            Active = c.Active
                        };
            return query.ToList();
        }

        public List<MenusItem> GetAllListSimpleByParentId(int parent, int groupId)
        {
            var query = from c in FDIDB.Menus
                        where c.Id > 1 && c.ParentId == parent && c.GroupId == groupId
                        orderby c.Sort
                        select new MenusItem
                        {
                            ID = c.Id,
                            Name = c.Name.Trim(),
                            GroupId = c.GroupId,
                            ParentId = c.ParentId,
                            PageId = c.PageId,
                            IsLevel = c.IsLevel,
                            IsNewTab = c.IsNewTab,
                            Type = c.Type,
                            Sort = c.Sort,
                            Url = c.Url,
                            Icon = c.Icon,
                            LanguageId = c.LanguageId,
                            CreatedDate = c.CreatedDate,
                            UserCreate = c.UserCreate,
                            UpdatedDate = c.UpdatedDate,
                            UserUpdate = c.UserUpdate,
                            PortalId = c.PortalId,
                            Active = c.Active
                        };
            return query.ToList();
        }

        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public Menu GetById(int id)
        {
            var query = from c in FDIDB.Menus where c.Id == id select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<Menu> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.Menus where ltsArrID.Contains(c.Id) select c;
            return query.ToList();
        }

        /// <summary>
        /// Kiểm tra bản ghi đã tồn tại hay chưa
        /// </summary>
        /// <param name="systemConfig">Đối tượng kiểm tra</param>
        /// <returns>Trạng thái tồn tại</returns>
        public bool CheckExits(Menu menu)
        {
            var query = from c in FDIDB.Menus where ((c.Name == menu.Name) && (c.Id != menu.Id)) && c.LanguageId.ToLower().Equals(LanguageId) select c;
            return query.Any();
        }

        /// <summary>
        /// Lấy về bản ghi qua tên
        /// </summary>
        /// <param name="name">Tên bản ghi</param>
        /// <returns>Bản ghi</returns>
        public Menu GetByName(string name)
        {
            var query = from c in FDIDB.Menus where ((c.Name == name)) && c.LanguageId.ToLower().Equals(LanguageId) select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="systemConfig"> bản ghi cần thêm</param>
        public void Add(Menu menu)
        {
            FDIDB.Menus.Add(menu);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="systemConfig">Xóa bản ghi</param>
        public void Delete(Menu menu)
        {
            FDIDB.Menus.Remove(menu);
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
