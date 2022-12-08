using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int categoryId);
        List<Product> GetByUnitPrice(double min, double max);
        List<Product> GetByUnitPriceMin(double min);
        List<Product> GetByUnitPriceMax(double max);

        List<ProductDetailDto> GetProductDetails();
    }
}
