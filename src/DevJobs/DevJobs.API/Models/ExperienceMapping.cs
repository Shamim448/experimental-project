using System;
using System.Collections.Generic;

namespace DevJobs.API.Models;

public partial class ExperienceMapping
{
    public Guid Id { get; set; }

    public string? Keyword { get; set; }

    public int Level { get; set; }
}
