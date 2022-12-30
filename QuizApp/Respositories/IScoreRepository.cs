using QuizApp.Dtos;
using QuizApp.Entities;

namespace QuizApp.Respositories
{
    public interface IScoreRepository
    {
        Task<Score> Insert(ScoreCreateDto dtoModel);
        Task<IEnumerable<Score>> GetAllByQuiz(int quizId);
    }
}
