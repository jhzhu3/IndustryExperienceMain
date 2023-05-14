using System;
using System.Collections.Generic;

namespace IndustryExperienceMain.Models;

public partial class Answer
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int Points { get; set; }

    public int QuestionId { get; set; }

    public virtual Question Question { get; set; } = null!;
}
