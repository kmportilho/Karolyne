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
    public class employeesController : ApiController
    {
        private HRContext db = new HRContext();

        // GET: api/employees
        public IQueryable<EMPLOYEES> GetEMPLOYEES()
        {
            return db.EMPLOYEES;
        }

        // GET: api/employees/5
        [ResponseType(typeof(EMPLOYEES))]
        public IHttpActionResult GetEMPLOYEES(int id)
        {
            EMPLOYEES eMPLOYEES = db.EMPLOYEES.Find(id);
            if (eMPLOYEES == null)
            {
                return NotFound();
            }

            return Ok(eMPLOYEES);
        }

        // PUT: api/employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEMPLOYEES(int id, EMPLOYEES eMPLOYEES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eMPLOYEES.MANAGER_ID)
            {
                return BadRequest();
            }

            db.Entry(eMPLOYEES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPLOYEESExists(id))
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

        // POST: api/employees
        [ResponseType(typeof(EMPLOYEES))]
        public IHttpActionResult PostEMPLOYEES(EMPLOYEES eMPLOYEES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EMPLOYEES.Add(eMPLOYEES);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eMPLOYEES.MANAGER_ID }, eMPLOYEES);
        }

        // DELETE: api/employees/5
        [ResponseType(typeof(EMPLOYEES))]
        public IHttpActionResult DeleteEMPLOYEES(int id)
        {
            EMPLOYEES eMPLOYEES = db.EMPLOYEES.Find(id);
            if (eMPLOYEES == null)
            {
                return NotFound();
            }

            db.EMPLOYEES.Remove(eMPLOYEES);
            db.SaveChanges();

            return Ok(eMPLOYEES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EMPLOYEESExists(int id)
        {
            return db.EMPLOYEES.Count(e => e.MANAGER_ID == id) > 0;
        }
    }
}
