using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevJobs.API.Data;
using DevJobs.API.Models;

namespace DevJobs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTechnologiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobTechnologiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobTechnologies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTechnology>>> GetJobTechnologies()
        {
            return await _context.JobTechnologies.ToListAsync();
        }

        // GET: api/JobTechnologies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTechnology>> GetJobTechnology(Guid id)
        {
            var jobTechnology = await _context.JobTechnologies.FindAsync(id);

            if (jobTechnology == null)
            {
                return NotFound();
            }

            return jobTechnology;
        }

        // PUT: api/JobTechnologies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobTechnology(Guid id, JobTechnology jobTechnology)
        {
            if (id != jobTechnology.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobTechnology).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTechnologyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JobTechnologies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobTechnology>> PostJobTechnology(JobTechnology jobTechnology)
        {
            _context.JobTechnologies.Add(jobTechnology);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobTechnologyExists(jobTechnology.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobTechnology", new { id = jobTechnology.Id }, jobTechnology);
        }

        // DELETE: api/JobTechnologies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTechnology(Guid id)
        {
            var jobTechnology = await _context.JobTechnologies.FindAsync(id);
            if (jobTechnology == null)
            {
                return NotFound();
            }

            _context.JobTechnologies.Remove(jobTechnology);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobTechnologyExists(Guid id)
        {
            return _context.JobTechnologies.Any(e => e.Id == id);
        }
    }
}
