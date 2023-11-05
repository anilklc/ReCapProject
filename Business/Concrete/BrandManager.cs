using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        
        public BrandManager(IBrandDal brandDal)
        {
             _brandDal= brandDal;
        }
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(int id)
        {
            var brand = _brandDal.Get(b => b.Id == id);
            if (brand != null)
            {
                _brandDal.Delete(brand);
                return new SuccessResult(Messages.BrandDelete);
            }
            else
            {
                return new ErrorResult(Messages.BrandNotDelete);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new DataResult<List<Brand>>(_brandDal.GetAll(),true,Messages.BrandGetAll);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new DataResult<Brand>(_brandDal.Get(b=>b.Id==id),true,Messages.BrandListedById);
        }

        public IResult Update(Brand brand)
        {
             _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdate);
        }
    }
}
