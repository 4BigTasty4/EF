using System;
using System.Collections.Generic;

namespace HM1;

public class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int Age { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();

    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
