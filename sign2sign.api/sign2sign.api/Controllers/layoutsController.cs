using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using sign2sign.data;

namespace sign2sign.api.Controllers
{
    public class layoutsController : ApiController
    {
        private sign2signEntities db = new sign2signEntities();

        // GET: api/layouts
        public List<layout> Getlayouts()
        {
            var layouts = db.layouts.ToList();
            foreach (var layout in layouts)
            {
                layout.windows = db.windows.Where(x => x.layout_id == layout.id).ToList();
            }
            return layouts;
        }

        // GET: api/layouts/5
        [ResponseType(typeof(layout))]
        public async Task<IHttpActionResult> Getlayout(int id)
        {
            layout layout = await db.layouts.FindAsync(id);
            if (layout == null)
            {
                return NotFound();
            }

            layout.windows = db.windows.Where(x => x.layout_id == layout.id).ToList();

            return Ok(layout);
        }

        // PUT: api/layouts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putlayout(int id, layout layout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != layout.id)
            {
                return BadRequest();
            }

            db.Entry(layout).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!layoutExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/layouts
        [ResponseType(typeof(layout))]
        public async Task<IHttpActionResult> Postlayout(layout layout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.layouts.Add(layout);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = layout.id }, layout);
        }

        // DELETE: api/layouts/5
        [ResponseType(typeof(layout))]
        public async Task<IHttpActionResult> Deletelayout(int id)
        {
            layout layout = await db.layouts.FindAsync(id);
            if (layout == null)
            {
                return NotFound();
            }

            db.layouts.Remove(layout);
            await db.SaveChangesAsync();

            return Ok(layout);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool layoutExists(int id)
        {
            return db.layouts.Count(e => e.id == id) > 0;
        }
    }
}