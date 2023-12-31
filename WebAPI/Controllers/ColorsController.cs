﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("GetAllColor")]
        public IActionResult GetAllColor() 
        {
            var result = _colorService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else 
            { 
                return BadRequest(result.Message); 
            }
        }

        [HttpGet("GetByIdColor")]
        public IActionResult GetByIdColor(int id)
        {
            var result = _colorService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("AddColor")]
        public IActionResult AddColor(Color color)
        {
            return Ok(_colorService.Add(color));
        }

        [HttpPut("UpdateColor")]
        public IActionResult UpdateColor(Color color)
        {
            var result = _colorService.Update(color);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("DeleteColor")]
        public IActionResult DeleteColor(int id)
        {
            var result = _colorService.Delete(id);
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
