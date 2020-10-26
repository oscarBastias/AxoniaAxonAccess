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
            ViewBag.sucursals = new Ref_Sucursal().ReadAllSinFiltro();
            return View();
        }

        // GET: Mae_Sucursal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mae_Sucursal/Create
        public ActionResult Create()
        {
            EnviarComuna();
            EnviarEstado();
            EnviarEmpresa();
            return View();
        }

        // POST: Mae_Sucursal/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id_Estado,Id_Comuna,Id_Empresa,Direccion,Latitud,Longitud,Descripcion")] Ref_Sucursal sucursal)
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
            ViewBag.empresas = new Models.Clases.Mae_Empresa().ReadAll(2);
        }
        // GET: Mae_Sucursal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mae_Sucursal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mae_Sucursal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mae_Sucursal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
