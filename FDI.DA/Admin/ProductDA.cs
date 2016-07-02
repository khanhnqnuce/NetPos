using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FDI.Base;
using FDI.Simple;

namespace FDI.DA.Admin
{
    public class ProductDA : BaseDA
    {
        public ProductDA()
        {
        }

        public ProductDA(string pathPaging)
        {
            PathPaging = pathPaging;
        }

        public ProductDA(string pathPaging, string pathPagingExt)
        {
            PathPaging = pathPaging;
            PathPagingext = pathPagingExt;
        }

        public List<ProductItem> GetListSimpleByRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);

            var query = from o in FDIDB.Shop_Product
                        where o.IsDelete == false
                        select new ProductItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow,
                            CreateBy = o.CreateBy,
                            UpdateBy = o.UpdateBy,
                            CreatedOnUtc = o.CreatedOnUtc,
                            PriceNew = o.PriceNew,
                            PriceOld = o.PriceOld
                        };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();

        }
        
        
        public List<OrderItem> GetListOrderRequest(HttpRequestBase httpRequest)
        {
            Request = new ParramRequest(httpRequest);

            var query = from o in FDIDB.Orders
                        where o.IsDelete == false
                        select new OrderItem
                        {
                            ID = o.ID,
                            CustomerName = o.Customer.FullName,
                            CustomerId = o.CustomerId,
                            IsShow = o.IsShow,
                            DateCreated = o.DateCreated,
                            Price = o.OrderDetails.Sum(c => c.Quantity * c.Price),
                            IsActive = o.IsActive??false
                        };
            query = query.SelectByRequest(Request, ref TotalRecord);
            return query.ToList();

        }

        public ProductItem GetBySimpleId(int id)
        {
            var query = from o in FDIDB.Shop_Product
                        where o.ID == id
                        select new ProductItem
                        {
                            ID = o.ID,
                            Name = o.Name,
                            IsShow = o.IsShow,
                            CreateBy = o.CreateBy,
                            UpdateBy = o.UpdateBy,
                            CreatedOnUtc = o.CreatedOnUtc,
                            PriceNew = o.PriceNew,
                            PriceOld = o.PriceOld
                        };
            return query.FirstOrDefault();
        }

        public List<Shop_Product> Get(List<int> lst)
        {
            var query = from c in FDIDB.Shop_Product where lst.Contains(c.ID) select c;
            return query.ToList();
        }
        
        public Shop_Product Get(int id)
        {
            var query = from c in FDIDB.Shop_Product where c.ID == id select c;
            return query.FirstOrDefault();
        }

        public Order GetOrder(int id)
        {
            var query = from c in FDIDB.Orders where c.ID == id select c;
            return query.FirstOrDefault();
        }

        public List<OrderItem> GetOrder()
        {
            var query = from o in FDIDB.Orders 
                        where o.IsDelete == false
                        select new OrderItem
                        {
                            ID = o.ID,
                             IsShow = o.IsShow,
                             DateCreated = o.DateCreated,
                             Price = o.OrderDetails.Sum(c=>c.Quantity*c.Price)
                        };
            return query.ToList();
        }

        public void Add(Shop_Product item)
        {
            FDIDB.Shop_Product.Add(item);
        }

        public void Delete(Shop_Product item)
        {
            FDIDB.Shop_Product.Remove(item);
        }

        public void Save()
        {
            FDIDB.SaveChanges();
        }
    }
}
