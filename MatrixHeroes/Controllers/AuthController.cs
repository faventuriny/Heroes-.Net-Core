using System.Collections.Generic;
using System.Threading.Tasks;
using MatrixHeroes.Auth;
using MatrixHeroes.Models.Dtos.Requests;
using MatrixHeroes.Models.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MatrixHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepo _repository;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AuthController(IAuthRepo repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto user)
        {
            if (ModelState.IsValid)
            {
                RegistrationResponse response = await _repository.Register(user);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            log.Error("Register() - Model isn't valid");
            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                RegistrationResponse response = await _repository.Login(user);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }

            log.Error("Login() - Model isn't valid");
            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() {
                        "Invalid payload"
                    },
                Success = false
            });
        }


    }
}