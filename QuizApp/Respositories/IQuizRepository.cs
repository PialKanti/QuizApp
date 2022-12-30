using QuizApp.Dtos;
using QuizApp.Entities;

namespace QuizApp.Respositories
{
    public interface IQuizRepository
    {
        Task<Quiz> Insert(QuizCreateDto dtoModel);
        Task<IEnumerable<Quiz>> GetAll();
    }
}
