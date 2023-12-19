using System;
using System.Collections.Generic;

namespace DevJobs.API.Models;

public partial class JobTechnology
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? JobAnalysisId { get; set; }

    public virtual JobAnalysis? JobAnalysis { get; set; }
}
