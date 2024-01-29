using System;
using System.Collections.Generic;

namespace HM1;

public class Student
{
    public int Id { get; set; }

    public int? PersonId { get; set; }

    public int Gpa { get; set; }

    public ICollection<GroupDatum> GroupData { get; set; } = new List<GroupDatum>();

    public Person? Person { get; set; }
}
