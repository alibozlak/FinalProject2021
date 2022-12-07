using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public List<Product> GetAll()
        {
            // Business codes here ..
            //
            //
            return this.productDal.GetAll(); 
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            //
            // 
            return this.productDal.GetAll(p=>p.CategoryId == categoryId);
        }

        public List<Product> GetByUnitPrice(double min, double max)
        {
            return this.productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<Product> GetByUnitPriceMax(double max)
        {
            return this.productDal.GetAll(p => p.UnitPrice <= max);
        }

        public List<Product> GetByUnitPriceMin(double min)
        {
            return this.productDal.GetAll(p => p.UnitPrice >= min);
        }
    }
}
