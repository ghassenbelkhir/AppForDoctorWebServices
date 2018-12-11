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
    public class DemandeExamenController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/DemandeExamen
        public IQueryable<DemandeExamen> GetDemandeExamen()
        {
            return db.DemandeExamen;
        }

        // GET: api/DemandeExamen/5
        [ResponseType(typeof(DemandeExamen))]
        public IHttpActionResult GetDemandeExamen(int id)
        {
            DemandeExamen demandeExamen = db.DemandeExamen.Find(id);
            if (demandeExamen == null)
            {
                return NotFound();
            }

            return Ok(demandeExamen);
        }

        // PUT: api/DemandeExamen/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDemandeExamen(int id, DemandeExamen demandeExamen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != demandeExamen.DemandeExamenId)
            {
                return BadRequest();
            }

            db.Entry(demandeExamen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemandeExamenExists(id))
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

        // POST: api/DemandeExamen
        [ResponseType(typeof(DemandeExamen))]
        public IHttpActionResult PostDemandeExamen(DemandeExamen demandeExamen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DemandeExamen.Add(demandeExamen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = demandeExamen.DemandeExamenId }, demandeExamen);
        }

        // DELETE: api/DemandeExamen/5
        [ResponseType(typeof(DemandeExamen))]
        public IHttpActionResult DeleteDemandeExamen(int id)
        {
            DemandeExamen demandeExamen = db.DemandeExamen.Find(id);
            if (demandeExamen == null)
            {
                return NotFound();
            }

            db.DemandeExamen.Remove(demandeExamen);
            db.SaveChanges();

            return Ok(demandeExamen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DemandeExamenExists(int id)
        {
            return db.DemandeExamen.Count(e => e.DemandeExamenId == id) > 0;
        }
    }
}