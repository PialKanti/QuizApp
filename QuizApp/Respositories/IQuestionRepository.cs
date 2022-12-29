using QuizApp.Dtos;
using QuizApp.Entities;

namespace QuizApp.Respositories
{
    public interface IQuestionRepository
    {
        Task<Question> Insert(QuestionCreateDto dtoModel);
    }
}
