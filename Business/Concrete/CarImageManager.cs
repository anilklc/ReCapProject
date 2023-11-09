using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, int carId)
        {
            IResult result = BusinessRules.Run(CheckCarImageLimit(carId));
            if(result != null) 
            { 
                return result;
            }
            CarImage carImage = new CarImage();
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date=DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);

        }

        public IResult Delete(int id)
        {

            var result = _carImageDal.Get(c => c.Id == id);
            if (result != null)
            {
                _carImageDal.Delete(result);
                return new SuccessResult(Messages.CarImageDelete);
            }
            else
            {
                return new ErrorResult(Messages.CarImageNotDelete);
            }
            
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new DataResult<List<CarImage>>(_carImageDal.GetAll(),true,Messages.CarImageAllListed);
        }

        public IDataResult<List<CarImage>> GetCarsId(int id)
        {
            var result = BusinessRules.Run(CheckCarImage(id));
            if(result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(id).Data, false, Messages.CarImageNotFound);
            }
            return new DataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id), true, Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetCarsImageById(int id)
        {
            return new DataResult<CarImage>(_carImageDal.Get(c => c.Id == id), true, Messages.CarImageListed);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdate);
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "wwwroot\\DefaultImage.png" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }
            return new SuccessResult();
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >0) 
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImageNotFound);
        }
    }
}
