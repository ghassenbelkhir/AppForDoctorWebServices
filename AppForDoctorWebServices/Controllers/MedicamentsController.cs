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
    public class MedicamentsController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/Medicaments
        public IQueryable<Medicament> GetMedicaments()
        {
            return db.Medicaments;
        }

        // GET: api/Medicaments/5
        [ResponseType(typeof(Medicament))]
        public IHttpActionResult GetMedicament(int id)
        {
            Medicament medicament = db.Medicaments.Find(id);
            if (medicament == null)
            {
                return NotFound();
            }

            return Ok(medicament);
        }

        // PUT: api/Medicaments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedicament(int id, Medicament medicament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicament.MedicamentId)
            {
                return BadRequest();
            }

            db.Entry(medicament).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentExists(id))
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

        // POST: api/Medicaments
        [ResponseType(typeof(Medicament))]
        public IHttpActionResult PostMedicament(Medicament medicament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medicaments.Add(medicament);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicament.MedicamentId }, medicament);
        }

        // DELETE: api/Medicaments/5
        [ResponseType(typeof(Medicament))]
        public IHttpActionResult DeleteMedicament(int id)
        {
            Medicament medicament = db.Medicaments.Find(id);
            if (medicament == null)
            {
                return NotFound();
            }

            db.Medicaments.Remove(medicament);
            db.SaveChanges();

            return Ok(medicament);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicamentExists(int id)
        {
            return db.Medicaments.Count(e => e.MedicamentId == id) > 0;
        }

        [Route("Dossier/{DossierId}/Medicaments")]
        [HttpGet]
        public IEnumerable<Medicament> FindMedicamentByDossier(int DossierId)

        {
            var query = from i in db.Medicaments
                        where i.DossierMedical.PatientId == DossierId
                        select i;
            return query.ToList();
        }
    }
}