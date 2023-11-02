using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (DBContext context = new DBContext())
            {
                var result = from c in context.Cars join b in context.Brands on c.BrandId equals b.Id join clr in context.Colors on c.ColorId equals clr.Id 
                             select new CarDetailDto 
                             {
                                 BrandName = b.BrandName,
                                 Name =c.Name,
                                 ColorName=clr.ColorName,
                                 DailyPrice=c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
