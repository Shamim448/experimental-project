using System;
using System.Collections.Generic;

namespace DevJobs.API.Models;

public partial class Technology
{
    public Guid Id { get; set; }

    public int TechnologyTrack { get; set; }

    public string? Name { get; set; }
}
