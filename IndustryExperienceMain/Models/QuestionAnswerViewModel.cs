namespace IndustryExperienceMain.Models
{
    public class QuestionAnswerViewModel
    {
        public string Question { get; set; } = null!;

        public List<Answer> Answers { get; set; } = null!;

        public int Points { get; set; }
    }
}
