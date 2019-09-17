using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Dominio.Core.Entities;
using Dominio.Main.Module;

namespace MvcApplication5.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Validar() {
            if (Request.Cookies["Usuario"] != null) {
                Response.Cookies["Usuario"].Expires = DateTime.Now.AddDays(-1);
            }

            if (Request.Cookies["NombreUsuario"] != null) {
                Response.Cookies["NombreUsuario"].Expires = DateTime.Now.AddDays(-1);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Validar(string user, string password) {
            IEnumerable<Usuario> objeto = null;
            UsuarioManager manager = new UsuarioManager();

            objeto = manager.LoginUsuario(user, password);

            if (objeto.Count() == 0)
            {
                return View();
            }
            else {
                Response.Cookies["Usuario"].Value = objeto.ElementAt(0).usuario_u.ToString();
                Response.Cookies["NombreUsuario"].Value = objeto.ElementAt(0).nombreUsuario_u.ToString();

                Response.Cookies["Usuario"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["NombreUsuario"].Expires = DateTime.Now.AddDays(1);

                return RedirectToAction("Index", "CURSO");
            }
        }
    }
}
