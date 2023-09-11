using Business.Abstract;
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

        [HttpPost("addCarImage")]
        public IActionResult CarImageAdd([FromForm (Name = "image")] IFormFile formFile, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(formFile, carImage);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("deleteCarImage")]
        public IActionResult DeleteCarImage(int carImageId)
        {
            var result = _carImageService.Delete(carImageId);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("updateCarImage")]
        public IActionResult UpdateCarImage([FromForm] IFormFile formFile, CarImage carImage)
        {
            var result = _carImageService.Update(formFile, carImage);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("getCarImage")]
        public IActionResult GetCarImage(int carImageId)
        {
            var result = _carImageService.Get(carImageId);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("getAllCarImages")]
        public IActionResult GetAllCarImages()
        {
            var result = _carImageService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
