using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentDetailesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentDetailes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetaile>>> GetPaymentDetailes()
        {
          if (_context.PaymentDetailes == null)
          {
              return NotFound();
          }
            return await _context.PaymentDetailes.ToListAsync();
        }

        // GET: api/PaymentDetailes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetaile>> GetPaymentDetaile(int id)
        {
          if (_context.PaymentDetailes == null)
          {
              return NotFound();
          }
            var paymentDetaile = await _context.PaymentDetailes.FindAsync(id);

            if (paymentDetaile == null)
            {
                return NotFound();
            }

            return paymentDetaile;
        }

        // PUT: api/PaymentDetailes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentDetaile(int id, PaymentDetaile paymentDetaile)
        {
            if (id != paymentDetaile.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentDetaile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetaileExists(id))
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

        // POST: api/PaymentDetailes
        [HttpPost]
        public async Task<ActionResult<PaymentDetaile>> PostPaymentDetaile(PaymentDetaile paymentDetaile)
        {
          if (_context.PaymentDetailes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.PaymentDetailes'  is null.");
          }
            _context.PaymentDetailes.Add(paymentDetaile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentDetaile", new { id = paymentDetaile.Id }, paymentDetaile);
        }

        // DELETE: api/PaymentDetailes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetaile(int id)
        {
            if (_context.PaymentDetailes == null)
            {
                return NotFound();
            }
            var paymentDetaile = await _context.PaymentDetailes.FindAsync(id);
            if (paymentDetaile == null)
            {
                return NotFound();
            }

            _context.PaymentDetailes.Remove(paymentDetaile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentDetaileExists(int id)
        {
            return (_context.PaymentDetailes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
