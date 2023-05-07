using System;
using System.Collections.Generic;

namespace IndustryExperienceMain.Models;

public partial class Question
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int QuizId { get; set; }

    public virtual ICollection<Answer> Answers { get; } = new List<Answer>();

    public virtual Quiz Quiz { get; set; } = null!;
}
