using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Data;
using QuizApp.Dtos;
using QuizApp.Entities;
using QuizApp.Respositories;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository<ApplicationUser> _repository;

        public UsersController(IUserRepository<ApplicationUser> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApplicationUser>> Get([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id)) 
            {
                return BadRequest();
            }
            return Ok(await _repository.Get(id));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> Get()
        {
            var users = await _repository.GetAll();
            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IdentityResult>> Create([FromBody] UserCreateDto dtoModel)
        {
            var result = await _repository.Insert(dtoModel);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(result);
        }
    }
}
