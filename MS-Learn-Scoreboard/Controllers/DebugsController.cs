using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MS_Learn_Scoreboard.Data;
using MS_Learn_Scoreboard.Models;

namespace MS_Learn_Scoreboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebugsController : ControllerBase
    {
        private readonly MS_Learn_ScoreboardContext _context;

        public DebugsController(MS_Learn_ScoreboardContext context)
        {
            _context = context;
        }

        // GET: api/Debugs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Debug>>> GetDebug()
        {
            return await _context.Debug.ToListAsync();
        }

        // GET: api/Debugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Debug>> GetDebug(int id)
        {
            var debug = await _context.Debug.FindAsync(id);

            if (debug == null)
            {
                return NotFound();
            }

            return debug;
        }

        // PUT: api/Debugs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDebug(int id, Debug debug)
        {
            if (id != debug.Id)
            {
                return BadRequest();
            }

            _context.Entry(debug).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DebugExists(id))
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

        // POST: api/Debugs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Debug>> PostDebug(Debug debug)
        {
            _context.Debug.Add(debug);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDebug", new { id = debug.Id }, debug);
        }

        // DELETE: api/Debugs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Debug>> DeleteDebug(int id)
        {
            var debug = await _context.Debug.FindAsync(id);
            if (debug == null)
            {
                return NotFound();
            }

            _context.Debug.Remove(debug);
            await _context.SaveChangesAsync();

            return debug;
        }

        private bool DebugExists(int id)
        {
            return _context.Debug.Any(e => e.Id == id);
        }
    }
}
