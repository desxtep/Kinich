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
using Backend.Models;
using Backend.Helpers;

namespace Backend.Controllers
{
    public class TorneosController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Torneos
        public async Task<ActionResult> Index()
        {
            var torneos = db.Torneos.Include(t => t.Usuarios);
            return View(await torneos.ToListAsync());
        }

        // GET: Torneos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = await db.Torneos.FindAsync(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }

        // GET: Torneos/Create
        public ActionResult Create()
        {
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario");
            return View();
        }

        // POST: Torneos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TorneoView view)
        {
            var torneo = ToTorneo(view);
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Logos";
                if (view.LogoFile != null) {
                    pic = FilesHelper.UploadPhoto(view.LogoFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                torneo = ToTorneo(view);
                torneo.Logo = pic;
                db.Torneos.Add(torneo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", torneo.idUsuario);
            return View(view);
        }

        private Torneo ToTorneo(TorneoView view)
        {
            return new Torneo
            {
                idTorneo = view.idTorneo,
                Nombre = view.Nombre,
                Sede = view.Sede,
                Logo = view.Logo,
                Fecha = view.Fecha,
                HoraInicio = view.HoraInicio,
                idUsuario = view.idUsuario,
                NoAreas = view.NoAreas
            };
        }

        // GET: Torneos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var torneo = await db.Torneos.FindAsync(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            var view = TorneoView(torneo);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", torneo.idUsuario);
            return View(view);
        }

        private TorneoView TorneoView(Torneo torneo)
        {
            return new TorneoView
            {
                idTorneo = torneo.idTorneo,
                Nombre = torneo.Nombre,
                Sede = torneo.Sede,
                Logo = torneo.Logo,
                Fecha = torneo.Fecha,
                HoraInicio = torneo.HoraInicio,
                idUsuario = torneo.idUsuario,
                NoAreas = torneo.NoAreas
            };
        }

        // POST: Torneos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TorneoView view)
        {
            var torneo = ToTorneo(view);
            if (ModelState.IsValid)
            {
                var pic = view.Logo;
                var folder = "~/Content/Logos";
                if (view.LogoFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.LogoFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                torneo = ToTorneo(view);
                torneo.Logo = pic;

                db.Entry(torneo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuario = new SelectList(db.Usuarios, "idUsuario", "NombreUsuario", torneo.idUsuario);
            return View(view);
        }

        // GET: Torneos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = await db.Torneos.FindAsync(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }

        // POST: Torneos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Torneo torneo = await db.Torneos.FindAsync(id);
            db.Torneos.Remove(torneo);
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
