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
        axonAccessEntities2 db = new axonAccessEntities2();
        public ActionResult Index()
        {
            ViewBag.empresas = new Mae_Empresa().ReadAllSinFiltro();
            return View();
        }
        public ActionResult AccesList()
        {
            ViewBag.asignados = new Ref_UserAccesscs().ReadAllAcces();
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
            ViewBag.id_empresa = id;
            ViewBag.id_usuario = id_us;
            return View();
        }
        [HttpPost]
        public ActionResult Create(int[]puerta, int id_empresa, int id_usuario)
        {
            foreach(int id_puerta in puerta)
            {
                db.SP_INS_REFUSERACCESS(id_usuario, id_puerta, "ASIGNADO", DateTime.Now);
            }
            return RedirectToAction("AccesList");
        }

        public ActionResult listaXuser()
        {
            ViewBag.usu = new Ref_UserAccesscs().ReadUser();
            return View();
        }
        [HttpPost]
        public ActionResult listaXuser(string nom)
        {
            ViewBag.usu = new Ref_UserAccesscs().Find(nom);
            return View();
        }
        public ActionResult listaXuser2(int id)
        {
            ViewBag.usu = new Ref_UserAccesscs().ReadUser2(id);
            return View();
        }

        public ActionResult listaXemp()
        {
            ViewBag.emp = new Ref_UserAccesscs().ReadEmp();
            return View();
        }
        [HttpPost]
        public ActionResult listaXemp(string nom)
        {
            ViewBag.emp = new Ref_UserAccesscs().FindEmp(nom);
            return View();
        }
        public ActionResult listaXemp2(int id)
        {
            ViewBag.emp = new Ref_UserAccesscs().ReadEmp2(id);
            return View();
        }
    }
}