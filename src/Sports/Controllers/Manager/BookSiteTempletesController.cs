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
using Sports.Models;
using Sports.Models.Manager;

namespace Sports.Controllers.Manager
{
    public class BookSiteTempletesController : ApiController
    {
        // GET: api/BookSiteTempletes
        public IQueryable<BookSiteTemplete> GetBookSiteTempletes()
        {
            using (SportsContext db = new SportsContext())
            {
                return db.BookSiteTempletes;
            }
        }

        // GET: api/BookSiteTempletes/5
        [ResponseType(typeof(BookSiteTemplete))]
        public async Task<IHttpActionResult> GetBookSiteTemplete(Guid id)
        {
            using (SportsContext db = new SportsContext())
            {
                BookSiteTemplete bookSiteTemplete = await db.BookSiteTempletes.FindAsync(id);
                if (bookSiteTemplete == null)
                {
                    return NotFound();
                }
                return Ok(bookSiteTemplete);
            }
        }

        // PUT: api/BookSiteTempletes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookSiteTemplete(Guid id, BookSiteTemplete bookSiteTemplete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookSiteTemplete.TempleteId)
            {
                return BadRequest();
            }

            using (SportsContext db = new SportsContext())
            {
                db.Entry(bookSiteTemplete).State = EntityState.Modified;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (db.BookSiteTempletes.Count(e => e.TempleteId == id) <= 0)
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
        }

        // POST: api/BookSiteTempletes
        [ResponseType(typeof(BookSiteTemplete))]
        public async Task<IHttpActionResult> PostBookSiteTemplete(BookSiteTemplete bookSiteTemplete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (SportsContext db = new SportsContext())
            {
                db.BookSiteTempletes.Add(bookSiteTemplete);
                await db.SaveChangesAsync();
                return CreatedAtRoute("DefaultApi", new { id = bookSiteTemplete.TempleteId }, bookSiteTemplete);
            }
        }

        // DELETE: api/BookSiteTempletes/5
        [ResponseType(typeof(BookSiteTemplete))]
        public async Task<IHttpActionResult> DeleteBookSiteTemplete(Guid id)
        {
            using (SportsContext db = new SportsContext())
            {
                BookSiteTemplete bookSiteTemplete = await db.BookSiteTempletes.FindAsync(id);
                if (bookSiteTemplete == null)
                {
                    return NotFound();
                }

                db.BookSiteTempletes.Remove(bookSiteTemplete);
                await db.SaveChangesAsync();

                return Ok(bookSiteTemplete);
            }
        }
    }
}