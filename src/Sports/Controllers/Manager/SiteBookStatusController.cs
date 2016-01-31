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
    public class SiteBookStatusController : ApiController
    {

        // GET: api/SiteBookStatus
        public IQueryable<SiteBookStatus> GetSiteBookStatus()
        {
            using (SportsContext db = new SportsContext())
            {
                return db.SiteBookStatus;
            }
        }

        // GET: api/SiteBookStatus/5
        [ResponseType(typeof(SiteBookStatus))]
        public async Task<IHttpActionResult> GetSiteBookStatus(Guid id)
        {
            using (SportsContext db = new SportsContext())
            {
                SiteBookStatus siteBookStatus = await db.SiteBookStatus.FindAsync(id);
                if (siteBookStatus == null)
                {
                    return NotFound();
                }

                return Ok(siteBookStatus);
            }
        }

        // PUT: api/SiteBookStatus/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSiteBookStatus(Guid id, SiteBookStatus siteBookStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != siteBookStatus.Id)
            {
                return BadRequest();
            }

            using (SportsContext db = new SportsContext())
            {
                db.Entry(siteBookStatus).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (db.SiteBookStatus.Count(e => e.Id == id) <= 0)
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

        // POST: api/SiteBookStatus
        [ResponseType(typeof(SiteBookStatus))]
        public async Task<IHttpActionResult> PostSiteBookStatus(SiteBookStatus siteBookStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (SportsContext db = new SportsContext())
            {
                db.SiteBookStatus.Add(siteBookStatus);
                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = siteBookStatus.Id }, siteBookStatus);
            }
        }

        // DELETE: api/SiteBookStatus/5
        [ResponseType(typeof(SiteBookStatus))]
        public async Task<IHttpActionResult> DeleteSiteBookStatus(Guid id)
        {
            using (SportsContext db = new SportsContext())
            {
                SiteBookStatus siteBookStatus = await db.SiteBookStatus.FindAsync(id);
                if (siteBookStatus == null)
                {
                    return NotFound();
                }

                db.SiteBookStatus.Remove(siteBookStatus);
                await db.SaveChangesAsync();

                return Ok(siteBookStatus);
            }
        }
    }
}