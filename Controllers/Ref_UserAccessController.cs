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
        public ActionResult Create(int id)
        {
            ViewBag.useraccess = new Ref_UserAccesscs().ReadAllAcc(id);
            return View();
        }
        [HttpPost]
        public ActionResult Create(int id_valor, int id_valor2)
        {
            ViewBag.empresas = new Models.Clases.Mae_Empresa().ReadAll(id_valor);
            ViewBag.comunas = new Models.Clases.Mae_Comuna().ReadAllFiltrado(id_valor2);
            ViewBag.pais = new Models.Clases.Mae_Pais().ReadAllFiltrado(id_valor2);

            return View();
        }
    }
}