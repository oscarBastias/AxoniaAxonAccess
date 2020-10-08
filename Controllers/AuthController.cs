using AxonAccessMVC.Models.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace AxonAccessMVC.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario, string ReturnUrl)
        {
            if (IsValid(usuario))
            {
                FormsAuthentication.SetAuthCookie(usuario.Mail, false);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("IndexRegistrado", "Home");
            }
            TempData["mensaje"] = "Credenciales Incorrectas";
            return View(usuario);
        }

        private bool IsValid(Usuario usuario)
        {

            return usuario.Autenticar();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            TempData.Remove("mensaje");
            return RedirectToAction("Index", "Home");
        }

    }
}