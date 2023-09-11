using Business.Abstract;
using Entities.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }//Burayı geçiyorsa,kullanıcı başarıyla giriş yaptı demektir

            var result = _authService.CreateAccessToken(userToLogin.Data);//Kullanıcıya token oluşturuyor
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)//Böyle bir hesap sistemde mevcut mu
            {
                return BadRequest(userExists.Message);
            }

            //Bu noktayı geçtiyse kullanıcı mevcut değil
            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);//Kullanıcı kayıt oldu, User dönderir
            var result = _authService.CreateAccessToken(registerResult.Data);//Token oluşturuldu
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
