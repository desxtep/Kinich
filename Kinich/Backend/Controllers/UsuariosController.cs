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

namespace Backend.Controllers
{
    public class UsuariosController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Usuarios
        public async Task<ActionResult> Index()
        {
            var usuarios = db.Usuarios.Include(u => u.Categoria_Edads).Include(u => u.Categoria_Pesos);
            return View(await usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria_Edad = new SelectList(db.Categoria_Edad, "idCategoria_Edad", "NCatE");
            ViewBag.idCategoria_Peso = new SelectList(db.Categoria_Peso, "idCategoria_Peso", "NCatP");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idUsuario,NombreUsuario,Correo,Contraseña,Nombre,apepat,apemat,fnac,Peso,Grado,Genero,idCategoria_Edad,idCategoria_Peso,TipoUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Contraseña = Usuario.GetSHA256(usuario.Contraseña);
                db.Usuarios.Add(usuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria_Edad = new SelectList(db.Categoria_Edad, "idCategoria_Edad", "NCatE", usuario.idCategoria_Edad);
            ViewBag.idCategoria_Peso = new SelectList(db.Categoria_Peso, "idCategoria_Peso", "NCatP", usuario.idCategoria_Peso);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria_Edad = new SelectList(db.Categoria_Edad, "idCategoria_Edad", "NCatE", usuario.idCategoria_Edad);
            ViewBag.idCategoria_Peso = new SelectList(db.Categoria_Peso, "idCategoria_Peso", "NCatP", usuario.idCategoria_Peso);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idUsuario,NombreUsuario,Correo,Contraseña,Nombre,apepat,apemat,fnac,Peso,Grado,Genero,idCategoria_Edad,idCategoria_Peso,TipoUsuario")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria_Edad = new SelectList(db.Categoria_Edad, "idCategoria_Edad", "NCatE", usuario.idCategoria_Edad);
            ViewBag.idCategoria_Peso = new SelectList(db.Categoria_Peso, "idCategoria_Peso", "NCatP", usuario.idCategoria_Peso);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            db.Usuarios.Remove(usuario);
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
