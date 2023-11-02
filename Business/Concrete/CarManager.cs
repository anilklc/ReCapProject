using Business.Abstract;
using Business.Constants;
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
        public void Add(Car car)
        {
            if (car.Name.Length >= 2 & car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine(Messages.CarAdd);
            }
            else 
            { 
            Console.WriteLine(Messages.CarError);
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c=>c.Id==id);
        }

        public List<CarDetailDto> GetDto()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
             _carDal.Update(car);
        }
    }
}
