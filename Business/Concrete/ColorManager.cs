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
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(int id)
        {  
            var color = _colorDal.Get(c => c.Id == id);
            if (color != null)
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDelete);
            }
            else
            {
                return new ErrorResult(Messages.ColorNotDelete);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new DataResult<List<Color>>(_colorDal.GetAll(),true,Messages.ColorGetAll);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new DataResult<Color>(_colorDal.Get(c=>c.Id==id),true,Messages.ColorListedById);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
