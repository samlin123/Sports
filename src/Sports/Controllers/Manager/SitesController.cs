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
    public class SitesController : ApiController
    {
        // GET: api/Sites
        public IQueryable<Site> GetSites()
        {
            using (SportsContext db = new SportsContext())
            {
                return db.Sites;
            }
        }

        // GET: api/Sites/5
        [ResponseType(typeof(Site))]
        public async Task<IHttpActionResult> GetSite(Guid id)
        {
            using (SportsContext db = new SportsContext())
            {
                Site site = await db.Sites.FindAsync(id);
                if (site == null)
                {
                    return NotFound();
                }
                return Ok(site);
            }
        }

        // PUT: api/Sites/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSite(Guid id, Site site)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != site.SiteId)
            {
                return BadRequest();
            }
            using (SportsContext db = new SportsContext())
            {
                db.Entry(site).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (db.Sites.Count(e => e.SiteId == id) <= 0)
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

        // POST: api/Sites
        [ResponseType(typeof(Site))]
        public async Task<IHttpActionResult> PostSite(Site site)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SportsContext db = new SportsContext())
            {
                db.Sites.Add(site);
                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = site.SiteId }, site);
            }
        }

        // DELETE: api/Sites/5
        [ResponseType(typeof(Site))]
        public async Task<IHttpActionResult> DeleteSite(Guid id)
        {
            using (SportsContext db = new SportsContext())
            {
                Site site = await db.Sites.FindAsync(id);
                if (site == null)
                {
                    return NotFound();
                }

                db.Sites.Remove(site);
                await db.SaveChangesAsync();

                return Ok(site);
            }
        }
    }
}