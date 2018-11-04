using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sign2sign.api.Models;

namespace sign2sign.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowsController : ControllerBase
    {
        private readonly sign2signContext _context;

        public WindowsController(sign2signContext context)
        {
            _context = context;
        }

        // GET: api/Windows
        [HttpGet]
        public IEnumerable<Windows> GetWindows()
        {
            return _context.Windows;
        }

        // GET: api/Windows/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWindows([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var windows = await _context.Windows.FindAsync(id);

            if (windows == null)
            {
                return NotFound();
            }

            return Ok(windows);
        }

        // PUT: api/Windows/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWindows([FromRoute] int id, [FromBody] Windows windows)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != windows.Id)
            {
                return BadRequest();
            }

            _context.Entry(windows).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WindowsExists(id))
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

        // POST: api/Windows
        [HttpPost]
        public async Task<IActionResult> PostWindows([FromBody] Windows windows)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Windows.Add(windows);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWindows", new { id = windows.Id }, windows);
        }

        // DELETE: api/Windows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWindows([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var windows = await _context.Windows.FindAsync(id);
            if (windows == null)
            {
                return NotFound();
            }

            _context.Windows.Remove(windows);
            await _context.SaveChangesAsync();

            return Ok(windows);
        }

        private bool WindowsExists(int id)
        {
            return _context.Windows.Any(e => e.Id == id);
        }
    }
}