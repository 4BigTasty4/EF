using System;
using System.Collections.Generic;

namespace HM1;

public class GroupDatum
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? GroupId { get; set; }

    public Group? Group { get; set; }

    public Student? Student { get; set; }
}
