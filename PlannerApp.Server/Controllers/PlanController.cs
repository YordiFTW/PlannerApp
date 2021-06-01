using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlannerApp.Server.Data;
using PlannerApp.Shared;

namespace PlannerApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Plan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlans()
        {
            return await _context.Plans.ToListAsync();
        }

        // GET: api/Plan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlan(int id)
        {
            var plan = await _context.Plans.FindAsync(id);

            if (plan == null)
            {
                return NotFound();
            }

            return plan;
        }

        // PUT: api/Plan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan(int id, Plan plan)
        {
            if (id != plan.Id)
            {
                return BadRequest();
            }

            _context.Entry(plan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanExists(id))
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

        // POST: api/Plan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plan>> PostPlan(Plan plan)
        {
            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlan", new { id = plan.Id }, plan);
        }

        // DELETE: api/Plan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(int id)
        {
            var plan = await _context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }

            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanExists(int id)
        {
            return _context.Plans.Any(e => e.Id == id);
        }
    }
}

