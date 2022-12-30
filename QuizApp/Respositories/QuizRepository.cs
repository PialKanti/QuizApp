using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Dtos;
using QuizApp.Entities;
using System.Threading.Tasks;

namespace QuizApp.Respositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizAppContext _dbContext;
        private readonly IQuestionRepository _questionRepository;
        public QuizRepository(QuizAppContext dbContext, IQuestionRepository questionRepository)
        {
            _dbContext = dbContext;
            _questionRepository = questionRepository;
        }

        public async Task<Quiz> Insert(QuizCreateDto dtoModel)
        {
            var quiz = new Quiz
            {
                Name = dtoModel.Name,
                Questions = new List<Question>()
            };

            foreach (var questionId in dtoModel.SelectedQuestionIds)
            {
                var question = await _questionRepository.Get(questionId);
                quiz.Questions.Add(question);
            }

            var valueTask = _dbContext.Quizes.Add(quiz);
            await _dbContext.SaveChangesAsync();
            return valueTask.Entity;
        }

        public async Task<IEnumerable<Quiz>> GetAll()
        {
            return await _dbContext.Quizes.Include(quiz => quiz.Questions).ToListAsync();
        }
    }
}
