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
    public class SportsCentersController : ApiController
    {
        /// <summary>
        /// 获取所有商户
        /// </summary>
        /// <returns></returns>
        public IQueryable<SportsCenter> GetSportsCenters()
        {
            using (SportsContext db = new SportsContext())
            {
                return db.SportsCenters;
            }
        }

        /// <summary>
        /// 获取指定商户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(SportsCenter))]
        public async Task<IHttpActionResult> GetSportsCenter(Guid id)
        {
            using (SportsContext db = new SportsContext())
            {
                SportsCenter sportsCenter = await db.SportsCenters.FindAsync(id);
                if (sportsCenter == null)
                {
                    return NotFound();
                }

                return Ok(sportsCenter);
            }
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sportsCenter"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSportsCenter(int id, SportsCenter sportsCenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sportsCenter.CenterId)
            {
                return BadRequest();
            }
            using (SportsContext db = new SportsContext())
            {
                db.Entry(sportsCenter).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (db.SportsCenters.Count(e => e.CenterId == id) <= 0)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 删除商户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(SportsCenter))]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            using (SportsContext db = new SportsContext())
            {
                SportsCenter sportsCenter = await db.SportsCenters.FindAsync(id);
                if (sportsCenter == null)
                {
                    return NotFound();
                }

                db.SportsCenters.Remove(sportsCenter);
                await db.SaveChangesAsync();

                return Ok(sportsCenter);
            }
        }

        /// <summary>
        /// 商户注册
        /// </summary>
        /// <param name="sportsCenter">商户信息</param>
        /// <returns></returns>
        [ResponseType(typeof(SportsCenter))]
        public async Task<IHttpActionResult> PostSportsCenter(SportsCenter sportsCenter)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SportsContext>());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (SportsContext db = new SportsContext())
            {

                db.SportsCenters.Add(sportsCenter);
                int effetiveRow = await db.SaveChangesAsync();
            }

            return CreatedAtRoute("DefaultApi", new { id = sportsCenter.CenterId }, sportsCenter);
        }
    }
}