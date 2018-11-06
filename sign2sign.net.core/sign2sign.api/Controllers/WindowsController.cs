using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sign2sign.api.Models;

namespace sign2sign.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WindowsController : ControllerBase
    {
        private readonly sign2signContext _context;

        public WindowsController(sign2signContext context)
        {
            _context = context;
        }

        // GET: api/Windows
        [HttpGet]
        public IEnumerable<Window> GetWindows()
        {
            return from w in _context.Windows
                   select new Window
                   {
                       Id = w.Id,
                       Width = w.Width,
                       Height = w.Height,
                       Top = w.Top,
                       Left = w.Left,
                       ZIndex = w.ZIndex
                   };
        }

        // GET: api/Windows/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWindow([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var windows = await (from w in _context.Windows
                                 where w.Id == id
                                 select new Window
                                 {
                                     Id = w.Id,
                                     Width = w.Width,
                                     Height = w.Height,
                                     Top = w.Top,
                                     Left = w.Left,
                                     ZIndex = w.ZIndex
                                 }).FirstOrDefaultAsync();

            if (windows == null)
            {
                return NotFound();
            }

            return Ok(windows);
        }

        // PUT: api/Windows/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWindow([FromRoute] int id, [FromBody] Window window)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != window.Id)
            {
                return BadRequest();
            }

            _context.Entry(window).State = EntityState.Modified;

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
        public async Task<IActionResult> PostWindow([FromBody] Window window)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Windows.Add(window);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWindow", new { id = window.Id }, window);
        }

        // DELETE: api/Windows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWindow([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var window = await _context.Windows.FindAsync(id);
            if (window == null)
            {
                return NotFound();
            }

            _context.Windows.Remove(window);
            await _context.SaveChangesAsync();

            return Ok(window);
        }

        private bool WindowsExists(int id)
        {
            return _context.Windows.Any(e => e.Id == id);
        }
    }
}