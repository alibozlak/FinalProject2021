using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal 
    {
        private List<Product> _products;

        public InMemoryProductDal()
        {
            _products= new List<Product>()
            {
                new Product() {ProductId= 1,CategoryId = 1, ProductName = "Bardak", UnitPrice = 23, UnitsInStock = 52 },
                new Product() {ProductId= 2,CategoryId = 1, ProductName = "Kamera", UnitPrice = 2350, UnitsInStock = 25 },
                new Product() {ProductId= 3,CategoryId = 2, ProductName = "Telefon", UnitPrice = 3020, UnitsInStock = 6 },
                new Product() {ProductId= 4,CategoryId = 2, ProductName = "Laptop", UnitPrice = 15600, UnitsInStock = 15 },
                new Product() {ProductId= 5,CategoryId = 2, ProductName = "Fare", UnitPrice = 135, UnitsInStock = 5 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product _product = GetRefrenceById(product.ProductId);
            _products.Remove(_product);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            //List<Product> products = new List<Product>();
            //foreach (var product in _products)
            //{
            //    if (product.CategoryId == categoryId)
            //    {
            //        products.Add(product);
            //    }
            //}
            //return products;

            // LINQ :
            return _products.Where(p => p.CategoryId == categoryId).ToList();   // <-- LINQ with Lambda
        }

        public void Update(Product product)
        {
            Product _product = GetRefrenceById(product.ProductId);
            _product.CategoryId = product.CategoryId;
            _product.ProductName = product.ProductName;
            _product.UnitPrice = product.UnitPrice;
            _product.UnitsInStock = product.UnitsInStock;
        }

        private Product GetRefrenceById(int productId)
        {
            foreach (Product product in _products)
            {
                if (product.ProductId == productId)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
