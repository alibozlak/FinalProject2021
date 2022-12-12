using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
//using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
//using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService 
    {
        private IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            // Difference between Validation and Business code <-------------------- Important

            //var unitPrice = product.UnitPrice;
            //if (unitPrice < 0)
            //{
            //    return new ErrorResult(Messages.ProductPriceNotNegative + unitPrice);
            //}

            //ValidationTool.Validate(new ProductValidator(),product);

            this.productDal.Add(product);
            var message = $"{product.ProductName} adlı ürün eklendi";
            return new SuccessResult(message);
        }

        public IDataResult<List<Product>> GetAll()
        {
            // Business codes here ..
            //
            //
            var data = this.productDal.GetAll();
            return new SuccessDataResult<List<Product>>(Messages.ProductListed, data); 
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {
            //
            // 
            var data = this.productDal.GetAll(p => p.CategoryId == categoryId);
            return new SuccessDataResult<List<Product>>(Messages.ProductListed, data);
        }

        public IDataResult<Product> GetById(int productId)
        {
            var data = this.productDal.Get(p => p.ProductId == productId);
            var message = $"ID'si {productId} olan ürün getirildi";
            return new SuccessDataResult<Product>(message,data);
        }

        public IDataResult<List<Product>> GetByUnitPrice(double min, double max)
        {
            var data = this.productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
            return new SuccessDataResult<List<Product>>(Messages.ProductListed, data);
        }

        public IDataResult<List<Product>> GetByUnitPriceMax(double max)
        {
            var data = this.productDal.GetAll(p => p.UnitPrice <= max);
            return new SuccessDataResult<List<Product>>(Messages.ProductListed, data);
        }

        public IDataResult<List<Product>> GetByUnitPriceMin(double min)
        {
            var data = this.productDal.GetAll(p => p.UnitPrice >= min);
            return new SuccessDataResult<List<Product>>(Messages.ProductListed, data);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            var data = this.productDal.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>("Ürün detayları listelendi", data);
        }
    }
}
