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
    public class CombatesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Combates
        public async Task<ActionResult> Index()
        {
            var combates = db.Combates.Include(c => c.Torneo).Include(c => c.Usuario);
            return View(await combates.ToListAsync());
        }

        // GET: Combates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combate combate = await db.Combates.FindAsync(id);
            if (combate == null)
            {
                return HttpNotFound();
            }
            return View(combate);
        }

        // GET: Combates/Create
        public ActionResult Create()
        {
            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre");
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario");
            return View();
        }

        // POST: Combates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idCombate,idTorneo,Id_part1,Id_part2,idUsuario,nivel")] Combate combate)
        {
            if (ModelState.IsValid)
            {
                db.Combates.Add(combate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre", combate.idTorneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", combate.idUsuario);
            return View(combate);
        }

        // GET: Combates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combate combate = await db.Combates.FindAsync(id);
            if (combate == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre", combate.idTorneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", combate.idUsuario);
            return View(combate);
        }

        // POST: Combates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCombate,idTorneo,Id_part1,Id_part2,idUsuario,nivel")] Combate combate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(combate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre", combate.idTorneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", combate.idUsuario);
            return View(combate);
        }

        // GET: Combates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combate combate = await db.Combates.FindAsync(id);
            if (combate == null)
            {
                return HttpNotFound();
            }
            return View(combate);
        }

        // POST: Combates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Combate combate = await db.Combates.FindAsync(id);
            db.Combates.Remove(combate);
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
