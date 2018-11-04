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
    public class LayoutsController : ControllerBase
    {
        private readonly sign2signContext _context;

        public LayoutsController(sign2signContext context)
        {
            _context = context;
        }

        // GET: api/Layouts
        [HttpGet]
        public IEnumerable<Layouts> GetLayouts()
        {
            return _context.Layouts;
        }

        // GET: api/Layouts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLayouts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var layouts = await _context.Layouts.FindAsync(id);

            if (layouts == null)
            {
                return NotFound();
            }

            return Ok(layouts);
        }

        // PUT: api/Layouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLayouts([FromRoute] int id, [FromBody] Layouts layouts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != layouts.Id)
            {
                return BadRequest();
            }

            _context.Entry(layouts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LayoutsExists(id))
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

        // POST: api/Layouts
        [HttpPost]
        public async Task<IActionResult> PostLayouts([FromBody] Layouts layouts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Layouts.Add(layouts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLayouts", new { id = layouts.Id }, layouts);
        }

        // DELETE: api/Layouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLayouts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var layouts = await _context.Layouts.FindAsync(id);
            if (layouts == null)
            {
                return NotFound();
            }

            _context.Layouts.Remove(layouts);
            await _context.SaveChangesAsync();

            return Ok(layouts);
        }

        private bool LayoutsExists(int id)
        {
            return _context.Layouts.Any(e => e.Id == id);
        }
    }
}