using System;
using System.Collections.Generic;

namespace DevJobs.API.Models;

public partial class Organization
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Website { get; set; }

    public string? Address { get; set; }

    public string? BusinessType { get; set; }

    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
}
