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
    public class DistributorDA : BaseDA
    {
        #region Constructer
        public DistributorDA()
        {

        }
        public List<Distributor> GetListByArrID(List<int> ltsArrID)
        {
            var query = from c in FDIDB.Distributors where ltsArrID.Contains(c.ID) select c;
            return query.ToList();
        }
        public DistributorDA(string pathPaging)
        {
            PathPaging = pathPaging;

        }

        public DistributorDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;

        }
        #endregion


        public List<DistributorItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            var query2 = from c in FDIDB.Distributors
                         orderby c.ID
                         where c.ID == 2959 && c.Customers.Any(m => !m.IsDistributor.HasValue)
                         select c;
            var b = query2.ToList();


            Request = new ParramRequest(httpRequest);
            var query = from c in FDIDB.Distributors
                        orderby c.ID
                        select new DistributorItem
                        {
                            ID = c.ID,
                            Address = c.Address,
                            Avartar = c.Avartar,
                            BankCode = c.BankCode,
                            BankName = c.BankName,
                            Birthday = c.Birthday,
                            Customers = c.Customers,
                            Email = c.Email,
                            FullName = c.FullName,
                            IsActive = c.IsActive,
                            Mobile = c.Mobile,
                            PeoplesIdentity = c.PeoplesIdentity,
                            CodeContract = c.CodeContract,

                            PictureItem1 = new PictureItem
                            {
                                ID = c.Gallery_Picture1 == null ? 0 : c.Gallery_Picture1.ID,
                                Folder = c.Gallery_Picture1.Folder,
                                Url = c.Gallery_Picture1.Url
                            },
                            PictureItem2 = new PictureItem
                            {
                                ID = c.Gallery_Picture2 == null ? 0 : c.Gallery_Picture2.ID,
                                Folder = c.Gallery_Picture2.Folder,
                                Url = c.Gallery_Picture2.Url
                            },
                            PictureItem = new PictureItem
                            {
                                ID = c.Gallery_Picture == null ? 0 : c.Gallery_Picture.ID,
                                Folder = c.Gallery_Picture.Folder,
                                Url = c.Gallery_Picture.Url
                            }

                        };

            int id = 1;
            if (!string.IsNullOrEmpty(httpRequest.QueryString["status"]))
            {
                id = int.Parse(httpRequest.QueryString["status"]);
            }
            if (id == 1)
            {
                query = query.Where(m => m.IsActive == true && m.Customers.Any(c => !c.IsDistributor.HasValue || (c.IsDistributor == false)));
            }
            else if (id == 2)
            {
                query = query.Where(m => m.IsActive == true && !m.Customers.Any(c => !c.IsDistributor.HasValue || (c.IsDistributor == false)));
            }
            else if (id == 3)
            {
                query = query.Where(m => m.IsActive == false);
            }
            if (!string.IsNullOrEmpty(httpRequest.QueryString["SearchIn"]) && httpRequest.QueryString["SearchIn"].Contains("ID"))
            {
                var userName = httpRequest.QueryString["Keyword"] ?? "";
                //query = query.Where(m => m.Customers.Any(c => c.UserName.Contains(userName) || (c.Title != null && c.Title.Contains(userName))));
                //return query.ToList();

                var d = query.ToList().Where(m => m.Customers.Any(c => c.UserName.Contains(userName) || (c.Title != null && c.Title.Contains(userName))));
                return d.ToList();
                //mat phan trang
                //query = query.SelectByRequest(Request, ref TotalRecord);
            }
            else
            {
                query = query.SelectByRequest(Request, ref TotalRecord);
            }

            //query = query.OrderBy(m=>m.ID);
            return query.ToList();
        }

        public List<Customer> GetAllCustomer(int distributorID)
        {
            var query = from c in FDIDB.Customers
                        where c.DistributorID == distributorID
                        select c;
            return query.ToList();
        }

        public Distributor GetByID(int id)
        {
            var query = from c in FDIDB.Distributors
                        where c.ID == id
                        select c;
            return query.FirstOrDefault();

        }
        //lay ban ghi thua khong co customer
        public List<Distributor> GetDistributors()
        {
            var query = from c in FDIDB.Distributors
                        where c.Customers.Count == 0
                        select c;
            return query.ToList();

        }

        public CustomerItem GetByCustomerID(int id)
        {
            var query = from c in FDIDB.Customers
                        where c.ID == id
                        select new CustomerItem
                        {
                            IsDistributor = c.IsDistributor,
                            DistributorID = c.DistributorID
                        };
            return query.FirstOrDefault();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="peoplesIdentity"></param>
        /// <returns></returns>
        public bool CheckExitsByPeoplesIdentity(string peoplesIdentity)
        {
            var query = from c in FDIDB.Distributors
                        where c.PeoplesIdentity.Equals(peoplesIdentity)
                        select c.ID;
            return query.Any();

        }
        public Distributor GetByBeoplesIdentity(string peoplesIdentity)
        {
            var query = from c in FDIDB.Distributors
                        where c.PeoplesIdentity.Equals(peoplesIdentity)
                        select c;
            return query.FirstOrDefault();

        }
        public bool CheckExitsByPeoplesIdentity(string peoplesIdentity, int id)
        {
            var query = from c in FDIDB.Customers
                        where c.ID != id && c.Distributor.PeoplesIdentity.Equals(peoplesIdentity)
                        select c.ID;
            return query.Any();

        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="distributor"> </param>
        public void Add(Distributor distributor)
        {
            FDIDB.Distributors.Add(distributor);
        }

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        public void Delete(Distributor distributor)
        {
            FDIDB.Distributors.Remove(distributor);
        }

        /// <summary>
        /// save bản ghi vào DB
        /// </summary>
        public void Save()
        {
            FDIDB.SaveChanges();
        }

    }
}
