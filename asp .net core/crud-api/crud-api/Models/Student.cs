using System;
using System.Collections.Generic;

namespace crud_api.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Class { get; set; }

    public string? Email { get; set; }
}
