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
    public class ImmunisationsController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/Immunisations
        public IQueryable<Immunisation> GetImmunisations()
        {
            return db.Immunisations;
        }

        // GET: api/Immunisations/5
        [ResponseType(typeof(Immunisation))]
        public IHttpActionResult GetImmunisation(int id)
        {
            Immunisation immunisation = db.Immunisations.Find(id);
            if (immunisation == null)
            {
                return NotFound();
            }

            return Ok(immunisation);
        }

        // PUT: api/Immunisations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImmunisation(int id, Immunisation immunisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != immunisation.ImmunisationId)
            {
                return BadRequest();
            }

            db.Entry(immunisation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImmunisationExists(id))
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

        // POST: api/Immunisations
        [ResponseType(typeof(Immunisation))]
        public IHttpActionResult PostImmunisation(Immunisation immunisation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Immunisations.Add(immunisation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = immunisation.ImmunisationId }, immunisation);
        }

        // DELETE: api/Immunisations/5
        [ResponseType(typeof(Immunisation))]
        public IHttpActionResult DeleteImmunisation(int id)
        {
            Immunisation immunisation = db.Immunisations.Find(id);
            if (immunisation == null)
            {
                return NotFound();
            }

            db.Immunisations.Remove(immunisation);
            db.SaveChanges();

            return Ok(immunisation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImmunisationExists(int id)
        {
            return db.Immunisations.Count(e => e.ImmunisationId == id) > 0;
        }

        [Route("Dossier/{DossierId}/Immunisations")]
        [HttpGet]
        public IEnumerable<Immunisation> FindImmunisationByCustomer(int DossierId)

        {
            var query = from i in db.Immunisations
                        where i.DossierMedical.PatientId == DossierId
                        select i;
            return query.ToList();
        }
    }
}