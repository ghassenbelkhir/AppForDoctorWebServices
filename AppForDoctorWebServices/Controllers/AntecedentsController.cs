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
    public class AntecedentsController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/Antecedents
        public IQueryable<Antecedent> GetAntecedents()
        {
            return db.Antecedents;
        }

        // GET: api/Antecedents/5
        [ResponseType(typeof(Antecedent))]
        public IHttpActionResult GetAntecedent(int id)
        {
            Antecedent antecedent = db.Antecedents.Find(id);
            if (antecedent == null)
            {
                return NotFound();
            }

            return Ok(antecedent);
        }

        // PUT: api/Antecedents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAntecedent(int id, Antecedent antecedent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != antecedent.AntecedentId)
            {
                return BadRequest();
            }

            db.Entry(antecedent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AntecedentExists(id))
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

        // POST: api/Antecedents
        [ResponseType(typeof(Antecedent))]
        public IHttpActionResult PostAntecedent(Antecedent antecedent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Antecedents.Add(antecedent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = antecedent.AntecedentId }, antecedent);
        }

        // DELETE: api/Antecedents/5
        [ResponseType(typeof(Antecedent))]
        public IHttpActionResult DeleteAntecedent(int id)
        {
            Antecedent antecedent = db.Antecedents.Find(id);
            if (antecedent == null)
            {
                return NotFound();
            }

            db.Antecedents.Remove(antecedent);
            db.SaveChanges();

            return Ok(antecedent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AntecedentExists(int id)
        {
            return db.Antecedents.Count(e => e.AntecedentId == id) > 0;
        }

        [Route("Dossier/{DossierId}/Antecedents")]
        [HttpGet]
        public IEnumerable<Antecedent> FindAntecedentByCustomer(int DossierId)

        {
            var query = from i in db.Antecedents
                        where i.DossierMedical.PatientId == DossierId
                        select i;
            return query.ToList();
        }

    }
}