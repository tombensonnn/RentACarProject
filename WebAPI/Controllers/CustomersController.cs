using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _customerService.Get(id);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("getcustomerdetails")]
        public IActionResult GetCustomerDetails(int id)
        {
            var result = _customerService.GetCustomerDetails(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
