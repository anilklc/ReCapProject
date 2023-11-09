using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("GetAllImage")]
        public IActionResult GetAllImage()
        {
            var result = _carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetByCarId")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImageService.GetCarsId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetByImageId")]
        public IActionResult GetByImageId(int id)
        {
            var result = _carImageService.GetCarsImageById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("AddImage")]
        public IActionResult AddImage(IFormFile formFile,int carId)
        {
            return Ok(_carImageService.Add(formFile,carId));
        }

        [HttpPut("UpdateImage")]
        public IActionResult UpdateColor(IFormFile file, CarImage carImage)
        {
            var result = _carImageService.Update(file,carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("DeleteImage")]
        public IActionResult DeleteImage(int id)
        {
            var result = _carImageService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
