using System.ComponentModel.DataAnnotations;

namespace QuizApp.Entities
{
    public class Score : BaseEntity
    {
        public int TotalScore { get; set; }
        public int EarnedScore { get; set; }
        public ApplicationUser User { get; set; }
        public Quiz Quiz { get; set; }
        public long CreatedTimestamp { get; set; }
    }
}
