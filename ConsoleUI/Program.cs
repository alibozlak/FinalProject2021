using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new ProductManager(new InMemoryProductDal());
            List<Product> products = productService.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName + " : " + product.UnitPrice + " TL");
            }
        }
    }
}