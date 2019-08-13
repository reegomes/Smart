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
using Start.Library;
using Start.Models;

namespace Start.Controllers
{
    public class ResidencialsController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Residencials
        public IQueryable<Residencial> GetResidencials()
        {
            return db.Residencials;
        }

        // GET: api/Residencials/5
        [ResponseType(typeof(Residencial))]
        public async Task<IHttpActionResult> GetResidencial(int id)
        {
            Residencial residencial = await db.Residencials.FindAsync(id);
            if (residencial == null)
            {
                return NotFound();
            }

            return Ok(residencial);
        }

        // PUT: api/Residencials/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutResidencial(int id, Residencial residencial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != residencial.Id)
            {
                return BadRequest();
            }

            db.Entry(residencial).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidencialExists(id))
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

        // POST: api/Residencials
        [ResponseType(typeof(Residencial))]
        public async Task<IHttpActionResult> PostResidencial(Residencial residencial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Residencials.Add(residencial);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = residencial.Id }, residencial);
        }

        // DELETE: api/Residencials/5
        [ResponseType(typeof(Residencial))]
        public async Task<IHttpActionResult> DeleteResidencial(int id)
        {
            Residencial residencial = await db.Residencials.FindAsync(id);
            if (residencial == null)
            {
                return NotFound();
            }

            db.Residencials.Remove(residencial);
            await db.SaveChangesAsync();

            return Ok(residencial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResidencialExists(int id)
        {
            return db.Residencials.Count(e => e.Id == id) > 0;
        }
    }
}