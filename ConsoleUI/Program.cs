using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //IProductService productService = new ProductManager(new EfProductDal());
            //List<Product> products = productService.GetByUnitPriceMin(100);
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName + " : " + product.UnitPrice + " USD");
            //}

            //ICategoryService categoryService = new CategoryManager(new EfCategoryDal());
            //List<Category> categories = categoryService.GetAll();
            //foreach (var category in categories)
            //{
            //    Console.WriteLine($"Kategori Adı : {category.CategoryName}, Kategori ID : {category.CategoryId}");
            //}

            //IProductService productService = new ProductManager(new EfProductDal());
            //List<ProductDetailDto> productDetailDtos = productService.GetProductDetails();
            //foreach (var productDetailDto in productDetailDtos)
            //{
            //    Console.WriteLine($"{productDetailDto.ProductName} -> {productDetailDto.CategoryName}");
            //}

            IProductService productService = new ProductManager(new EfProductDal());
            var result = productService.GetAll();
            if (result.IsSuccess)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine($"{product.ProductId} - {product.ProductName} - " +
                        $"{product.UnitPrice} - {product.UnitsInStock}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}