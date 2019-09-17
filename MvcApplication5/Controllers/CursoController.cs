using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Dominio.Core.Entities;
using Dominio.Main.Module;

namespace MvcApplication5.Controllers
{
    public class CursoController : Controller
    {
        //
        // GET: /Curso/

        public ActionResult Index()
        {
            IEnumerable<Curso> objeto = null;

            CursoManager manager = new CursoManager();
            objeto = manager.ListarCursos();
           
            return View(objeto);
        }

        public ActionResult CrearCurso() {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCursos(Curso objeto) {

            CursoManager manager = new CursoManager();
            if (ModelState.IsValid)
            {
                manager.RegistrarCurso(objeto);
                return RedirectToAction("Index");
            }
            else {
                return View(objeto);
            }
        }

        public ActionResult CerrarSession() {
            return RedirectToAction("Validar", "Usuario");
        }


    }
}
