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
using Domain;

namespace Api.Controllers
{
    [Authorize]
    public class Categoria_EdadController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Categoria_Edad
        public IQueryable<Categoria_Edad> GetCategoria_Edad()
        {
            return db.Categoria_Edad;
        }

        // GET: api/Categoria_Edad/5
        [ResponseType(typeof(Categoria_Edad))]
        public IHttpActionResult GetCategoria_Edad(int id)
        {
            Categoria_Edad categoria_Edad = db.Categoria_Edad.Find(id);
            if (categoria_Edad == null)
            {
                return NotFound();
            }

            return Ok(categoria_Edad);
        }

        // PUT: api/Categoria_Edad/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoria_Edad(int id, Categoria_Edad categoria_Edad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria_Edad.idCategoria_Edad)
            {
                return BadRequest();
            }

            db.Entry(categoria_Edad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Categoria_EdadExists(id))
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

        // POST: api/Categoria_Edad
        [ResponseType(typeof(Categoria_Edad))]
        public IHttpActionResult PostCategoria_Edad(Categoria_Edad categoria_Edad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categoria_Edad.Add(categoria_Edad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoria_Edad.idCategoria_Edad }, categoria_Edad);
        }

        // DELETE: api/Categoria_Edad/5
        [ResponseType(typeof(Categoria_Edad))]
        public IHttpActionResult DeleteCategoria_Edad(int id)
        {
            Categoria_Edad categoria_Edad = db.Categoria_Edad.Find(id);
            if (categoria_Edad == null)
            {
                return NotFound();
            }

            db.Categoria_Edad.Remove(categoria_Edad);
            db.SaveChanges();

            return Ok(categoria_Edad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Categoria_EdadExists(int id)
        {
            return db.Categoria_Edad.Count(e => e.idCategoria_Edad == id) > 0;
        }
    }
}