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
    public class CalificacionsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Calificacions
        public async Task<ActionResult> Index()
        {
            var calificacions = db.Calificacions.Include(c => c.Participante_Forma).Include(c => c.Usuario);
            return View(await calificacions.ToListAsync());
        }

        // GET: Calificacions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = await db.Calificacions.FindAsync(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            return View(calificacion);
        }

        // GET: Calificacions/Create
        public ActionResult Create()
        {
            ViewBag.idFicha = new SelectList(db.Participante_Forma, "idFicha", "Nombre_Forma");
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario");
            return View();
        }

        // POST: Calificacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idCalif,idFicha,idUsuario,Calificaion")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Calificacions.Add(calificacion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idFicha = new SelectList(db.Participante_Forma, "idFicha", "Nombre_Forma", calificacion.idFicha);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", calificacion.idUsuario);
            return View(calificacion);
        }

        // GET: Calificacions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = await db.Calificacions.FindAsync(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFicha = new SelectList(db.Participante_Forma, "idFicha", "Nombre_Forma", calificacion.idFicha);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", calificacion.idUsuario);
            return View(calificacion);
        }

        // POST: Calificacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCalif,idFicha,idUsuario,Calificaion")] Calificacion calificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificacion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idFicha = new SelectList(db.Participante_Forma, "idFicha", "Nombre_Forma", calificacion.idFicha);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", calificacion.idUsuario);
            return View(calificacion);
        }

        // GET: Calificacions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacion calificacion = await db.Calificacions.FindAsync(id);
            if (calificacion == null)
            {
                return HttpNotFound();
            }
            return View(calificacion);
        }

        // POST: Calificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Calificacion calificacion = await db.Calificacions.FindAsync(id);
            db.Calificacions.Remove(calificacion);
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
