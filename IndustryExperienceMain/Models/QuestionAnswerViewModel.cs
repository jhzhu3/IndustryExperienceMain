namespace IndustryExperienceMain.Models
{
    public class QuestionAnswerViewModel
    {
        public List<MyItem> Questions { get; set; }

    }

    public class MyItem
    { 
        public int Id { get; set; }
        public string Title { get; set; }

        public string Answer { get; set; }

        public int Points { get; set; }
    }
}
