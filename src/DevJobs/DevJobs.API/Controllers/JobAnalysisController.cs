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
    public class JobAnalysisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobAnalysisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobAnalysis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobAnalysis>>> GetJobAnalyses()
        {
            return await _context.JobAnalyses.ToListAsync();
        }

        // GET: api/JobAnalysis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobAnalysis>> GetJobAnalysis(Guid id)
        {
            var jobAnalysis = await _context.JobAnalyses.FindAsync(id);

            if (jobAnalysis == null)
            {
                return NotFound();
            }

            return jobAnalysis;
        }

        // PUT: api/JobAnalysis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobAnalysis(Guid id, JobAnalysis jobAnalysis)
        {
            if (id != jobAnalysis.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobAnalysis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobAnalysisExists(id))
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

        // POST: api/JobAnalysis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobAnalysis>> PostJobAnalysis(JobAnalysis jobAnalysis)
        {
            _context.JobAnalyses.Add(jobAnalysis);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobAnalysisExists(jobAnalysis.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobAnalysis", new { id = jobAnalysis.Id }, jobAnalysis);
        }

        // DELETE: api/JobAnalysis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobAnalysis(Guid id)
        {
            var jobAnalysis = await _context.JobAnalyses.FindAsync(id);
            if (jobAnalysis == null)
            {
                return NotFound();
            }

            _context.JobAnalyses.Remove(jobAnalysis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobAnalysisExists(Guid id)
        {
            return _context.JobAnalyses.Any(e => e.Id == id);
        }
    }
}
