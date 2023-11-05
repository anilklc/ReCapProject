using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() 
        {
            var result= _carService.GetAll();
            if (result.Success) 
            {
                return Ok(result);
            }
            else 
            { 
                return BadRequest(result.Message); 
            }
        }
        [HttpGet("GetId")]
        public IActionResult GetId(int id) 
        { 
            var result=_carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult Add(Car car) 
        {
          return Ok(_carService.Add(car));
           
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_carService.Delete(id));
        }

        [HttpPut("Update")]
        public IActionResult Update(Car car) 
        {
            var result=_carService.Update(car);
            if (result.Success) 
            {
                return Ok(result);
            }
            else 
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("GetDto")]
        public IActionResult GetDto() {
        
        return Ok(_carService.GetDto());
        
        }

    }
}
