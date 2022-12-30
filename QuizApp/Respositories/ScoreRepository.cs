using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using QuizApp.Data;
using QuizApp.Dtos;
using QuizApp.Entities;
using QuizApp.Utils;

namespace QuizApp.Respositories
{
    public class ScoreRepository : IScoreRepository
    {
        private QuizAppContext _dbContext;
        private IQuestionRepository _questionRepository;
        private IQuizRepository _quizRepository;
        IUserRepository<ApplicationUser> _userRepository;
        public ScoreRepository(QuizAppContext dbContext, IQuestionRepository questionRepository, IQuizRepository quizRepository, IUserRepository<ApplicationUser> userRepository) 
        {
            _dbContext = dbContext;
            _questionRepository = questionRepository;
            _quizRepository = quizRepository;
            _userRepository = userRepository;
        }

        public async Task<Score> Insert(ScoreCreateDto dtoModel)
        {
            int totalScore = dtoModel.AnsweredQuestions.Count();
            int earnedScore = await CalculateEarnedScore(dtoModel);
            var quiz = await _quizRepository.Get(dtoModel.QuizId);
            var user = await _userRepository.GetByEmail(dtoModel.UserEmail);

            var score = new Score
            {
                TotalScore = totalScore,
                EarnedScore = earnedScore,
                Quiz = quiz,
                User = user,
                CreatedTimestamp = CommonUtils.GetTimestamp(DateTime.UtcNow)
            };

            var valueTask = _dbContext.Scores.Add(score);
            await _dbContext.SaveChangesAsync();
            return valueTask.Entity;
        }

        private async Task<int> CalculateEarnedScore(ScoreCreateDto dtoModel)
        {
            int totalScore = 0;
            foreach (var item in dtoModel.AnsweredQuestions)
            {
                var question = await _questionRepository.Get(item.QuestionId);
                var originalAnswer = await _questionRepository.GetAnswerAsync(question);
                if(originalAnswer.Option.Id == item.AnswerId)
                {
                    totalScore++;
                }
            }

            return totalScore;
        }
    }
}
