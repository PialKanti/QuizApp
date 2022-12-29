using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuizApp.Entities;
using QuizApp.Respositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private IOptionRepository _repository;
        public OptionsController(OptionRepository repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Option>>> Get()
        {
            var options = await _repository.GetAll();
            return Ok(options);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Option>> Get(int id)
        {
            if(id < 0)
            {
                return NotFound();
            }

            return Ok(await _repository.Get(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Post([FromBody] string name)
        {
            var option = new Option 
            { 
                Name = name 
            };

            return Ok(await _repository.Insert(option));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put(int id, [FromBody] Option option)
        {
            if (id < 0 && id != option.Id)
            {
                return BadRequest();
            }

            await _repository.Update(option);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            Option item = await _repository.Delete(id);
            if (item == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
