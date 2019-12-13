using Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Backend.Controllers
{
    public class Vistas2Controller : Controller
    {
        private ProyectoEntities1 db2 = new ProyectoEntities1();
        // GET: Vistas2
        public async Task<ActionResult> Index()
        {
            // return View(await db.Categoria_Edad.ToListAsync());
            return View(await db2.reporte_formas.ToListAsync());
        }
    }
}