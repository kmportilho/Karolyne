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
using HumanResources.Models;

namespace HumanResources.Controllers
{
    public class jobsController : ApiController
    {
        private HRContext db = new HRContext();

        // GET: api/jobs
        public IQueryable<JOBS> GetJOBS()
        {
            return db.JOBS;
        }

        // GET: api/jobs/5
        [ResponseType(typeof(JOBS))]
        public IHttpActionResult GetJOBS(int id)
        {
            JOBS jOBS = db.JOBS.Find(id);
            if (jOBS == null)
            {
                return NotFound();
            }

            return Ok(jOBS);
        }

        // PUT: api/jobs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJOBS(int id, JOBS jOBS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jOBS.JOB_ID)
            {
                return BadRequest();
            }

            db.Entry(jOBS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JOBSExists(id))
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

        // POST: api/jobs
        [ResponseType(typeof(JOBS))]
        public IHttpActionResult PostJOBS(JOBS jOBS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JOBS.Add(jOBS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jOBS.JOB_ID }, jOBS);
        }

        // DELETE: api/jobs/5
        [ResponseType(typeof(JOBS))]
        public IHttpActionResult DeleteJOBS(int id)
        {
            JOBS jOBS = db.JOBS.Find(id);
            if (jOBS == null)
            {
                return NotFound();
            }

            db.JOBS.Remove(jOBS);
            db.SaveChanges();

            return Ok(jOBS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JOBSExists(int id)
        {
            return db.JOBS.Count(e => e.JOB_ID == id) > 0;
        }
    }
}