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
    public class Juez_TorneoController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Juez_Torneo
        public async Task<ActionResult> Index()
        {
            var juez_Torneo = db.Juez_Torneo.Include(j => j.Torneo).Include(j => j.Usuario);
            return View(await juez_Torneo.ToListAsync());
        }

        // GET: Juez_Torneo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juez_Torneo juez_Torneo = await db.Juez_Torneo.FindAsync(id);
            if (juez_Torneo == null)
            {
                return HttpNotFound();
            }
            return View(juez_Torneo);
        }

        // GET: Juez_Torneo/Create
        public ActionResult Create()
        {
            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre");
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario");
            return View();
        }

        // POST: Juez_Torneo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_user_juez,idUsuario,idTorneo,Area,Autorizado")] Juez_Torneo juez_Torneo)
        {
            if (ModelState.IsValid)
            {
                db.Juez_Torneo.Add(juez_Torneo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre", juez_Torneo.idTorneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", juez_Torneo.idUsuario);
            return View(juez_Torneo);
        }

        // GET: Juez_Torneo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juez_Torneo juez_Torneo = await db.Juez_Torneo.FindAsync(id);
            if (juez_Torneo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre", juez_Torneo.idTorneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", juez_Torneo.idUsuario);
            return View(juez_Torneo);
        }

        // POST: Juez_Torneo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_user_juez,idUsuario,idTorneo,Area,Autorizado")] Juez_Torneo juez_Torneo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juez_Torneo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre", juez_Torneo.idTorneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", juez_Torneo.idUsuario);
            return View(juez_Torneo);
        }

        // GET: Juez_Torneo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juez_Torneo juez_Torneo = await db.Juez_Torneo.FindAsync(id);
            if (juez_Torneo == null)
            {
                return HttpNotFound();
            }
            return View(juez_Torneo);
        }

        // POST: Juez_Torneo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Juez_Torneo juez_Torneo = await db.Juez_Torneo.FindAsync(id);
            db.Juez_Torneo.Remove(juez_Torneo);
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
