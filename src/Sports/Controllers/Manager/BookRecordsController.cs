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
    public class BookRecordsController : ApiController
    {
        private SportsContext db = new SportsContext();

        // GET: api/BookRecords
        public IQueryable<BookRecord> GetBookRecords()
        {
            return db.BookRecords;
        }

        // GET: api/BookRecords/5
        [ResponseType(typeof(BookRecord))]
        public async Task<IHttpActionResult> GetBookRecord(Guid id)
        {
            BookRecord bookRecord = await db.BookRecords.FindAsync(id);
            if (bookRecord == null)
            {
                return NotFound();
            }

            return Ok(bookRecord);
        }

        // PUT: api/BookRecords/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBookRecord(Guid id, BookRecord bookRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookRecord.RecordId)
            {
                return BadRequest();
            }

            db.Entry(bookRecord).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookRecordExists(id))
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

        // POST: api/BookRecords
        [ResponseType(typeof(BookRecord))]
        public async Task<IHttpActionResult> PostBookRecord(BookRecord bookRecord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookRecords.Add(bookRecord);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bookRecord.RecordId }, bookRecord);
        }

        // DELETE: api/BookRecords/5
        [ResponseType(typeof(BookRecord))]
        public async Task<IHttpActionResult> DeleteBookRecord(Guid id)
        {
            BookRecord bookRecord = await db.BookRecords.FindAsync(id);
            if (bookRecord == null)
            {
                return NotFound();
            }

            db.BookRecords.Remove(bookRecord);
            await db.SaveChangesAsync();

            return Ok(bookRecord);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookRecordExists(Guid id)
        {
            return db.BookRecords.Count(e => e.RecordId == id) > 0;
        }
    }
}