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
    public class businessesController : ApiController
    {
        private sign2signEntities db = new sign2signEntities();

        // GET: api/businesses
        public IQueryable<business> Getbusinesses()
        {
            return db.businesses;
        }

        // GET: api/businesses/5
        [ResponseType(typeof(business))]
        public async Task<IHttpActionResult> Getbusiness(int id)
        {
            business business = await db.businesses.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }

            return Ok(business);
        }

        // PUT: api/businesses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putbusiness(int id, business business)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != business.id)
            {
                return BadRequest();
            }

            db.Entry(business).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!businessExists(id))
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

        // POST: api/businesses
        [ResponseType(typeof(business))]
        public async Task<IHttpActionResult> Postbusiness(business business)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.businesses.Add(business);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = business.id }, business);
        }

        // DELETE: api/businesses/5
        [ResponseType(typeof(business))]
        public async Task<IHttpActionResult> Deletebusiness(int id)
        {
            business business = await db.businesses.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }

            db.businesses.Remove(business);
            await db.SaveChangesAsync();

            return Ok(business);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool businessExists(int id)
        {
            return db.businesses.Count(e => e.id == id) > 0;
        }
    }
}