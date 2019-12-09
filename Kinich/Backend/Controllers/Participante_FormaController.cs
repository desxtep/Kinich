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
    public class Participante_FormaController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Participante_Forma
        public async Task<ActionResult> Index()
        {
            var participante_Forma = db.Participante_Forma.Include(p => p.Torneo).Include(p => p.Usuario);
            return View(await participante_Forma.ToListAsync());
        }

        // GET: Participante_Forma/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante_Forma participante_Forma = await db.Participante_Forma.FindAsync(id);
            if (participante_Forma == null)
            {
                return HttpNotFound();
            }
            return View(participante_Forma);
        }

        // GET: Participante_Forma/Create
        public ActionResult Create()
        {
            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre");
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario");
            return View();
        }

        // POST: Participante_Forma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idFicha,idUsuario,idTorneo,Area,Nombre_Forma,Tipo_Forma,Hora_Aprox,Duracion,Cal,Resultado")] Participante_Forma participante_Forma)
        {
            if (ModelState.IsValid)
            {
                db.Participante_Forma.Add(participante_Forma);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre", participante_Forma.idTorneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", participante_Forma.idUsuario);
            return View(participante_Forma);
        }

        // GET: Participante_Forma/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante_Forma participante_Forma = await db.Participante_Forma.FindAsync(id);
            if (participante_Forma == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre", participante_Forma.idTorneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", participante_Forma.idUsuario);
            return View(participante_Forma);
        }

        // POST: Participante_Forma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idFicha,idUsuario,idTorneo,Area,Nombre_Forma,Tipo_Forma,Hora_Aprox,Duracion,Cal,Resultado")] Participante_Forma participante_Forma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participante_Forma).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idTorneo = new SelectList(db.Torneos, "idTorneo", "Nombre", participante_Forma.idTorneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", participante_Forma.idUsuario);
            return View(participante_Forma);
        }

        // GET: Participante_Forma/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participante_Forma participante_Forma = await db.Participante_Forma.FindAsync(id);
            if (participante_Forma == null)
            {
                return HttpNotFound();
            }
            return View(participante_Forma);
        }

        // POST: Participante_Forma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Participante_Forma participante_Forma = await db.Participante_Forma.FindAsync(id);
            db.Participante_Forma.Remove(participante_Forma);
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
