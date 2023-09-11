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
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("getbydailyprice")]
        public IActionResult GetByDailyResult(decimal min, decimal max)
        {
            var result = _carService.GetByDailyPrice(min, max);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _carService.GetByBrandId(brandId);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int carId)
        {
            var result = _carService.Get(carId);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
