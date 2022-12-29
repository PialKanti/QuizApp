using QuizApp.Data;
using QuizApp.Dtos;
using QuizApp.Entities;

namespace QuizApp.Respositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuizAppContext _dbContext;
        public QuestionRepository(QuizAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Question> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Question> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Question>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Question> Insert(QuestionCreateDto dtoModel)
        {
            var options = new List<Option>();
            foreach(string value in dtoModel.Options)
            {
                options.Add(new Option { Name = value });
            }

            var question = new Question
            {
                Title = dtoModel.QuestionTitle,
                TimeLimitInSeconds = dtoModel.QuestionTimeLimit,
                Options = options
            };

            var answer = new Answer
            {
                Question = question,
                Option = question.Options.FirstOrDefault(item => item.Name == dtoModel.Answer)
            };

            _dbContext.Answers.Add(answer);

            var valueTask = _dbContext.Questions.Add(question);
            await _dbContext.SaveChangesAsync();
            return valueTask.Entity;
        }

        public Task Update(Question entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
