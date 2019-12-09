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
    public class Participante_CombateController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Participante_Combate
        public async Task<ActionResult> Index()
        {
            var participante_Combate = db.Participante_Combate.Include(p => p.Torneo).Include(p => p.Usuario);
            return View(await participante_Combate.ToListAsync());
        }

        // GET: Participante_Combate/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante_Combate participante_Combate = await db.Participante_Combate.FindAsync(id);
            if (participante_Combate == null)
            {
                return HttpNotFound();
            }
            return View(participante_Combate);
        }

        // GET: Participante_Combate/Create
        public ActionResult Create()
        {
            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre");
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario");
            return View();
        }

        // POST: Participante_Combate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idFicha,idUsuario,idTorneo,Area,Color,Hora_Aprox,Resultado")] Participante_Combate participante_Combate)
        {
            if (ModelState.IsValid)
            {
                db.Participante_Combate.Add(participante_Combate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre", participante_Combate.idTorneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", participante_Combate.idUsuario);
            return View(participante_Combate);
        }

        // GET: Participante_Combate/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante_Combate participante_Combate = await db.Participante_Combate.FindAsync(id);
            if (participante_Combate == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre", participante_Combate.idTorneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", participante_Combate.idUsuario);
            return View(participante_Combate);
        }

        // POST: Participante_Combate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idFicha,idUsuario,idTorneo,Area,Color,Hora_Aprox,Resultado")] Participante_Combate participante_Combate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participante_Combate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre", participante_Combate.idTorneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", participante_Combate.idUsuario);
            return View(participante_Combate);
        }

        // GET: Participante_Combate/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante_Combate participante_Combate = await db.Participante_Combate.FindAsync(id);
            if (participante_Combate == null)
            {
                return HttpNotFound();
            }
            return View(participante_Combate);
        }

        // POST: Participante_Combate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Participante_Combate participante_Combate = await db.Participante_Combate.FindAsync(id);
            db.Participante_Combate.Remove(participante_Combate);
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
