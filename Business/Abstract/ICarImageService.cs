﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file,int carId);
        IResult Delete(int id);
        IResult Update(IFormFile file,int id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetCarsImageById(int id);
        IDataResult<List<CarImage>> GetCarsId(int id);
    }
}
