using System;
using System.Collections.Generic;

namespace HM1;

public class StudyPlan
{
    public int Id { get; set; }

    public int? TeacherId { get; set; }

    public int? GroupId { get; set; }

    public int? FacultyId { get; set; }

    public Faculty? Faculty { get; set; }

    public Group? Group { get; set; }

    public Teacher? Teacher { get; set; }
}
