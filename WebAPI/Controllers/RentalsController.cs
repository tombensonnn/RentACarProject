using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _rentalService.Get(id);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
