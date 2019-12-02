using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Domain;

namespace Api.Controllers
{
    public class Categoria_PesoController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Categoria_Peso
        public IQueryable<Categoria_Peso> GetCategoria_Peso()
        {
            return db.Categoria_Peso;
        }

        // GET: api/Categoria_Peso/5
        [ResponseType(typeof(Categoria_Peso))]
        public async Task<IHttpActionResult> GetCategoria_Peso(int id)
        {
            Categoria_Peso categoria_Peso = await db.Categoria_Peso.FindAsync(id);
            if (categoria_Peso == null)
            {
                return NotFound();
            }

            return Ok(categoria_Peso);
        }

        // PUT: api/Categoria_Peso/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategoria_Peso(int id, Categoria_Peso categoria_Peso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria_Peso.idCategoria_Peso)
            {
                return BadRequest();
            }

            db.Entry(categoria_Peso).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Categoria_PesoExists(id))
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

        // POST: api/Categoria_Peso
        [ResponseType(typeof(Categoria_Peso))]
        public async Task<IHttpActionResult> PostCategoria_Peso(Categoria_Peso categoria_Peso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categoria_Peso.Add(categoria_Peso);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = categoria_Peso.idCategoria_Peso }, categoria_Peso);
        }

        // DELETE: api/Categoria_Peso/5
        [ResponseType(typeof(Categoria_Peso))]
        public async Task<IHttpActionResult> DeleteCategoria_Peso(int id)
        {
            Categoria_Peso categoria_Peso = await db.Categoria_Peso.FindAsync(id);
            if (categoria_Peso == null)
            {
                return NotFound();
            }

            db.Categoria_Peso.Remove(categoria_Peso);
            await db.SaveChangesAsync();

            return Ok(categoria_Peso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Categoria_PesoExists(int id)
        {
            return db.Categoria_Peso.Count(e => e.idCategoria_Peso == id) > 0;
        }
    }
}