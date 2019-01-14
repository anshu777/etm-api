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
using ETM.Service.Interfaces;
using ETM.Repository.Dto;
using ETM.Web.Common;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Http.Cors;
using ETM.Service.Services;

namespace ETM.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MRFController : ApiController
    {
        private IMRFService _mrfService;
        public MRFController(IMRFService mrfService)
        {
            _mrfService = mrfService;
        }
        private DatabaseContext db = new DatabaseContext();

        // GET: api/MRF
        public IQueryable<MRF> GetMRF()
        {
            return db.MRF;
        }

        // GET: api/MRF/5
        [ResponseType(typeof(MRF))]
        public IHttpActionResult GetMRF(int id)
        {
            MRF mRF = db.MRF.Find(id);
            if (mRF == null)
            {
                return NotFound();
            }

            return Ok(mRF);
        }

        // PUT: api/MRF/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMRF(int id, MRF mRF)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mRF.id)
            {
                return BadRequest();
            }

            db.Entry(mRF).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MRFExists(id))
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

        // POST: api/MRF
        [ResponseType(typeof(MRF))]
        public async Task<IHttpActionResult> PostMRF(MRFDto mrf)
        {
            try
            {
                var result = await _mrfService.AddMRFRaise(mrf);
                return this.JsonDataResult(result);
            }
            catch(Exception e)  
            {
                return new InternalServerErrorResult(this);
            }
        }

        // DELETE: api/MRF/5
        [ResponseType(typeof(MRF))]
        public IHttpActionResult DeleteMRF(int id)
        {
            MRF mRF = db.MRF.Find(id);
            if (mRF == null)
            {
                return NotFound();
            }

            db.MRF.Remove(mRF);
            db.SaveChanges();

            return Ok(mRF);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MRFExists(int id)
        {
            return db.MRF.Count(e => e.id == id) > 0;
        }
    }
}