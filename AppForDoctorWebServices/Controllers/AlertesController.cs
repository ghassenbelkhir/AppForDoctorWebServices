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
    public class AlertesController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/Alertes
        public IQueryable<Alerte> GetAlertes()
        {
            return db.Alertes;
        }

        // GET: api/Alertes/5
        [ResponseType(typeof(Alerte))]
        public IHttpActionResult GetAlerte(int id)
        {
            Alerte alerte = db.Alertes.Find(id);
            if (alerte == null)
            {
                return NotFound();
            }

            return Ok(alerte);
        }

        // PUT: api/Alertes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlerte(int id, Alerte alerte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alerte.AlerteId)
            {
                return BadRequest();
            }

            db.Entry(alerte).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlerteExists(id))
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

        // POST: api/Alertes
        [ResponseType(typeof(Alerte))]
        public IHttpActionResult PostAlerte(Alerte alerte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alertes.Add(alerte);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = alerte.AlerteId }, alerte);
        }

        // DELETE: api/Alertes/5
        [ResponseType(typeof(Alerte))]
        public IHttpActionResult DeleteAlerte(int id)
        {
            Alerte alerte = db.Alertes.Find(id);
            if (alerte == null)
            {
                return NotFound();
            }

            db.Alertes.Remove(alerte);
            db.SaveChanges();

            return Ok(alerte);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlerteExists(int id)
        {
            return db.Alertes.Count(e => e.AlerteId == id) > 0;
        }

        [Route("Dossier/{DossierId}/Alertes")]
        [HttpGet]
        public IEnumerable<Alerte> FindAlerteByDossier(int DossierId)

        {
            var query = from i in db.Alertes
                        where i.DossierMedical.PatientId == DossierId
                        select i;
            return query.ToList();
        }
    }
}