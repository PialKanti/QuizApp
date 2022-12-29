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
        public async Task<ActionResult<Microsoft.AspNetCore.Identity.SignInResult>> Login([FromBody] UserLoginDto dtoModel)
        {
            ApplicationUser user = await _userRepository.GetByEmail(dtoModel.Email);
            if(user == null)
            {
                return NotFound("Email not found");
            }
            var result = await _manager.PasswordSignInAsync(user, dtoModel.Password, false, false);
            return Ok(result);
        }

        [HttpGet]
        [Route("logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Logout()
        {
            await _manager.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        [Route("current-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LoggedUserDto>> GetCurrentUser(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                return NotFound("Email can not be null or empty");
            }
            var user = await _userRepository.GetByEmail(email);
            var userDto = new LoggedUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName
            };
            var roles = await _userRepository.GetUserRoles(user);
            userDto.RoleName = roles.FirstOrDefault();
            return Ok(userDto);
        }
    }
}
