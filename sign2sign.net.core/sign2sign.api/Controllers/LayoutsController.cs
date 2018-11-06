using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sign2sign.api.BusinessModels;
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
        public IEnumerable<Layout> GetLayouts()
        {
            return from l in _context.Layouts
                   select new Layout
                   {
                       Id = l.Id,
                       Name = l.Name,
                       Windows = (from w in _context.Windows
                                  where w.LayoutId == l.Id
                                  select new Window
                                  {
                                      Id = w.Id,
                                      Width = w.Width,
                                      Height = w.Height,
                                      Top = w.Top,
                                      Left = w.Left,
                                      ZIndex = w.ZIndex
                                  }).ToList()
                   };
        }

        // GET: api/Layouts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLayout([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var layout = await (from l in _context.Layouts
                                where l.Id == id
                                select new Layout
                                {
                                    Id = l.Id,
                                    Name = l.Name,
                                    Windows = (from w in _context.Windows
                                               where w.LayoutId == l.Id
                                               select new Window
                                               {
                                                   Id = w.Id,
                                                   Width = w.Width,
                                                   Height = w.Height,
                                                   Top = w.Top,
                                                   Left = w.Left,
                                                   ZIndex = w.ZIndex
                                               }).ToList()
                                }).FirstOrDefaultAsync();

            if (layout == null)
            {
                return NotFound();
            }

            return Ok(layout);
        }

        // PUT: api/Layouts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLayout([FromRoute] int id, [FromBody] Layout layout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != layout.Id)
            {
                return BadRequest();
            }

            _context.Entry(layout).State = EntityState.Modified;

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
        public async Task<IActionResult> PostLayout([FromBody] Layout layout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Layouts.Add(layout);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLayouts", new { id = layout.Id }, layout);
        }

        // DELETE: api/Layouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLayout([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var layout = await _context.Layouts.FindAsync(id);
            if (layout == null)
            {
                return NotFound();
            }

            _context.Layouts.Remove(layout);
            await _context.SaveChangesAsync();

            return Ok(layout);
        }

        private bool LayoutsExists(int id)
        {
            return _context.Layouts.Any(e => e.Id == id);
        }
    }
}