using System;
using System.Collections.Generic;

namespace HM1;

public class Employee
{
    public int Id { get; set; }

    public decimal Salary { get; set; }

    public int Experience { get; set; }

    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
