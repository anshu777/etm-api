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
using ETM.Service.Services;
using System.Web.Http.Cors;
using ETM.Service.Interfaces;
using System.Threading.Tasks;
using ETM.Web.Common;

namespace ETM.Web.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrgChartsController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();
        private IOrgChartService _orgChartService;

        public OrgChartsController(IOrgChartService orgChartService)
        {
            _orgChartService = orgChartService;
        }

        // GET: api/OrgCharts
        [Route("api/getByProjectId/{id}")]
        public async Task<IHttpActionResult> GetOrgCharts(int id)
        {try
            {
                var result = await _orgChartService.getOrgChart(id);
                return this.JsonDataResult(result);
            }catch(Exception exception)
            {
                throw exception;
            }
        }

        /*
        // GET: api/OrgCharts/5
        [ResponseType(typeof(OrgChart))]
        public IHttpActionResult GetOrgChart(int id)
        {
            OrgChart orgChart = db.OrgCharts.Find(id);
            if (orgChart == null)
            {
                return NotFound();
            }

            return Ok(orgChart);
        }

        // PUT: api/OrgCharts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrgChart(int id, OrgChart orgChart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orgChart.id)
            {
                return BadRequest();
            }

            db.Entry(orgChart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrgChartExists(id))
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

        // POST: api/OrgCharts
        [ResponseType(typeof(OrgChart))]
        public IHttpActionResult PostOrgChart(OrgChart orgChart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrgCharts.Add(orgChart);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orgChart.id }, orgChart);
        }

        // DELETE: api/OrgCharts/5
        [ResponseType(typeof(OrgChart))]
        public IHttpActionResult DeleteOrgChart(int id)
        {
            OrgChart orgChart = db.OrgCharts.Find(id);
            if (orgChart == null)
            {
                return NotFound();
            }

            db.OrgCharts.Remove(orgChart);
            db.SaveChanges();

            return Ok(orgChart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrgChartExists(int id)
        {
            return db.OrgCharts.Count(e => e.id == id) > 0;
        }
        */
    }
}