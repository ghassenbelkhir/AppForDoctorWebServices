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
    public class ConsultationsController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/Consultations
        public IQueryable<Consultation> GetConsultations()
        {
            return db.Consultations;
        }

        // GET: api/Consultations/5
        [ResponseType(typeof(Consultation))]
        public IHttpActionResult GetConsultation(int id)
        {
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return NotFound();
            }

            return Ok(consultation);
        }

        // PUT: api/Consultations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConsultation(int id, Consultation consultation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consultation.ConsultationId)
            {
                return BadRequest();
            }

            db.Entry(consultation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultationExists(id))
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

        // POST: api/Consultations
        [ResponseType(typeof(Consultation))]
        public IHttpActionResult PostConsultation(Consultation consultation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consultations.Add(consultation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = consultation.ConsultationId }, consultation);
        }

        // DELETE: api/Consultations/5
        [ResponseType(typeof(Consultation))]
        public IHttpActionResult DeleteConsultation(int id)
        {
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return NotFound();
            }

            db.Consultations.Remove(consultation);
            db.SaveChanges();

            return Ok(consultation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsultationExists(int id)
        {
            return db.Consultations.Count(e => e.ConsultationId == id) > 0;
        }

        [Route("Dossier/{DossierId}/Consultations")]
        [HttpGet]
        public IEnumerable<Consultation> FindConsultationByDossier(int DossierId)

        {
            var query = from i in db.Consultations
                        where i.DossierMedical.PatientId == DossierId
                        select i;
            return query.ToList();
        }
    }
}