using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> oListUsuarios = new List<Usuario>();

            oListUsuarios = new CN_Usuarios().oListUsuarios();

            //return Json(oListUsuarios, JsonRequestBehavior.AllowGet);
            return Json(new {data = oListUsuarios } ,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUsuarios(Usuario usuario)
        {
            object resultado;
            string msg = string.Empty;

            if(usuario.IdUsuario == 0)
            {
                msg = new CN_Usuarios().RegistrarUsuario(usuario);
            }
            else
            {
                msg = new CN_Usuarios().EditarUsuario(usuario);
            }
            return Json(new { msg = msg }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarUsuarios(Usuario usuario)
        {
            object resultado;
            string msg = string.Empty;

            if (usuario.IdUsuario == 0)
            {
                msg = new CN_Usuarios().EliminarUsuario(usuario.IdUsuario);
            }
            else
            {
                msg = new CN_Usuarios().EliminarUsuario(usuario.IdUsuario);
            }
            return Json(new { msg = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}