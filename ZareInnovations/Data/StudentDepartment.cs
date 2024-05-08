using System;
using System.Collections.Generic;

namespace ZareInnovations.Data;

public partial class StudentDepartment
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public int StudentId { get; set; }

    public virtual Department? Department { get; set; } = null!;

    public virtual Student? Student { get; set; } = null!;
}
