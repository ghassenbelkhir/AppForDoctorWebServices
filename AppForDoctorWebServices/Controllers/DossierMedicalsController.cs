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
    public class DossierMedicalsController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/DossierMedicals
        public IQueryable<DossierMedical> GetDossierMedicals()
        {
            return db.DossierMedicals;
        }

        // GET: api/DossierMedicals/5
        [ResponseType(typeof(DossierMedical))]
        public IHttpActionResult GetDossierMedical(int id)
        {
            DossierMedical dossierMedical = db.DossierMedicals.Find(id);
            if (dossierMedical == null)
            {
                return NotFound();
            }

            return Ok(dossierMedical);
        }

        // PUT: api/DossierMedicals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDossierMedical(int id, DossierMedical dossierMedical)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dossierMedical.PatientId)
            {
                return BadRequest();
            }

            db.Entry(dossierMedical).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DossierMedicalExists(id))
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

        // POST: api/DossierMedicals
        [ResponseType(typeof(DossierMedical))]
        public IHttpActionResult PostDossierMedical(DossierMedical dossierMedical)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DossierMedicals.Add(dossierMedical);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DossierMedicalExists(dossierMedical.PatientId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dossierMedical.PatientId }, dossierMedical);
        }

        // DELETE: api/DossierMedicals/5
        [ResponseType(typeof(DossierMedical))]
        public IHttpActionResult DeleteDossierMedical(int id)
        {
            DossierMedical dossierMedical = db.DossierMedicals.Find(id);
            if (dossierMedical == null)
            {
                return NotFound();
            }

            db.DossierMedicals.Remove(dossierMedical);
            db.SaveChanges();

            return Ok(dossierMedical);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DossierMedicalExists(int id)
        {
            return db.DossierMedicals.Count(e => e.PatientId == id) > 0;
        }
    }
}