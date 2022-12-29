using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Dtos;
using QuizApp.Entities;
using QuizApp.Respositories;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserRepository<ApplicationUser> _userRepository;
        private SignInManager<ApplicationUser> _manager;
        public AccountController(IUserRepository<ApplicationUser> userRepository, SignInManager<ApplicationUser> manager)
        {
            _userRepository = userRepository;
            _manager = manager;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Login([FromBody] UserLoginDto dtoModel)
        {
            ApplicationUser user = await _userRepository.GetByEmail(dtoModel.Email);
            if(user == null)
            {
                return NotFound("Email not found");
            }
            var result = await _manager.PasswordSignInAsync(user, dtoModel.Password, false, false);
            return Ok(result);
        }
    }
}
