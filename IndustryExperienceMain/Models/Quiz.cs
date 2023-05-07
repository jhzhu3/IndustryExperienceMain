using System;
using System.Collections.Generic;

namespace IndustryExperienceMain.Models;

public partial class Quiz
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; } = new List<Question>();
}
