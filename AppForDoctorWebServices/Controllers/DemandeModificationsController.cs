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
    public class DemandeModificationsController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/DemandeModifications
        public IQueryable<DemandeModification> GetDemandeModifications()
        {
            return db.DemandeModifications;
        }

        // GET: api/DemandeModifications/5
        [ResponseType(typeof(DemandeModification))]
        public IHttpActionResult GetDemandeModification(int id)
        {
            DemandeModification demandeModification = db.DemandeModifications.Find(id);
            if (demandeModification == null)
            {
                return NotFound();
            }

            return Ok(demandeModification);
        }

        // PUT: api/DemandeModifications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDemandeModification(int id, DemandeModification demandeModification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != demandeModification.DemandeModificationId)
            {
                return BadRequest();
            }

            db.Entry(demandeModification).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DemandeModificationExists(id))
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

        // POST: api/DemandeModifications
        [ResponseType(typeof(DemandeModification))]
        public IHttpActionResult PostDemandeModification(DemandeModification demandeModification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DemandeModifications.Add(demandeModification);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = demandeModification.DemandeModificationId }, demandeModification);
        }

        // DELETE: api/DemandeModifications/5
        [ResponseType(typeof(DemandeModification))]
        public IHttpActionResult DeleteDemandeModification(int id)
        {
            DemandeModification demandeModification = db.DemandeModifications.Find(id);
            if (demandeModification == null)
            {
                return NotFound();
            }

            db.DemandeModifications.Remove(demandeModification);
            db.SaveChanges();

            return Ok(demandeModification);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DemandeModificationExists(int id)
        {
            return db.DemandeModifications.Count(e => e.DemandeModificationId == id) > 0;
        }
    }
}