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
    public class SystemMessageTemplateDa : BaseDA
    {
        #region Constructer
        public SystemMessageTemplateDa()
        {
        }

        public SystemMessageTemplateDa(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public SystemMessageTemplateDa(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }
        #endregion

        /// <summary>
        /// Lấy về tất cả kiểu đơn giản
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
        public List<SystemMessageTemplateItem> GetListSimpleAll()
        {
            var query = from c in FDIDB.System_MessageTemplate
                        orderby c.Name
                        select new SystemMessageTemplateItem
                                   {
                                       ID = c.ID,
                                       Name = c.Name.Trim()
                                   };
            return query.ToList();
        }

        /// <summary>
        /// Lấy về dưới dạng Autocomplete
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="showLimit"></param>
        /// <returns></returns>
        public List<SystemMessageTemplateItem> GetListSimpleByAutoComplete(string keyword, int showLimit)
        {
            var query = from c in FDIDB.System_MessageTemplate
                        orderby c.Name
                        where c.Name.StartsWith(keyword)
                        select new SystemMessageTemplateItem
                                   {
                                       ID = c.ID,
                                       Name = c.Name.Trim()
                                   };
            return query.Take(showLimit).ToList();
        }

        /// <summary>
        /// Lấy về kiểu đơn giản, phân trang
        /// </summary>
        /// <param name="httpRequest"> </param>
        /// <returns>Danh sách bản ghi</returns>
        public List<SystemMessageTemplateItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);
            var query = from o in FDIDB.System_MessageTemplate
                        select new SystemMessageTemplateItem
                                   {
                                       ID = o.ID,
                                       Name = o.Name.Trim(),
                                       IsActive = o.IsActive,
                                       Subject = o.Subject,
                                       BodyContent = o.BodyContent,
                                       BccEmail = o.BccEmail,
                                       IsDeleted = o.IsDeleted,
                                       EmailAccountId = o.EmailAccountId
                                   };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();
        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="ltsArrID"></param>
        /// <returns></returns>
        public List<SystemMessageTemplateItem> GetListSimpleByArrID(List<int> ltsArrID)
        {
            var query = from o in FDIDB.System_MessageTemplate
                        where ltsArrID.Contains(o.ID)
                        orderby o.ID descending
                        select new SystemMessageTemplateItem
                                   {
                                       ID = o.ID,
                                       Name = o.Name.Trim(),
                                       IsActive = o.IsActive,
                                       Subject = o.Subject,
                                       BodyContent = o.BodyContent,
                                       BccEmail = o.BccEmail,
                                       IsDeleted = o.IsDeleted,
                                       EmailAccountId = o.EmailAccountId
                                   };
            TotalRecord = query.Count();
            return query.ToList();
        }

        /// <summary>
        /// Lấy về mảng đơn giản qua mảng ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SystemMessageTemplateItem GetSystemConfigItemById(int id)
        {
            var query = from o in FDIDB.System_MessageTemplate
                        where o.ID == id
                        orderby o.ID descending
                        select new SystemMessageTemplateItem
                                   {
                                       ID = o.ID,
                                       Name = o.Name.Trim(),
                                       IsActive = o.IsActive,
                                       Subject = o.Subject,
                                       BodyContent = o.BodyContent,
                                       BccEmail = o.BccEmail,
                                       IsDeleted = o.IsDeleted,
                                       EmailAccountId = o.EmailAccountId
                                   };
            return query.FirstOrDefault();
        }

        #region Check Exits, Add, Update, Delete
        /// <summary>
        /// Lấy về bản ghi qua khóa chính
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <returns>Bản ghi</returns>
        public System_MessageTemplate GetById(int id)
        {
            var query = from c in FDIDB.System_MessageTemplate where c.ID == id select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Lấy về danh sách qua mảng id
        /// </summary>
        /// <param name="ltsArrID">Mảng ID</param>
        /// <returns>Danh sách bản ghi</returns>
        public List<System_MessageTemplate> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.System_MessageTemplate where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }

        /// <summary>
        /// Kiểm tra bản ghi đã tồn tại hay chưa
        /// </summary>
        /// <param name="systemConfig">Đối tượng kiểm tra</param>
        /// <returns>Trạng thái tồn tại</returns>
        public bool CheckExits(System_MessageTemplate systemMessageTemplate)
        {
            var query = from c in FDIDB.System_MessageTemplate where ((c.Name == systemMessageTemplate.Name) && (c.ID != systemMessageTemplate.ID)) select c;
            return query.Any();
        }

        /// <summary>
        /// Lấy về bản ghi qua tên
        /// </summary>
        /// <param name="name">Tên bản ghi</param>
        /// <returns>Bản ghi</returns>
        public System_MessageTemplate GetByName(string name)
        {
            var query = from c in FDIDB.System_MessageTemplate where ((c.Name == name)) select c;
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="systemConfig"> bản ghi cần thêm</param>
        public void Add(System_MessageTemplate systemMessageTemplate)
        {
            FDIDB.System_MessageTemplate.Add(systemMessageTemplate);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="systemConfig">Xóa bản ghi</param>
        public void Delete(System_MessageTemplate systemMessageTemplate)
        {
            FDIDB.System_MessageTemplate.Remove(systemMessageTemplate);
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
