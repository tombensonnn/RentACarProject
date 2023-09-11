﻿using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int userId)
        {
            var result = _userService.GetUserById(userId);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
