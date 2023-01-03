using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Dtos;
using QuizApp.Entities;
using QuizApp.Respositories;

namespace QuizApp.Controllers
{
    public class QuizsController : ApiControllerBase
    {
        private readonly IQuizRepository _repository;

        public QuizsController(IQuizRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Post(QuizCreateDto dtoModel)
        {
            return Ok(await _repository.Insert(dtoModel));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Quiz>>> Get()
        {
            var quizzes = await _repository.GetAll();
            return Ok(quizzes);
        }
    }
}
