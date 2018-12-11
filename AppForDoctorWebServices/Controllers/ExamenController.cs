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
    public class ExamenController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/Examen
        public IQueryable<Examen> GetExamen()
        {
            return db.Examen;
        }

        // GET: api/Examen/5
        [ResponseType(typeof(Examen))]
        public IHttpActionResult GetExamen(int id)
        {
            Examen examen = db.Examen.Find(id);
            if (examen == null)
            {
                return NotFound();
            }

            return Ok(examen);
        }

        // PUT: api/Examen/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExamen(int id, Examen examen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != examen.ExamenId)
            {
                return BadRequest();
            }

            db.Entry(examen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamenExists(id))
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

        // POST: api/Examen
        [ResponseType(typeof(Examen))]
        public IHttpActionResult PostExamen(Examen examen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Examen.Add(examen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = examen.ExamenId }, examen);
        }

        // DELETE: api/Examen/5
        [ResponseType(typeof(Examen))]
        public IHttpActionResult DeleteExamen(int id)
        {
            Examen examen = db.Examen.Find(id);
            if (examen == null)
            {
                return NotFound();
            }

            db.Examen.Remove(examen);
            db.SaveChanges();

            return Ok(examen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExamenExists(int id)
        {
            return db.Examen.Count(e => e.ExamenId == id) > 0;
        }

        [Route("Dossier/{DossierId}/Examens")]
        [HttpGet]
        public IEnumerable<Examen> FindExamenByDossier(int DossierId)

        {
            var query = from i in db.Examen
                        where i.DossierMedical.PatientId == DossierId
                        select i;
            return query.ToList();
        }


        [Route("Date/{date}/Examens")]
        [HttpGet]
        public IEnumerable<Examen> FindExamenByDate(DateTime date)

        {
            var query = from i in db.Examen
                        where i.Date==date
                        select i;
            return query.ToList();
        }
    }
}