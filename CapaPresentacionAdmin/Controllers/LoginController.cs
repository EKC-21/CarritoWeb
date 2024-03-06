using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
            //Usuario usuario = new Usuario();
            //usuario.Correo = Correo;
            //usuario.Clave = Clave;
            //Usuario oUsuario = new Usuario();
            //oUsuario = new CN_Usuarios().oListUsuarios().Where(u => u.Correo == usuario.Correo && u.Clave == CN_Recursos.ConvertirSHA256(usuario.Clave)).FirstOrDefault();

            //if (oUsuario == null)
            //{
            //    ViewBag.Error = "Correo o contraseña incorrecto";
            //    return View();
            //}
            //else
            //{
            //    ViewBag.Error = null;
            //    return RedirectToAction("Usuarios", "Home");
            //}
        }
        [HttpPost]
        public JsonResult Login(Usuario usuario)
        {
            Usuario oUsuario = new Usuario();
            string msg = "";
            oUsuario = new CN_Usuarios().oListUsuarios().Where(u => u.Correo == usuario.Correo && u.Clave == CN_Recursos.ConvertirSHA256(usuario.Clave)).FirstOrDefault();

            if (oUsuario == null)
            {
                msg = "Correo o contraseña incorrecto";
                return Json(new { msg = msg }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                msg = "";
                //RedirectToAction("Usuarios", "Home");
            }
            return Json(new { msg = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}