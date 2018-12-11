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
    public class MedecinsController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/Medecins
        public IQueryable<Medecin> GetMedecins()
        {
            return db.Medecins;
        }

        // GET: api/Medecins/5
        [ResponseType(typeof(Medecin))]
        public IHttpActionResult GetMedecin(int id)
        {
            Medecin medecin = db.Medecins.Find(id);
            if (medecin == null)
            {
                return NotFound();
            }

            return Ok(medecin);
        }

        // PUT: api/Medecins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedecin(int id, Medecin medecin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medecin.PersonneId)
            {
                return BadRequest();
            }

            db.Entry(medecin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedecinExists(id))
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

        // POST: api/Medecins
        [ResponseType(typeof(Medecin))]
        public IHttpActionResult PostMedecin(Medecin medecin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medecins.Add(medecin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medecin.PersonneId }, medecin);
        }

        // DELETE: api/Medecins/5
        [ResponseType(typeof(Medecin))]
        public IHttpActionResult DeleteMedecin(int id)
        {
            Medecin medecin = db.Medecins.Find(id);
            if (medecin == null)
            {
                return NotFound();
            }

            db.Medecins.Remove(medecin);
            db.SaveChanges();

            return Ok(medecin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedecinExists(int id)
        {
            return db.Medecins.Count(e => e.PersonneId == id) > 0;
        }

        [Route("Dossier/{PersonneId}/{MotDePasse}/Medecin")]
        [HttpGet]
        public IEnumerable<Medecin> FindMedecinByMotDePasse(int PersonneId, string MotDePasse)

        {
            var query = from i in db.Medecins
                        where i.PersonneId== PersonneId && i.Motdepasse==MotDePasse
                        select i;
            return query.ToList();
        }


        [Route("medecin/{PersonneId}/{MotDePasse}/Medecin")]
        [HttpGet]
        public Medecin FindMedecin(int PersonneId, string MotDePasse)

        {
            var query = from i in db.Medecins
                        where i.PersonneId == PersonneId && i.Motdepasse == MotDePasse
                        select i;
            Medecin med = (Medecin)query.FirstOrDefault();
            return med;
        }
    }
}