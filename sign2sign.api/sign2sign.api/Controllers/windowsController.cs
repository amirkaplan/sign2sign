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
using sign2sign.bo;


namespace sign2sign.api.Controllers
{
    public class windowsController : ApiController
    {
        private sign2signEntities db = new sign2signEntities();

        // GET: api/windows
        public IQueryable<Window> Getwindows()
        {
            return from window in db.windows
                   select new Window
                   {
                       id = window.id,
                       width = window.width,
                       hieght = window.hieght,
                       top = window.top,
                       left = window.left,
                       layout_id = window.layout_id,
                       z_index = window.z_index
                   };
        }

        // GET: api/windows/5
        [ResponseType(typeof(window))]
        public async Task<IHttpActionResult> Getwindow(int id)
        {
            Window window = await (from w in db.windows
                                   select new Window
                                   {
                                       id = w.id,
                                       width = w.width,
                                       hieght = w.hieght,
                                       top = w.top,
                                       left = w.left,
                                       layout_id = w.layout_id,
                                       z_index = w.z_index
                                   }).SingleOrDefaultAsync();
            if (window == null)
            {
                return NotFound();
            }

            return Ok(window);
        }

        // PUT: api/windows/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putwindow(int id, window window)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != window.id)
            {
                return BadRequest();
            }

            db.Entry(window).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!windowExists(id))
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

        // POST: api/windows
        [ResponseType(typeof(window))]
        public async Task<IHttpActionResult> Postwindow(window window)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.windows.Add(window);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = window.id }, window);
        }

        // DELETE: api/windows/5
        [ResponseType(typeof(window))]
        public async Task<IHttpActionResult> Deletewindow(int id)
        {
            window window = await db.windows.FindAsync(id);
            if (window == null)
            {
                return NotFound();
            }

            db.windows.Remove(window);
            await db.SaveChangesAsync();

            return Ok(window);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool windowExists(int id)
        {
            return db.windows.Count(e => e.id == id) > 0;
        }
    }
}