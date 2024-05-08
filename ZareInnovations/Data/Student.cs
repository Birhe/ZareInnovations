using System;
using System.Collections.Generic;

namespace ZareInnovations.Data;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int? DepartmentId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<StudentDepartment> StudentDepartments { get; set; } = new List<StudentDepartment>();
}
