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
    public class SportCategoriesController : ApiController
    {
        private SportsContext db = new SportsContext();

        // GET: api/SportCategories
        public IQueryable<SportCategory> GetSportCategories()
        {
            using (SportsContext db = new SportsContext())
            {
                return db.SportCategories;
            }
        }

        // GET: api/SportCategories/5
        [ResponseType(typeof(SportCategory))]
        public async Task<IHttpActionResult> GetSportCategory(Guid id)
        {
            using (SportsContext db = new SportsContext())
            {
                SportCategory sportCategory = await db.SportCategories.FindAsync(id);
                if (sportCategory == null)
                {
                    return NotFound();
                }

                return Ok(sportCategory);
            }
        }

        // PUT: api/SportCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSportCategory(Guid id, SportCategory sportCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sportCategory.CategoryId)
            {
                return BadRequest();
            }
            using (SportsContext db = new SportsContext())
            {
                db.Entry(sportCategory).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (db.SportCategories.Count(e => e.CategoryId == id) <= 0)
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

        // POST: api/SportCategories
        [ResponseType(typeof(SportCategory))]
        public async Task<IHttpActionResult> PostSportCategory(SportCategory sportCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (SportsContext db = new SportsContext())
            {
                db.SportCategories.Add(sportCategory);
                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = sportCategory.CategoryId }, sportCategory);
            }
        }

        // DELETE: api/SportCategories/5
        [ResponseType(typeof(SportCategory))]
        public async Task<IHttpActionResult> DeleteSportCategory(Guid id)
        {
            using (SportsContext db = new SportsContext())
            {
                SportCategory sportCategory = await db.SportCategories.FindAsync(id);
                if (sportCategory == null)
                {
                    return NotFound();
                }

                db.SportCategories.Remove(sportCategory);
                await db.SaveChangesAsync();

                return Ok(sportCategory);
            }
        }
    }
}