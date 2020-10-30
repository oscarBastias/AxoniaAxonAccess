using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mae_Empresa = AxonAccessMVC.Models.Clases.Mae_Empresa;
using Ref_Estamento = AxonAccessMVC.Models.Clases.Ref_Estamento;
using Ref_Sucursal = AxonAccessMVC.Models.Clases.Ref_Sucursal;

namespace AxonAccessMVC.Controllers
{
    public class Mae_SucursalController : Controller
    {
        // GET: Mae_Sucursal
        public ActionResult Index()
        {
            EnviarComuna();
            EnviarEstado();
            EnviarEmpresa();
            ViewBag.sucursals = new Ref_Sucursal().ReadAll();
            return View();
        }

        // GET: Mae_Sucursal/Details/5
        public ActionResult Create()
        {
            EnviarPais();
            return View("SelectPais");
        }
        [HttpPost]
        public ActionResult Create(int id_valor)
        {
            ViewBag.comunas = new Models.Clases.Mae_Comuna().ReadAllFiltrado(id_valor);
            EnviarPais();
            EnviarEstado();
            EnviarEmpresa();
            return View();
        }

        // POST: Mae_Sucursal/Create
        [HttpPost]
        public ActionResult Create2([Bind(Include = "Id_Estado,Id_Comuna,Id_Empresa,Direccion,Latitud,Longitud,Descripcion")] Ref_Sucursal sucursal)
        {
            try
            {
                sucursal.Save();
                TempData["mensaje"] = "Guardado correctamente";
                return RedirectToAction("Create");
            }
            catch
            {
                return View("Create");
            }
        }
        private void EnviarPais()
        {
            ViewBag.pais = new Models.Clases.Mae_Pais().ReadAll();
        }
        private void EnviarComuna()
        {
            ViewBag.comunas = new Models.Clases.Mae_Comuna().ReadAll();
        }
        private void EnviarEstado()
        {
            ViewBag.estados = new Models.Clases.Ref_Estado().ReadAll();
        }
        private void EnviarEmpresa()
        {
            ViewBag.empresas = new Models.Clases.Mae_Empresa().ReadAllSinFiltro();
        }

        public ActionResult Delete(int id)
        {
            if (new Ref_Sucursal().Find(id) == null)
            {
                TempData["mensaje"] = "No existe usuario";
                return RedirectToAction("Index");
            }
            if (new Ref_Sucursal().Delete(id))
            {
                TempData["mensaje"] = "eliminado Correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "No se ah podido eliminar el usuario";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Ref_Sucursal u = new Ref_Sucursal().Find(id);
            if (u == null)
            {
                TempData["Mensaje"] = "El usuario no existe";
                return RedirectToAction("Index");
            }
            EnviarComuna();
            EnviarEstado();
            ViewBag.empresas = new Models.Clases.Mae_Empresa().ReadAllSinFiltro();

            return View(u);
        }
        [HttpPost]
        public ActionResult Edit(Ref_Sucursal sucursal)
        {
            try
            {
                sucursal.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

    }
}
