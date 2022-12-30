using QuizApp.Dtos;
using QuizApp.Entities;

namespace QuizApp.Respositories
{
    public interface IQuestionRepository
    {
        Task<Question> Insert(QuestionCreateDto dtoModel);
        Task<IEnumerable<Question>> GetAll();
        Task<Question> Get(int id);
        Task<Answer> GetAnswerAsync(Question question);
    }
}
