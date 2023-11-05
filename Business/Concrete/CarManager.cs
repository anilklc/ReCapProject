﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
       
        private readonly ICarDal _carDal;
       
        public CarManager(ICarDal carDal) 
        {
            _carDal = carDal;
           
            
        }
        public IResult Add(Car car)
        {
            if (car.Name.Length >= 2 & car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else 
            { 
                return new ErrorResult(Messages.CarNotAdded);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new DataResult<List<Car>>(_carDal.GetAll(),true,Messages.CarListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new DataResult<Car>(_carDal.Get(c=>c.Id==id),true,Messages.CarListedById);
        }

        public IDataResult<List<CarDetailDto>> GetDto()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),true,Messages.CarListed);
        }

        public IResult Update(Car car)
        {
             _carDal.Update(car);
             return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(int id)
        {
            var car = _carDal.Get(c => c.Id == id);
            if (car != null)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDelete);
            }
            else
            {
                return new ErrorResult(Messages.CarNotDelete);
            }

        }
    }
}
