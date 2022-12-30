using Microsoft.AspNetCore.Mvc;
using QuizApp.Dtos;
using QuizApp.Entities;
using QuizApp.Respositories;
using System.Linq;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionRepository _repository;

        public QuestionsController(IQuestionRepository repository) 
        { 
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Post(QuestionCreateDto dtoModel)
        {
            return Ok(await _repository.Insert(dtoModel));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Question>>> Get()
        {
            var questions = await _repository.GetAll();
            return Ok(questions);
        }
    }
}
