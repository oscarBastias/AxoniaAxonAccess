using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Usuario = AxonAccessMVC.Models.Clases.Usuario;
using Ref_Estado = AxonAccessMVC.Models.Clases.Ref_Estado;
using Ref_Role = AxonAccessMVC.Models.Clases.Ref_Role;
using Ref_Estamento = AxonAccessMVC.Models.Clases.Ref_Estamento;
using Mae_Empresa = AxonAccessMVC.Models.Clases.Mae_Empresa;
using AxonAccessMVC.Models;
using AxonAccessMVC.Models.Clases;
using AxonAccessMVC.Views.Ref_UserAccess;
using System.Web.UI.WebControls;

namespace AxonAccessMVC.Controllers
{
    public class Ref_UserAccessController : Controller
    {
        // GET: Ref_UserAccess
        public ActionResult Index()
        {
            ViewBag.empresas = new Mae_Empresa().ReadAllSinFiltro();
            return View();
        }
        [HttpPost]
        public ActionResult Lista(int id_valor)
        {
            ViewBag.useraccess = new Ref_UserAccesscs().ReadAllFiltrado(id_valor);

            return View();
        }
        public ActionResult Create(int id,int id_us)
        {
            ViewBag.useraccess = new Ref_UserAccesscs().ReadAllAcc(id, id_us);
            return View();
        }
        [HttpPost]
        public ActionResult Create()
        {
            List<string> lst = new List<string>();
            return View();
        }

        public ActionResult Test()
        {

            return View();
        }

        public ActionResult Vista()
        {

            return View(new Vista());
        }
    }
}