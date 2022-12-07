using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new ProductManager(new EfProductDal());
            List<Product> products = productService.GetByUnitPriceMin(100);
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName + " : " + product.UnitPrice + " USD");
            }
        }
    }
}