using System;
using System.Collections.Generic;

namespace HM1;

public class Faculty
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();

    public ICollection<StudyPlan> StudyPlans { get; set; } = new List<StudyPlan>();
}
