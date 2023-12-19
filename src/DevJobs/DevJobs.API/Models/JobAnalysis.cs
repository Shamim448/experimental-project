using System;
using System.Collections.Generic;

namespace DevJobs.API.Models;

public partial class JobAnalysis
{
    public Guid Id { get; set; }

    public Guid JobPostId { get; set; }

    public int JobTrack { get; set; }

    public int Experience { get; set; }

    public virtual JobPost JobPost { get; set; } = null!;

    public virtual ICollection<JobTechnology> JobTechnologies { get; set; } = new List<JobTechnology>();
}
