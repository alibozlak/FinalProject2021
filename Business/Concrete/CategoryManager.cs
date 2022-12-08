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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            // Business codes here...
            //
            return this.categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return this.categoryDal.Get(c => c.CategoryId == categoryId);
        }
    }
}
