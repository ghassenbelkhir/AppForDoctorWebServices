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
    public class ExamenImagesController : ApiController
    {
        private AppForDoctorWebServicesContext db = new AppForDoctorWebServicesContext();

        // GET: api/ExamenImages
        public IQueryable<ExamenImage> GetExamenImages()
        {
            return db.ExamenImages;
        }

        // GET: api/ExamenImages/5
        [ResponseType(typeof(ExamenImage))]
        public IHttpActionResult GetExamenImage(int id)
        {
            ExamenImage examenImage = db.ExamenImages.Find(id);
            if (examenImage == null)
            {
                return NotFound();
            }

            return Ok(examenImage);
        }

        // PUT: api/ExamenImages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExamenImage(int id, ExamenImage examenImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != examenImage.ExamenImageId)
            {
                return BadRequest();
            }

            db.Entry(examenImage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamenImageExists(id))
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

        // POST: api/ExamenImages
        [ResponseType(typeof(ExamenImage))]
        public IHttpActionResult PostExamenImage(ExamenImage examenImage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExamenImages.Add(examenImage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = examenImage.ExamenImageId }, examenImage);
        }

        // DELETE: api/ExamenImages/5
        [ResponseType(typeof(ExamenImage))]
        public IHttpActionResult DeleteExamenImage(int id)
        {
            ExamenImage examenImage = db.ExamenImages.Find(id);
            if (examenImage == null)
            {
                return NotFound();
            }

            db.ExamenImages.Remove(examenImage);
            db.SaveChanges();

            return Ok(examenImage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExamenImageExists(int id)
        {
            return db.ExamenImages.Count(e => e.ExamenImageId == id) > 0;
        }

        [Route("Images/{ExamenId}/ExamensImages")]
        [HttpGet]
        public IEnumerable<ExamenImage> FindExamenImagesByExamen(int ExamenId)

        {
            var query = from i in db.ExamenImages
                        where i.Examen.ExamenId==ExamenId
                        select i;
            return query.ToList();
        }
    }
}