using System;
using System.Collections.Generic;

namespace DevJobs.API.Models;

public partial class TrackMapping
{
    public Guid Id { get; set; }

    public string? Keyword { get; set; }

    public int JobTrack { get; set; }
}
