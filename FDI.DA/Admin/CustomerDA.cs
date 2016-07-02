using System.Net.Sockets;
using System.Text;
using FDI.DA.Admin;
using FDI.Base;
using FDI.Simple;
using FDI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FDI.DA.Admin
{
    public partial class CustomerDA : BaseDA
    {
        private readonly System_CountryDA _systemCountryDA;
        private readonly System_CityDA _systemCityDA;
        private readonly System_DistrictDA _systemDistrictDA;

        #region Constructer

        public CustomerDA()
        {
            _systemCountryDA = new System_CountryDA("#");
            _systemCityDA = new System_CityDA("#");
            _systemDistrictDA = new System_DistrictDA("#");
        }

        public CustomerDA(string pathPaging)
        {
            PathPaging = pathPaging;
            _systemCountryDA = new System_CountryDA("#");
            _systemCityDA = new System_CityDA("#");
            _systemDistrictDA = new System_DistrictDA("#");
        }

        public CustomerDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
            _systemCountryDA = new System_CountryDA("#");
            _systemCityDA = new System_CityDA("#");
            _systemDistrictDA = new System_DistrictDA("#");
        }

        #endregion


        #region các function lấy đệ quy

        /// <summary>
        /// Lấy về cây có tổ chức
        /// </summary>
        /// <param name="ltsSource">Toàn bộ danh mục</param>
        /// <param name="idRemove">ID danh mục select</param>
        /// <returns></returns>
        public List<CustomerItem> GetAllSelectList(List<CustomerItem> ltsSource, int idRemove)
        {

            var ltsConvert = new List<CustomerItem>
            {
                new CustomerItem
                {
                    ID = 1,
                    UserName = "Thư mục gốc"
                }
            };

            BuildTreeListItem(ltsSource, 1, string.Empty, idRemove, ref ltsConvert);
            return ltsConvert;
        }

        public List<CustomerItem> GetAllSelectListByid(List<CustomerItem> ltsSource, int idRemove, int id)
        {

            var ltsConvert = new List<CustomerItem>();
            BuildTreeListCustomerItem(ltsSource, id, idRemove, ref ltsConvert);
            return ltsConvert;
        }

        /// <summary>
        /// Build cây đệ quy
        /// </summary>
        /// <param name="ltsItems"></param>
        /// <param name="rootID"> </param>
        /// <param name="space"></param>
        /// <param name="idRemove"> </param>
        /// <param name="ltsConvert"></param>
        private void BuildTreeListCustomerItem(List<CustomerItem> ltsItems, int rootID, int idRemove,
            ref List<CustomerItem> ltsConvert)
        {
            //space += "---";
            var custome = ltsItems.FirstOrDefault(m => m.ID == rootID);
            var ltsChils = ltsItems.Where(o => o.ParentID == rootID && o.ID != idRemove).ToList();
            foreach (var currentItem in ltsChils)
            {
                //currentItem.UserName = string.Format("{0}{1}", space, currentItem.UserName);
                currentItem.Level = custome.Level + 1;
                ltsConvert.Add(currentItem);
                BuildTreeListCustomerItem(ltsItems, currentItem.ID, idRemove, ref ltsConvert);
            }
        }

        /// <summary>
        /// Build cây đệ quy
        /// </summary>
        /// <param name="ltsItems"></param>
        /// <param name="rootID"> </param>
        /// <param name="space"></param>
        /// <param name="idRemove"> </param>
        /// <param name="ltsConvert"></param>
        private void BuildTreeListItem(List<CustomerItem> ltsItems, int rootID, string space, int idRemove,
            ref List<CustomerItem> ltsConvert)
        {
            space += "---";
            var ltsChils = ltsItems.Where(o => o.ParentID == rootID && o.ID != idRemove).ToList();
            foreach (var currentItem in ltsChils)
            {
                currentItem.UserName = string.Format("|{0} {1}", space, currentItem.UserName);
                ltsConvert.Add(currentItem);
                BuildTreeListItem(ltsItems, currentItem.ID, space, idRemove, ref ltsConvert);
            }
        }


        #region dùng bên ngoài trang khách hàng

        public void BuildTreeViewHome(List<CustomerItem> ltsSource, int id, bool checkShow,
            ref StringBuilder TreeViewHtml)
        {
            var tempCategory = ltsSource.Where(m => m.ParentID == id).ToList();
            if (checkShow)
                tempCategory = tempCategory.Where(m => m.IsPublish != checkShow).ToList();

            foreach (var category in tempCategory)
            {
                var countQuery = ltsSource.Where(m => m.ParentID == category.ID && m.ID > 1);
                if (checkShow)
                    countQuery = countQuery.Where(m => m.IsPublish != checkShow);
                int totalChild = countQuery.Count();
                if (totalChild > 0)
                {
                    TreeViewHtml.Append("<li title=\"" + "\" class=\"unselect\" id=\"" + category.ID.ToString() +
                                        "\"><span class=\"folder\"><a class=\"tool " + (category.IsNext ? "IsNext" : "") +
                                        "\" href=\"javascript:;\">");
                    if (category.IsPublish == true)
                        TreeViewHtml.Append("<strike>" + HttpContext.Current.Server.HtmlEncode(category.UserName) +
                                            "</strike>");
                    else
                        TreeViewHtml.Append(HttpContext.Current.Server.HtmlEncode(category.UserName));
                    TreeViewHtml.Append("</a>\r\n");
                    TreeViewHtml.AppendFormat(" <i>({0})</i>\r\n", category.Level);
                    TreeViewHtml.Append(buildEditToolByID(category) + "\r\n");
                    TreeViewHtml.Append("</span>\r\n");
                    TreeViewHtml.Append("<ul>\r\n");
                    BuildTreeView(ltsSource, category.ID, checkShow, ref TreeViewHtml);
                    TreeViewHtml.Append("</ul>\r\n");
                    TreeViewHtml.Append("</li>\r\n");
                }
                else
                {
                    TreeViewHtml.Append("<li title=\"" + "\" class=\"unselect\" id=\"" + category.ID.ToString() +
                                        "\"><span class=\"file\"><a class=\"tool " + (category.IsNext ? "IsNext" : "") +
                                        "\" href=\"javascript:;\">");
                    if (category.IsPublish == true)
                        TreeViewHtml.Append("<strike>" + HttpContext.Current.Server.HtmlEncode(category.UserName) +
                                            "</strike>");
                    else
                        TreeViewHtml.Append(HttpContext.Current.Server.HtmlEncode(category.UserName));
                    TreeViewHtml.Append("</a> <i>(" + category.Level + ")</i>" + buildEditToolByID(category) +
                                        "</span></li>\r\n");
                }
            }
        }

        public void BuildTreeView(List<CustomerItem> ltsSource, int id, bool checkShow, ref StringBuilder TreeViewHtml)
        {
            var tempCategory = ltsSource.Where(m => m.ParentID == id).ToList();
            if (checkShow)
                tempCategory = tempCategory.Where(m => m.IsPublish != checkShow).ToList();

            foreach (var category in tempCategory)
            {
                var countQuery = ltsSource.Where(m => m.ParentID == category.ID && m.ID > 1);
                if (checkShow)
                    countQuery = countQuery.Where(m => m.IsPublish != checkShow);
                int totalChild = countQuery.Count();
                if (totalChild > 0)
                {
                    TreeViewHtml.Append("<li title=\"" + "\" class=\"unselect\" id=\"" + category.ID.ToString() +
                                        "\"><span class=\"folder\"><a class=\" " + (category.IsNext ? "IsNext" : "tool") +
                                        "\" href=\"javascript:;\">");
                    if (category.IsPublish == true)
                        TreeViewHtml.Append("<strike>" + HttpContext.Current.Server.HtmlEncode(category.UserName) +
                                            "</strike>");
                    else
                        TreeViewHtml.Append(HttpContext.Current.Server.HtmlEncode(category.UserName));
                    TreeViewHtml.Append("</a>\r\n");
                    TreeViewHtml.AppendFormat(" <i>({0})</i>\r\n", category.Level);
                    TreeViewHtml.Append(buildEditToolByID(category) + "\r\n");
                    TreeViewHtml.Append("</span>\r\n");
                    TreeViewHtml.Append("<ul>\r\n");
                    BuildTreeView(ltsSource, category.ID, checkShow, ref TreeViewHtml);
                    TreeViewHtml.Append("</ul>\r\n");
                    TreeViewHtml.Append("</li>\r\n");
                }
                else
                {
                    TreeViewHtml.Append("<li title=\"" + "\" class=\"unselect\" id=\"" + category.ID.ToString() +
                                        "\"><span class=\"file\"><a class=\"tool " + (category.IsNext ? "IsNext" : "") +
                                        "\" href=\"javascript:;\">");
                    if (category.IsPublish == true)
                        TreeViewHtml.Append("<strike>" + HttpContext.Current.Server.HtmlEncode(category.UserName) +
                                            "</strike>");
                    else
                        TreeViewHtml.Append(HttpContext.Current.Server.HtmlEncode(category.UserName));
                    TreeViewHtml.Append("</a> <i>(" + category.Level + ")</i>" + buildEditToolByID(category) +
                                        "</span></li>\r\n");
                }
            }
        }

        public string buildEditToolByID(CustomerItem tempCustomer)
        {
            var strTool = new StringBuilder();
            strTool.Append("<div class=\"quickTool\">\r\n");
            if (tempCustomer.IsActive == true)
            {
                strTool.AppendFormat("<div class=\"ShowDetailAccHome\">");
                strTool.Append("<div class=\"titleAcc " + (tempCustomer.IsAgency ? (tempCustomer.IsLeader ? "Leader" : "Agency") : tempCustomer.RankUser) +
                               "\">Thông tin thành viên</div>");
                strTool.Append("<div class=\"bodyAcc\">");
                strTool.Append("<span><strong>Tên thành viên :</strong><strong>" + tempCustomer.FullName + " (" + tempCustomer.UserName + ")</strong></span>");
                //strTool.Append("<span class = \"colorrank\"><strong>Hạng NPP :</strong><strong>" +
                //               (tempCustomer.IsAgency
                //                   ? (tempCustomer.IsLeader ? "Leader" : "Agency")
                //                   : (tempCustomer.RankNows != null || tempCustomer.Level < 4 || tempCustomer.RankNows.Level < 4 ? tempCustomer.RankUser : "Pro")) + "</strong></span>");
                strTool.Append("<span><strong>Cấp bậc :</strong><strong>" + tempCustomer.RankUser + "</strong></span>");
                //strTool.Append("<span><strong>Tổng chu Kỳ :</strong><strong>" + (tempCustomer.RankNows != null ? (int)(tempCustomer.RankNows.CycleNumberHome ?? 0) : 0) +
                //               "</strong></span>");
                strTool.Append("<span><strong>Tổng NPP trái :</strong><strong>" + (tempCustomer.RankNows != null ? (int)(tempCustomer.RankNows.PricePVUser ?? 0) : 0) +
                               " </strong></span>");
                strTool.Append("<span><strong>Tổng NPP phải :</strong><strong>" + (tempCustomer.RankNows != null ? (int)(tempCustomer.RankNows.PricePVUser1 ?? 0) : 0) +
                               " </strong></span> </div> </div>");
            }
            else
            {
                strTool.AppendFormat("<div class=\"ShowDetailAccHome\">");
                strTool.Append("<div class=\"titleAcc " +
                               "\">Thông tin thành viên</div>");
                strTool.Append("<div class=\"bodyAcc\">");
                strTool.Append("<span><strong>Tên thành viên :</strong><strong>" + tempCustomer.FullName + " (" + tempCustomer.Title + ")</strong></span>" +
                               "<span style=color:red;font-weight:bold>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Chưa là thành viên chính thức<span></div> </div>");
            }

            strTool.Append("</div>\r\n");
            return strTool.ToString();
        }

        #endregion



        /// <summary>
        /// Hàm build ra treeview có checkbox chứa danh sách category
        /// </summary>
        public void BuildTreeViewCheckBox(List<CustomerItem> ltsSource, int id, bool checkShow,
            ref StringBuilder treeViewHtml)
        {
            var tempCustomer = ltsSource.Where(m => m.ParentID == id && m.ID > 1);

            foreach (var customerItem in tempCustomer)
            {
                var countQuery = ltsSource.Where(m => m.ParentID == customerItem.ID && m.ID > 1);
                if (checkShow)
                    countQuery = countQuery.Where(m => m.IsPublish == checkShow);
                int totalChild = countQuery.Count();
                if (totalChild > 0)
                {
                    treeViewHtml.Append("<li title=\"" + "\" class=\"unselect\" id=\"" + customerItem.ID.ToString() +
                                        "\"><span class=\"folder\"> <input id=\"Category_" + customerItem.ID +
                                        "\" name=\"Category_" + customerItem.ID + "\" value=\"" + customerItem.ID +
                                        "\" type=\"checkbox\" title=\"" + customerItem.UserName + "\" /> ");
                    if (customerItem.IsPublish == false)
                        treeViewHtml.Append("<strike>" + HttpContext.Current.Server.HtmlEncode(customerItem.UserName) +
                                            "</strike>");
                    else
                        treeViewHtml.Append(HttpContext.Current.Server.HtmlEncode(customerItem.UserName));
                    treeViewHtml.Append("</span>\r\n");
                    treeViewHtml.Append("<ul>\r\n");
                    BuildTreeViewCheckBox(ltsSource, customerItem.ID, checkShow, ref treeViewHtml);
                    treeViewHtml.Append("</ul>\r\n");
                    treeViewHtml.Append("</li>\r\n");
                }
                else
                {

                    if (customerItem.IsPublish == false)
                        treeViewHtml.Append("<strike>" + HttpContext.Current.Server.HtmlEncode(customerItem.UserName) +
                                            "</strike>");
                    else
                        treeViewHtml.Append(HttpContext.Current.Server.HtmlEncode(customerItem.UserName));
                    treeViewHtml.Append("</span></li>\r\n");
                }
            }
        }


        /// <summary>
        /// Hàm build ra treeview chứa danh sách category
        /// </summary>
        /// <param name="ltsSource">List category</param>
        /// <param name="id">ID parent</param>
        /// <param name="checkShow">Check hiển thị</param>
        /// <param name="treeViewHtml">String output</param>
        /// <param name="add"> </param>
        /// <param name="delete"> </param>
        /// <param name="edit"> </param>
        /// <param name="view"> </param>
        /// <param name="show"> </param>
        /// <param name="hide"> </param>
        /// <param name="order"> </param>
        public void BuildTreeView(List<CustomerItem> ltsSource, int id, bool checkShow, ref StringBuilder TreeViewHtml,
            bool add, bool delete, bool edit, bool view, bool show, bool hide, bool order)
        {
            var tempCategory = ltsSource.Where(m => m.ParentID == id).ToList();
            if (checkShow)
                tempCategory = tempCategory.Where(m => m.IsPublish != checkShow).ToList();

            foreach (var category in tempCategory)
            {
                var countQuery = ltsSource.Where(m => m.ParentID == category.ID && m.ID > 1);
                if (checkShow)
                    countQuery = countQuery.Where(m => m.IsPublish != checkShow);
                int totalChild = countQuery.Count();
                if (totalChild > 0)
                {
                    TreeViewHtml.Append("<li title=\"" + "\" class=\"unselect\" id=\"" + category.ID.ToString() +
                                        "\"><span class=\"folder\"><a class=\"tool " + (category.IsNext ? "IsNext" : "") +
                                        "\" href=\"javascript:;\">");
                    if (category.IsPublish == true)
                        TreeViewHtml.Append("<strike>" + HttpContext.Current.Server.HtmlEncode(category.UserName) +
                                            "</strike>");
                    else
                        TreeViewHtml.Append(HttpContext.Current.Server.HtmlEncode(category.UserName));
                    TreeViewHtml.Append("</a>\r\n");
                    TreeViewHtml.AppendFormat(" <i>({0})</i>\r\n", category.Level);
                    TreeViewHtml.Append(buildEditToolByID(category, add, delete, edit, show, order) + "\r\n");
                    TreeViewHtml.Append("</span>\r\n");
                    TreeViewHtml.Append("<ul>\r\n");
                    BuildTreeView(ltsSource, category.ID, checkShow, ref TreeViewHtml, add, delete, edit, view, show,
                        hide, order);
                    TreeViewHtml.Append("</ul>\r\n");
                    TreeViewHtml.Append("</li>\r\n");
                }
                else
                {
                    TreeViewHtml.Append("<li title=\"" + "\" class=\"unselect\" id=\"" + category.ID.ToString() +
                                        "\"><span class=\"file\"><a class=\"tool " + (category.IsNext ? "IsNext" : "") +
                                        "\" href=\"javascript:;\">");
                    if (category.IsPublish == true)
                        TreeViewHtml.Append("<strike>" + HttpContext.Current.Server.HtmlEncode(category.UserName) +
                                            "</strike>");
                    else
                        TreeViewHtml.Append(HttpContext.Current.Server.HtmlEncode(category.UserName));
                    TreeViewHtml.Append("</a> <i>(0)</i>" + buildEditToolByID(category, add, delete, edit, show, order) +
                                        "</span></li>\r\n");
                }
            }
        }




        /// Replace for upper function
        /// <summary>
        /// Build ra editor cho từng NewsCategoryItem
        /// </summary>
        /// <param name="tempCustomer"> </param>
        /// <param name="add"> </param>
        /// <param name="delete"> </param>
        /// <param name="edit"> </param>
        /// <param name="show"> </param>
        /// <param name="order"> </param>
        /// <returns></returns>
        private string buildEditToolByID(CustomerItem tempCustomer, bool add, bool delete, bool edit, bool show,
            bool order)
        {
            var strTool = new StringBuilder();
            strTool.Append("<div class=\"quickTool\">\r\n");
            if (add && tempCustomer.Countcustomer < 2 && tempCustomer.IsAdd)
            {
                strTool.AppendFormat("    <a title=\"Thêm mới Customer: {1}\" class=\"add\" href=\"#{0}\">\r\n",
                    tempCustomer.ID, tempCustomer.UserName);
                strTool.Append(
                    "        <img border=\"0\" title=\"Thêm mới Customer\" src=\"/Content/Admin/images/gridview/add.gif\">\r\n");
                strTool.Append("    </a>");
            }
            if (edit)
            {
                strTool.AppendFormat("    <a title=\"Chỉnh sửa: {1}\" class=\"edit\" href=\"#{0}\">\r\n",
                    tempCustomer.ID, tempCustomer.UserName);
                strTool.Append(
                    "        <img border=\"0\" title=\"Sửa Customer\" src=\"/Content/Admin/images/gridview/edit.gif\">\r\n");
                strTool.Append("    </a>");
            }
            if (show)
            {
                if (tempCustomer.IsPublish == false)
                {
                    strTool.AppendFormat("    <a title=\"Ẩn: {1}\" href=\"#{0}\" class=\"hide\">\r\n", tempCustomer.ID,
                        tempCustomer.UserName);
                    strTool.Append(
                        "        <img border=\"0\" title=\"Đang hiển thị\" src=\"/Content/Admin/images/gridview/show.gif\">\r\n");
                    strTool.Append("    </a>\r\n");
                }
                else
                {
                    strTool.AppendFormat("    <a title=\"Hiển thị: {1}\" href=\"#{0}\" class=\"show\">\r\n",
                        tempCustomer.ID, tempCustomer.UserName);
                    strTool.Append(
                        "        <img border=\"0\" title=\"Đang ẩn\" src=\"/Content/Admin/images/gridview/hide.gif\">\r\n");
                    strTool.Append("    </a>\r\n");
                }
            }
            if (delete)
            {
                strTool.AppendFormat("    <a title=\"Xóa: {1}\" href=\"#{0}\" class=\"delete\">\r\n", tempCustomer.ID,
                    tempCustomer.UserName);
                strTool.Append(
                    "        <img border=\"0\" title=\"Xóa Customer\" src=\"/Content/Admin/images/gridview/delete.gif\">\r\n");
                strTool.Append("    </a>\r\n");
            }

            if (order)
            {
                strTool.AppendFormat(
                    "    <a title=\"Sắp xếp các category con: {1}\" href=\"#{0}\" class=\"sort\">\r\n",
                    tempCustomer.ParentID, tempCustomer.UserName);
                strTool.Append(
                    "        <img border=\"0\" title=\"Xắp xếp Customer\" src=\"/Content/Admin/images/gridview/sort.gif\">\r\n");
                strTool.Append("    </a>\r\n");
            }

            strTool.AppendFormat("<div class=\"ShowDetailAccHome\">");
            strTool.Append("<div class=\"titleAcc " + (tempCustomer.IsAgency ? (tempCustomer.IsLeader ? "Leader" : "Agency") : tempCustomer.RankUser) +
                           "\">Thông tin thành viên</div>");
            strTool.Append("<div class=\"bodyAcc\">");
            strTool.Append("<span><strong>Tên thành viên :</strong><strong>" + tempCustomer.FullName + " (" + tempCustomer.Title + ")</strong></span>");
            strTool.Append("<span class = \"colorrank\"><strong>Hạng NPP :</strong><strong>" +
                           (tempCustomer.IsAgency
                               ? (tempCustomer.IsLeader ? "Leader" : "Agency")
                               : (tempCustomer.RankNows.Level < 4 ? tempCustomer.RankUser : "Pro")) + "</strong></span>");
            strTool.Append("<span><strong>Cấp bậc :</strong><strong>" + tempCustomer.RankUser + "</strong></span>");
            strTool.Append("<span><strong>Chu Kỳ :</strong><strong>" + (int)tempCustomer.RankNows.CycleNumberHome +
                           "</strong></span>");
            strTool.Append("<span><strong>Nhánh A :</strong><strong>" + (int)tempCustomer.RankNows.PricePVUser +
                           " PV</strong></span>");
            strTool.Append("<span><strong>Nhánh B :</strong><strong>" + (int)tempCustomer.RankNows.PricePVUser1 +
                           " PV</strong></span> </div> </div>");
            strTool.Append("</div>\r\n");
            return strTool.ToString();
        }

        #endregion

        /// <summary>
        /// get all list customer with delete dafault is false
        /// </summary>
        /// <param name="delete"></param>
        /// <returns></returns>


        public List<RankNowItem> GetAdminAllSimple()
        {
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var query = (from c in FDIDB.RankNows
                         where c.DateCreated > date && c.ActiveRank > 0 && c.Level > 0
                         select new RankNowItem
                         {
                             ID = c.ID,
                             Customer = new CustomerItem
                             {
                                 ID = c.ID,
                                 FullName = c.Customer.FullName,
                                 UserName = c.Customer.UserName,
                                 Mobile = c.Customer.Mobile,
                                 Title = c.Customer.Title

                             },
                             ActiveRank = c.ActiveRank,
                             LevelId = c.Rank.Name,
                             IsAward = c.IsAward,
                             CheckLimit = c.CheckLimit,
                             PricePVNow = c.PricePVNow,
                             IsPay = c.IsPay,
                             IsPay40 = c.IsPay40
                         }).ToList();
            return query;
        }

        public List<CustomerItem> GetAllPerenteen(int id, int level)
        {
            var idstring = id.ToString();
            var ids = ',' + idstring + ',';
            var idss = ',' + idstring;
            var query = (from c in FDIDB.Customers
                         where c.Level < level && c.IsDelete == false && c.IsActive == true && (c.ID == id || c.ListCustomerId.Contains(ids) || c.ListCustomerId.Contains(idss))
                         select new CustomerItem
                         {
                             ID = c.ID,
                             UserName = c.UserName,
                             FullName = c.FullName,
                             ParentID = c.ParentID,
                             IsActive = c.IsActive,
                             ListCustomerId = c.ListCustomerId,
                             Level = c.Level.Value,
                             RankName = c.RankNows.Any() ? c.RankNows.FirstOrDefault().Rank.Name : "NPP",
                             IsNext = c.Level == level - 1
                         }).ToList();
            return query;
        }

        public List<CustomerItem> GetAlllargerGold()
        {
            var query = (from c in FDIDB.RankNows
                         where c.CustomerID > 1 && c.Level > 5
                         select new CustomerItem
                         {
                             ID = c.ID,
                             CustomerID = c.CustomerID,
                             IsPublish = c.Customer.IsPublish,
                             LevelId = c.Level,
                             RankUser = c.Rank.Name,
                         }).ToList();
            return query;
        }

        public void TotalPVParentId(string lstid, decimal pricepv)
        {
            FDIDB.TotalPVParentId(lstid, pricepv);
        }

        public Customer GetCustomerByUserName(string user)
        {
            var query = (from c in FDIDB.Customers
                         where c.IsDelete == false && c.UserName.Equals(user) //|| c.Email.Contains(KeywordEmail)
                         select c).FirstOrDefault();
            return query;
        }

        public List<CustomerItem> GetAllListSimple()
        {
            var query = from c in FDIDB.Customers
                        select new CustomerItem
                        {
                            ID = c.ID,
                           
                        };
            return query.ToList();
        }

        public string GetListCustomerId(int id)
        {
            var query = from c in FDIDB.Customers
                        where c.IsDelete == false && c.ID == id
                        select c.ListCustomerId;
            return query.FirstOrDefault();
        }

        public bool CheckUserName(string username)
        {
            var query = from c in FDIDB.Customers
                        where c.UserName.ToLower().Equals(username.ToLower())
                        select c;
            return query.Any();

        }

        /// <summary>
        /// Lấy về kiểu đơn giản, phân trang
        /// </summary>
        /// <param name="httpRequest"> </param>
        /// <param name="delete"> </param>
        /// <param name="isActive"></param>
        /// <returns>Danh sách bản ghi</returns>
        public List<CustomerItem> GetListSimpleByRequest(HttpRequestBase httpRequest, bool isActive)
        {
            Request = new ParramRequest(httpRequest);
            var query = from c in FDIDB.Customers
                        where c.IsDelete == false && c.IsActive == isActive && c.ID>1
                        orderby c.CreatedOnUtc descending
                        select new CustomerItem
                        {
                            ID = c.ID,
                            FullName = c.FullName,
                            PeoplesIdentityReward = c.PeoplesIdentityReward,
                            Mobile = c.Mobile,
                            UserName = c.UserName,
                            Email = c.Email,
                            DistributorID = c.DistributorID,
                            IdentityType = c.IdentityType.HasValue ? c.IdentityType : c.Custome_RankCustomer.Any(m => m.PricePV > 0) ? 0 : c.IdentityType,
                            //RankNows = c.RankNows.Select(o => new RankNowItem
                            //{
                            //    LevelId = o.Rank.Name,
                            //}).FirstOrDefault(),
                            IsDelete = c.IsDelete,
                            IsActive = c.IsActive,
                            CreatedOnUtc = c.CreatedOnUtc,
                            Title = c.Title,
                            PeoplesIdentity = c.PeoplesIdentity,
                            UserNameCD = FDIDB.Customers.FirstOrDefault(m => m.ID == c.ParentID.Value).UserName,

                        };

            try
            {
                if (!string.IsNullOrEmpty(httpRequest["fromCreateDate"]))
                {
                    var formDate = Convert.ToDateTime(httpRequest["fromCreateDate"]);
                    var Before2Month2 = DateTime.Now.AddMonths(-2);
                    if (formDate < Before2Month2)
                    {
                        formDate = Before2Month2;
                    }
                    query = query.Where(c => c.CreatedOnUtc >= formDate);
                }

                if (!string.IsNullOrEmpty(httpRequest["toCreateDate"]))
                {
                    var toDate = Convert.ToDateTime(httpRequest["toCreateDate"]);
                    query = query.Where(c => c.CreatedOnUtc <= toDate);
                }

                if (!string.IsNullOrEmpty(httpRequest["typeCustomer"]))
                {
                    var type = Int32.Parse(httpRequest["typeCustomer"]);
                    query = query.Where(c => c.CustomerTypeID == type);
                }

                //phuocnh 28/5/2015
                //loc dieu kien sua cmnd nhan thuong
                if (!string.IsNullOrEmpty(httpRequest["PeoplesIdentityChange"]))
                {
                    var type = httpRequest["PeoplesIdentityChange"];
                    if (type == "PeoplesIdentityChange")
                        query = query.Where(c => c.PeoplesIdentityReward != c.PeoplesIdentity && c.PeoplesIdentityReward != null);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Instance.LogError(GetType(), ex);
            }

            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<Customer> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.Customers where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }

        ///phuocnh
        /// <summary>
        /// Lấy về danh sách customer theo id distributor
        /// </summary>
        /// <param name="Id">Id distributor</param>
        /// <returns>Danh sách customer</returns>
        /// 
        public List<Customer> GetListByIdDistributor(int Id)
        {
            var query = from c in FDIDB.Customers where c.DistributorID == Id select c;
            return query.ToList();
        }
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="customerId">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public Customer GetById(int customerId)
        {
            var query = from c in FDIDB.Customers where c.ID == customerId select c;
            return query.FirstOrDefault();
        }

        public string GetUserNameById(int customerId)
        {
            var query = from c in FDIDB.Customers where c.ID == customerId select c.UserName;
            return query.FirstOrDefault();
        }

        public Customer GetByUserName(string username)
        {
            var query = from c in FDIDB.Customers where c.UserName.ToLower() == username.ToLower() select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public decimal GetTotalPvByUserName(String userName, out bool check)
        {
            var query = from c in FDIDB.Customers
                        where c.UserName == userName
                        select new CustomerItem
                        {
                            TotalPricePv = c.Custome_RankCustomer.Where(m => m.IsDeleted == false).Sum(m => m.PricePV)
                        };
            check = query.Any();
            var firstOrDefault = query.FirstOrDefault();

            return (firstOrDefault != null && firstOrDefault.TotalPricePv.HasValue) ? firstOrDefault.TotalPricePv.Value : 0;

        }

        public string GetUserById(int id)
        {
            var query = from c in FDIDB.Customers where c.ID == id select c.UserName;
            return query.FirstOrDefault();
        }
        public void UpRankNpp(decimal price, int id)
        {
            FDIDB.UpRankNPP();
            FDIDB.InsertHHGroup(price, id);
        }

        public List<CustomerItem> GetListCustomerByTang(string ID, int level)
        {
            var query = from c in FDIDB.Customers
                        where (c.ListCustomerId2.Contains(ID) || c.ListCustomerId2.Contains("," + ID) || c.ListCustomerId2.Contains(ID + ",") || c.ListCustomerId2.Contains("," + ID + ",")) && c.Level2 == level && c.IsActive == true && c.IsDelete == false
                        select new CustomerItem
                        {
                            UserName = c.UserName,
                            FullName = c.FullName,
                            //RankUser = c.RankNows.Any() ? c.RankNows.FirstOrDefault().LevelId : "0",
                            Avatar = new PictureItem
                            {
                                Url = c.Gallery_Picture.Folder + c.Gallery_Picture.Url
                            },
                        };

            return query.ToList();
        }

        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="customerId">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public CustomerItem GetCustomerItemById(int customerId)
        {
            var query = from c in FDIDB.Customers
                        where c.ID == customerId
                        select new CustomerItem
                        {
                            ID = c.ID,
                            UserName = c.UserName,
                            FullName = c.FullName,
                            Email = c.Email,
                            Gender = c.Gender,
                            Birthday = c.Birthday,
                            Password = c.Password,
                            Level2 = c.Level2 ?? 0,
                            IsDelete = c.IsDelete,
                            Mobile = c.Mobile,
                            CustomerAvatarID = c.CustomerAvatarID ?? 0,
                            ListCustomerId = c.ListCustomerId,
                            ProvincialAgencyID = c.ProvincialAgencyID,
                            PeoplesIdentityReward = c.PeoplesIdentityReward,
                            Level = c.Level.Value,
                            CreatedOnUtc = c.CreatedOnUtc,

                            CustomerAvatarId = c.CustomerAvatarID,
                            Avatar = new PictureItem
                            {
                                Name = c.Gallery_Picture.Name,
                                Url = c.Gallery_Picture.Folder + c.Gallery_Picture.Url
                            },
                            LevelId = c.RankNows.FirstOrDefault().Level,
                            DistrictId = c.DistrictID,
                            CityId = c.CityID,
                            CountryId = c.CountryID,
                            IsActive = c.IsActive,
                        };

            var result = query.FirstOrDefault();

            if (result != null && result.CountryId.HasValue)
                result.Country = _systemCountryDA.GetCountryItemById(result.CountryId.Value);
            if (result != null && result.CityId.HasValue)
                result.City = _systemCityDA.GetCityItemById(result.CityId.Value);
            if (result != null && result.DistrictId.HasValue)
                result.District = _systemDistrictDA.GetDistrictItemById(result.DistrictId.Value);
            return result;
        }

        public bool CheckExitsByUserName(string username, int customer)
        {
            var query = from c in FDIDB.Customers
                        where c.UserName.Equals(username) && c.IsDelete == false && c.ID != customer
                        select c.ID;
            return query.Any();
        }

        public bool CheckExitsUserName(string username)
        {
            var query = from c in FDIDB.Customers
                        where c.UserName.Equals(username) && c.IsDelete == false && c.Custome_RankCustomer.Any()
                        select new CustomerItem
                        {
                            IsRank = c.Custome_RankCustomer.Sum(m => m.PricePV) >= 2750
                        };
            var firstOrDefault = query.FirstOrDefault();
            return (firstOrDefault != null && firstOrDefault.IsRank);
        }

        public CustomerItem CheckExitsGT(string usernamecd)
        {
            var query = from c in FDIDB.Customers
                        where c.UserName.Equals(usernamecd) && c.IsDelete == false
                        select new CustomerItem
                        {
                            ID = c.ID,
                            ListCustomerId = c.ListCustomerId
                        };
            return query.FirstOrDefault();
        }

        public CustomerItem GetUserNameBy(string usernamecd)
        {
            var query = from c in FDIDB.Customers
                        where (c.PeoplesIdentity.Equals(usernamecd) || c.Title.Equals(usernamecd)) && c.IsDelete == false
                        select new CustomerItem
                        {
                            ID = c.ID,
                            UserName = c.UserName,
                            ParentID = c.ParentID,
                            CustomerID = c.CustomerID
                        };
            return query.FirstOrDefault();
        }

        public CustomerItem CheckExitsCD(string usernamecd)
        {
            var query = from c in FDIDB.Customers
                        where c.UserName.Equals(usernamecd) && c.IsDelete == false
                        select new CustomerItem
                        {
                            ID = c.ID,
                            ListCustomerId = c.ListCustomerId,
                            IsAdd = c.IsActive != true || c.RankNows.FirstOrDefault().UserId == 0 || c.RankNows.FirstOrDefault().UserId1 == 0
                        };

            return query.FirstOrDefault();
        }

        public CustomerItem CheckExitsUserCD(int id)
        {
            var query = from c in FDIDB.Customers
                        where c.ID == id && c.IsDelete == false && c.IsActive == true
                        //&& (c.RankNows.FirstOrDefault().UserId == 0 || c.RankNows.FirstOrDefault().UserId1 == 0)
                        select new CustomerItem
                        {
                            ID = c.ID,
                            ListCustomerId = c.ListCustomerId,
                        };

            return query.FirstOrDefault();
        }

        public CustomerItem CheckExitsUserGT(int id)
        {
            var query = from c in FDIDB.Customers
                        where c.ID == id && c.IsDelete == false && c.IsActive == true
                        select new CustomerItem
                        {
                            ID = c.ID,
                            ListCustomerId = c.ListCustomerId,
                            ListCustomerId2 = c.ListCustomerId2,
                            Level2 = c.Level2 ?? 0,
                            Level = c.Level.HasValue ? c.Level.Value : 0
                        };

            return query.FirstOrDefault();
        }

        public int GetIdByUserName(string username)
        {
            var query = from c in FDIDB.Customers
                        where c.UserName.Equals(username) && c.IsDelete == false
                        select c.ID;
            return query.Any() ? query.FirstOrDefault() : 0;
        }

        public bool CheckExitsByUserName(string username)
        {
            var query = from c in FDIDB.Customers
                        where c.PeoplesIdentity.Equals(username) && c.IsDelete == false
                        select c.ID;
            return query.Any();
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="customer"> </param>
        public void Add(Customer customer)
        {
            FDIDB.Customers.Add(customer);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        public void Delete(Customer customer)
        {
            FDIDB.Customers.Remove(customer);
        }

        /// <summary>
        /// save bản ghi vào DB
        /// </summary>
        public void Save()
        {

            FDIDB.SaveChanges();
        }

        public List<CustomerItem> GetListSimpleByAutoComplete(string keyword, int showLimit)
        {
            var query = from c in FDIDB.Customers
                        orderby c.UserName
                        where c.UserName.Contains(keyword) && c.IsDelete == false && c.IsActive == true && c.IsPublish == false
                        select new CustomerItem
                        {
                            ID = c.ID,
                            UserName = c.UserName

                        };
            return query.Take(showLimit).ToList();
        }

        public List<CustomerItem> GetListSixLevel(List<int> list, int? level)
        {
            var query = from c in FDIDB.Customers
                        where c.IsDelete == false && c.IsActive == true && list.Contains(c.ID) && c.Level > level - 7
                        select new CustomerItem
                        {
                            ID = c.ID,
                            LevelId = level - c.Level
                        };
            return query.ToList();
        }
    }
}
