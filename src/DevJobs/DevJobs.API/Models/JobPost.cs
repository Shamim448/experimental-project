using System;
using System.Collections.Generic;

namespace DevJobs.API.Models;

public partial class JobPost
{
    public Guid Id { get; set; }

    public Guid OrganizationId { get; set; }

    public string? JobTitle { get; set; }

    public int NumberOfVacancies { get; set; }

    public DateTime PublishedOn { get; set; }

    public string? JobNature { get; set; }

    public int ExperienceMin { get; set; }

    public int? ExperienceMax { get; set; }

    public int? Gender { get; set; }

    public int? AgeMin { get; set; }

    public int? AgeMax { get; set; }

    public string? JobLocation { get; set; }

    public int? SalaryMin { get; set; }

    public int? SalaryMax { get; set; }

    public string? JobDescription { get; set; }

    public string? EducationalRequirements { get; set; }

    public string? ExperienceRequirements { get; set; }

    public string? AdditionalJobRequirements { get; set; }

    public string? OtherBenefits { get; set; }

    public string? Source { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual ICollection<JobAnalysis> JobAnalyses { get; set; } = new List<JobAnalysis>();

    public virtual Organization Organization { get; set; } = null!;
}
