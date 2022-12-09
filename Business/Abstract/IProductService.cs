using Core.Utilities.Results;
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
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int categoryId);
        IDataResult<List<Product>> GetByUnitPrice(double min, double max);
        IDataResult<List<Product>> GetByUnitPriceMin(double min);
        IDataResult<List<Product>> GetByUnitPriceMax(double max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
    }
}
