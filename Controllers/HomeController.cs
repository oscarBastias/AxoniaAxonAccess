using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Usuario = AxonAccessMVC.Models.Clases.Usuario;
namespace AxonAccessMVC.Controllers
{

    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "AxonAccess.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "AxonAccess.";

            return View();
        }


        public ActionResult IndexRegistrado()
        {
            ViewBag.usuarios = new Usuario().ReadOne();
            ViewBag.Message = "AxonAccess.";
            return View();
        }
    }
}