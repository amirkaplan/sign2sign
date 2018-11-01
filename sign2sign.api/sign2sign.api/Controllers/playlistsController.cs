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
    public class playlistsController : ApiController
    {
        private sign2signEntities db = new sign2signEntities();

        // GET: api/playlists
        public IQueryable<playlist> Getplaylists()
        {
            return db.playlists;
        }

        // GET: api/playlists/5
        [ResponseType(typeof(playlist))]
        public async Task<IHttpActionResult> Getplaylist(int id)
        {
            playlist playlist = await db.playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            return Ok(playlist);
        }

        // PUT: api/playlists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putplaylist(int id, playlist playlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playlist.id)
            {
                return BadRequest();
            }

            db.Entry(playlist).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!playlistExists(id))
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

        // POST: api/playlists
        [ResponseType(typeof(playlist))]
        public async Task<IHttpActionResult> Postplaylist(playlist playlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.playlists.Add(playlist);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = playlist.id }, playlist);
        }

        // DELETE: api/playlists/5
        [ResponseType(typeof(playlist))]
        public async Task<IHttpActionResult> Deleteplaylist(int id)
        {
            playlist playlist = await db.playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            db.playlists.Remove(playlist);
            await db.SaveChangesAsync();

            return Ok(playlist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool playlistExists(int id)
        {
            return db.playlists.Count(e => e.id == id) > 0;
        }
    }
}