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
using AppForDoctorWebServices.Context;
using AppForDoctorWebServices.Models;

namespace AppForDoctorWebServices.Controllers
{
    public class FicheDeSoinsController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/FicheDeSoins
        public IQueryable<FicheDeSoins> GetFicheDeSoins()
        {
            return db.FicheDeSoins;
        }

        // GET: api/FicheDeSoins/5
        [ResponseType(typeof(FicheDeSoins))]
        public IHttpActionResult GetFicheDeSoins(int id)
        {
            FicheDeSoins ficheDeSoins = db.FicheDeSoins.Find(id);
            if (ficheDeSoins == null)
            {
                return NotFound();
            }

            return Ok(ficheDeSoins);
        }

        // PUT: api/FicheDeSoins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFicheDeSoins(int id, FicheDeSoins ficheDeSoins)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ficheDeSoins.HospitalisationId)
            {
                return BadRequest();
            }

            db.Entry(ficheDeSoins).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FicheDeSoinsExists(id))
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

        // POST: api/FicheDeSoins
        [ResponseType(typeof(FicheDeSoins))]
        public IHttpActionResult PostFicheDeSoins(FicheDeSoins ficheDeSoins)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FicheDeSoins.Add(ficheDeSoins);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FicheDeSoinsExists(ficheDeSoins.HospitalisationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ficheDeSoins.HospitalisationId }, ficheDeSoins);
        }

        // DELETE: api/FicheDeSoins/5
        [ResponseType(typeof(FicheDeSoins))]
        public IHttpActionResult DeleteFicheDeSoins(int id)
        {
            FicheDeSoins ficheDeSoins = db.FicheDeSoins.Find(id);
            if (ficheDeSoins == null)
            {
                return NotFound();
            }

            db.FicheDeSoins.Remove(ficheDeSoins);
            db.SaveChanges();

            return Ok(ficheDeSoins);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FicheDeSoinsExists(int id)
        {
            return db.FicheDeSoins.Count(e => e.HospitalisationId == id) > 0;
        }
    }
}