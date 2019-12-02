using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Backend.Controllers
{
    [Authorize]
    public class Categoria_PesoController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Categoria_Peso
        public async Task<ActionResult> Index()
        {
            return View(await db.Categoria_Peso.ToListAsync());
        }

        // GET: Categoria_Peso/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria_Peso categoria_Peso = await db.Categoria_Peso.FindAsync(id);
            if (categoria_Peso == null)
            {
                return HttpNotFound();
            }
            return View(categoria_Peso);
        }

        // GET: Categoria_Peso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria_Peso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idCategoria_Peso,NCatP,Peso_min,Peso_max")] Categoria_Peso categoria_Peso)
        {
            if (ModelState.IsValid)
            {
                db.Categoria_Peso.Add(categoria_Peso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(categoria_Peso);
        }

        // GET: Categoria_Peso/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria_Peso categoria_Peso = await db.Categoria_Peso.FindAsync(id);
            if (categoria_Peso == null)
            {
                return HttpNotFound();
            }
            return View(categoria_Peso);
        }

        // POST: Categoria_Peso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCategoria_Peso,NCatP,Peso_min,Peso_max")] Categoria_Peso categoria_Peso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria_Peso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoria_Peso);
        }

        // GET: Categoria_Peso/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria_Peso categoria_Peso = await db.Categoria_Peso.FindAsync(id);
            if (categoria_Peso == null)
            {
                return HttpNotFound();
            }
            return View(categoria_Peso);
        }

        // POST: Categoria_Peso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Categoria_Peso categoria_Peso = await db.Categoria_Peso.FindAsync(id);
            db.Categoria_Peso.Remove(categoria_Peso);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
