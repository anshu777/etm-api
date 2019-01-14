using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ETM.Repository.Models;
using ETM.Service;
using ETM.Web.Common;
using System.Web.Http.Cors;

namespace ETM.Web.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ExitClearancesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/ExitClearances
        public IQueryable<ExitClearance> GetExitClearances()
        {
            return db.ExitClearances;
        }

        // GET: api/ExitClearances/5
        [ResponseType(typeof(ExitClearance))]
        public IHttpActionResult GetExitClearance(int id)
        {
            ExitClearance exitClearance = db.ExitClearances.Find(id);
            if (exitClearance == null)
            {
                return this.JsonDataResult("null");
            }

            return Ok(exitClearance);
        }

        // PUT: api/ExitClearances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExitClearance(int id, ExitClearance exitClearance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exitClearance.Id)
            {
                return BadRequest();
            }

            db.Entry(exitClearance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExitClearanceExists(id))
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

        // POST: api/ExitClearances
        [ResponseType(typeof(ExitClearance))]
        public IHttpActionResult PostExitClearance(ExitClearance exitClearance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExitClearances.Add(exitClearance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = exitClearance.Id }, exitClearance);
        }

        // DELETE: api/ExitClearances/5
        [ResponseType(typeof(ExitClearance))]
        public IHttpActionResult DeleteExitClearance(int id)
        {
            ExitClearance exitClearance = db.ExitClearances.Find(id);
            if (exitClearance == null)
            {
                return NotFound();
            }

            db.ExitClearances.Remove(exitClearance);
            db.SaveChanges();

            return Ok(exitClearance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExitClearanceExists(int id)
        {
            return db.ExitClearances.Count(e => e.Id == id) > 0;
        }
    }
}