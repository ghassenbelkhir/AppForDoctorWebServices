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
    public class HospitalisationsController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/Hospitalisations
        public IQueryable<Hospitalisation> GetHospitalisations()
        {
            return db.Hospitalisations;
        }

        // GET: api/Hospitalisations/5
        [ResponseType(typeof(Hospitalisation))]
        public IHttpActionResult GetHospitalisation(int id)
        {
            Hospitalisation hospitalisation = db.Hospitalisations.Find(id);
            if (hospitalisation == null)
            {
                return NotFound();
            }

            return Ok(hospitalisation);
        }

        // PUT: api/Hospitalisations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHospitalisation(int id, Hospitalisation hospitalisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospitalisation.HospitalisationId)
            {
                return BadRequest();
            }

            db.Entry(hospitalisation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalisationExists(id))
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

        // POST: api/Hospitalisations
        [ResponseType(typeof(Hospitalisation))]
        public IHttpActionResult PostHospitalisation(Hospitalisation hospitalisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hospitalisations.Add(hospitalisation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hospitalisation.HospitalisationId }, hospitalisation);
        }

        // DELETE: api/Hospitalisations/5
        [ResponseType(typeof(Hospitalisation))]
        public IHttpActionResult DeleteHospitalisation(int id)
        {
            Hospitalisation hospitalisation = db.Hospitalisations.Find(id);
            if (hospitalisation == null)
            {
                return NotFound();
            }

            db.Hospitalisations.Remove(hospitalisation);
            db.SaveChanges();

            return Ok(hospitalisation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalisationExists(int id)
        {
            return db.Hospitalisations.Count(e => e.HospitalisationId == id) > 0;
        }

        [Route("Dossier/{DossierId}/Hospitalisations")]
        [HttpGet]
        public IEnumerable<Hospitalisation> FindHospitalisationsByDossier(int DossierId)

        {
            var query = from i in db.Hospitalisations
                        where i.DossierMedical.PatientId == DossierId
                        select i;
            return query.ToList();
        }
    }
}