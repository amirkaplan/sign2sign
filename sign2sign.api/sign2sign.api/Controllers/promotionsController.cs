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
    public class promotionsController : ApiController
    {
        private sign2signEntities db = new sign2signEntities();

        // GET: api/promotions
        public IQueryable<promotion> Getpromotions()
        {
            return db.promotions;
        }

        // GET: api/promotions/5
        [ResponseType(typeof(promotion))]
        public async Task<IHttpActionResult> Getpromotion(int id)
        {
            promotion promotion = await db.promotions.FindAsync(id);
            if (promotion == null)
            {
                return NotFound();
            }

            return Ok(promotion);
        }

        // PUT: api/promotions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putpromotion(int id, promotion promotion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promotion.id)
            {
                return BadRequest();
            }

            db.Entry(promotion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!promotionExists(id))
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

        // POST: api/promotions
        [ResponseType(typeof(promotion))]
        public async Task<IHttpActionResult> Postpromotion(promotion promotion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.promotions.Add(promotion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = promotion.id }, promotion);
        }

        // DELETE: api/promotions/5
        [ResponseType(typeof(promotion))]
        public async Task<IHttpActionResult> Deletepromotion(int id)
        {
            promotion promotion = await db.promotions.FindAsync(id);
            if (promotion == null)
            {
                return NotFound();
            }

            db.promotions.Remove(promotion);
            await db.SaveChangesAsync();

            return Ok(promotion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool promotionExists(int id)
        {
            return db.promotions.Count(e => e.id == id) > 0;
        }
    }
}