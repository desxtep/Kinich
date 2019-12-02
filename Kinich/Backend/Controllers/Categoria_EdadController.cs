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
    public class Categoria_EdadController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Categoria_Edad
        public async Task<ActionResult> Index()
        {
            return View(await db.Categoria_Edad.ToListAsync());
        }

        // GET: Categoria_Edad/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria_Edad categoria_Edad = await db.Categoria_Edad.FindAsync(id);
            if (categoria_Edad == null)
            {
                return HttpNotFound();
            }
            return View(categoria_Edad);
        }

        // GET: Categoria_Edad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria_Edad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idCategoria_Edad,NCatE,Edad_min,Edad_max")] Categoria_Edad categoria_Edad)
        {
            if (ModelState.IsValid)
            {
                db.Categoria_Edad.Add(categoria_Edad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(categoria_Edad);
        }

        // GET: Categoria_Edad/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria_Edad categoria_Edad = await db.Categoria_Edad.FindAsync(id);
            if (categoria_Edad == null)
            {
                return HttpNotFound();
            }
            return View(categoria_Edad);
        }

        // POST: Categoria_Edad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCategoria_Edad,NCatE,Edad_min,Edad_max")] Categoria_Edad categoria_Edad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria_Edad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoria_Edad);
        }

        // GET: Categoria_Edad/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria_Edad categoria_Edad = await db.Categoria_Edad.FindAsync(id);
            if (categoria_Edad == null)
            {
                return HttpNotFound();
            }
            return View(categoria_Edad);
        }

        // POST: Categoria_Edad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Categoria_Edad categoria_Edad = await db.Categoria_Edad.FindAsync(id);
            db.Categoria_Edad.Remove(categoria_Edad);
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
