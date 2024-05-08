using System;
using System.Collections.Generic;

namespace ZareInnovations.Data;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<StudentDepartment> StudentDepartments { get; set; } = new List<StudentDepartment>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
