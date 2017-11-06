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
using Web.Models.Contexto;
using WebApplication.Models;

namespace WebApplication.API
{
    public class BichosController : ApiController
    {
        private MeuContexto db = new MeuContexto();

        // GET: api/Bichos
        public IQueryable<Bicho> GetBichoes()
        {
            return db.Bichoes;
        }

        // GET: api/Bichos/5
        [ResponseType(typeof(Bicho))]
        public IHttpActionResult GetBicho(int id)
        {
            Bicho bicho = db.Bichoes.Find(id);
            if (bicho == null)
            {
                return NotFound();
            }

            return Ok(bicho);
        }

        // PUT: api/Bichos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBicho(int id, Bicho bicho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bicho.BichoID)
            {
                return BadRequest();
            }

            db.Entry(bicho).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BichoExists(id))
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

        // POST: api/Bichos
        [ResponseType(typeof(Bicho))]
        public IHttpActionResult PostBicho(Bicho bicho)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bichoes.Add(bicho);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bicho.BichoID }, bicho);
        }

        // DELETE: api/Bichos/5
        [ResponseType(typeof(Bicho))]
        public IHttpActionResult DeleteBicho(int id)
        {
            Bicho bicho = db.Bichoes.Find(id);
            if (bicho == null)
            {
                return NotFound();
            }

            db.Bichoes.Remove(bicho);
            db.SaveChanges();

            return Ok(bicho);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BichoExists(int id)
        {
            return db.Bichoes.Count(e => e.BichoID == id) > 0;
        }
    }
}