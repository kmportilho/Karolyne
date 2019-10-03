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
    public class departmentsController : ApiController
    {
        private HRContext db = new HRContext();

        // GET: api/departments
        public IQueryable<DEPARTMENTS> GetDEPARTMENTS()
        {
            return db.DEPARTMENTS;
        }

        // GET: api/departments/5
        [ResponseType(typeof(DEPARTMENTS))]
        public IHttpActionResult GetDEPARTMENTS(int id)
        {
            DEPARTMENTS dEPARTMENTS = db.DEPARTMENTS.Find(id);
            if (dEPARTMENTS == null)
            {
                return NotFound();
            }

            return Ok(dEPARTMENTS);
        }

        // PUT: api/departments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDEPARTMENTS(int id, DEPARTMENTS dEPARTMENTS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dEPARTMENTS.DEPARTMENT_ID)
            {
                return BadRequest();
            }

            db.Entry(dEPARTMENTS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DEPARTMENTSExists(id))
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

        // POST: api/departments
        [ResponseType(typeof(DEPARTMENTS))]
        public IHttpActionResult PostDEPARTMENTS(DEPARTMENTS dEPARTMENTS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DEPARTMENTS.Add(dEPARTMENTS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dEPARTMENTS.DEPARTMENT_ID }, dEPARTMENTS);
        }

        // DELETE: api/departments/5
        [ResponseType(typeof(DEPARTMENTS))]
        public IHttpActionResult DeleteDEPARTMENTS(int id)
        {
            DEPARTMENTS dEPARTMENTS = db.DEPARTMENTS.Find(id);
            if (dEPARTMENTS == null)
            {
                return NotFound();
            }

            db.DEPARTMENTS.Remove(dEPARTMENTS);
            db.SaveChanges();

            return Ok(dEPARTMENTS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DEPARTMENTSExists(int id)
        {
            return db.DEPARTMENTS.Count(e => e.DEPARTMENT_ID == id) > 0;
        }
    }
}