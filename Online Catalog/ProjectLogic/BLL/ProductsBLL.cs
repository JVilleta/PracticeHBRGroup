using System.Collections.Generic;
using ProjectLogic.DAL;
using ProjectLogic.BLL.Entities;

namespace ProjectLogic.BLL
{
    public class ProductsBLL
    {
        private readonly ProductsDAL _context;

       public ProductsBLL(ProductsDAL context)
       {
            _context = context;
       }

        public List<dtProducts> GetProducts()
        {
            return _context.GetProducts();
        }
        public dtProducts GetProductByID(int productID)
        {
            return _context.GetProductsByID(productID);
        }
        public List<dtProducts> GetProductsByCategoryID(int IdCategory) 
        {
            return _context.GetProductsByCategoryID(IdCategory);
        }
        public List<dtProducts> GetProductsByName(string ProductName)
        {
            return _context.GetProductsByName(ProductName);
        }
        public bool AddProduct(dtProducts products, string author = "")
        {
            products.Author = author;
            return _context.AddProduct(products);
        }
        public bool UpdateProduct(dtProducts products, string author = "") 
        {
            products.Author = author;
            return _context.UpdateProduct(products);
        }
        public bool DeleteProduct(int id)
        {
            return _context.DeleteProduct(id);
        }
    }

}
