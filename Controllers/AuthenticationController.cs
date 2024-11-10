using Expenses.Core;
using Expenses.Core.CustomExceptions;
using Expenses.DB;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController: ControllerBase
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(User user)
        {
            try
            {
                var result = await _userService.SignUp(user);
                return Created("", result);
            }catch (UsernameAlreadyExistsException ex)
            {
                return StatusCode(409, ex.Message);
            }
           
        }
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(User user) 
        { 
            try
            {
                var result = await _userService.SignIn(user);
                return Ok(result); 
            }
            catch (InvalidUsernamePasswordException ex)
            {
                return StatusCode(401, ex.Message);
            }
        }

    }
}
