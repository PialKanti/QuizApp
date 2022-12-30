using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Dtos;
using QuizApp.Entities;
using QuizApp.Respositories;

namespace QuizApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoresController : ControllerBase
    {
        private IScoreRepository _repository;

        public ScoresController(IScoreRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Post(ScoreCreateDto dtoModel)
        {
            var score = await _repository.Insert(dtoModel);
            return Ok(score);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Score>>> GetAllByQuiz([FromQuery] int quizId)
        {
            var scores = await _repository.GetAllByQuiz(quizId);
            return Ok(scores);
        }
    }
}
