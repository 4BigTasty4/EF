﻿using System;
using System.Collections.Generic;

namespace HM1;

public class Group
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Course { get; set; }

    public int? FacultyId { get; set; }

    public Faculty? Faculty { get; set; }

    public ICollection<GroupDatum> GroupData { get; set; } = new List<GroupDatum>();

    public ICollection<StudyPlan> StudyPlans { get; set; } = new List<StudyPlan>();
}
