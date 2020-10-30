using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AxonAccessMVC.Models;
using AxonAccessMVC.Models.Clases;
using Mae_Empresa = AxonAccessMVC.Models.Clases.Mae_Empresa;
using Ref_Estamento = AxonAccessMVC.Models.Clases.Ref_Estamento;

namespace AxonAccessMVC.Controllers
{
    public class Mae_EntidadController : Controller
    {
        public Mae_Empresa entidad;
        // GET: Mae_Entidad
        public ActionResult Index()
        {
            EnviarEstamento();

            return View();
        }
        [HttpPost]

        public ActionResult Index(int id_valor)
        {
                EnviarEstamento();
                EnviarPais();

                ViewBag.entidades = new Mae_Empresa().ReadAll(id_valor);

                return View("IndexSelect1");

        }

        private void EnviarEstamento()
        {
            ViewBag.estamentos = new Ref_Estamento().ReadAll();
        }
        private void EnviarComuna()
        {
            ViewBag.comunas = new Models.Clases.Mae_Comuna().ReadAll();
        }
        private void EnviarPais()
        {
            ViewBag.pais = new Models.Clases.Mae_Pais().ReadAll();
        }

        public ActionResult Create()
        {
            EnviarPais();
            return View("SelectPaisEst");
        }

        [HttpPost]
        public ActionResult Create(int id_valor)
        {
            ViewBag.comunas = new Models.Clases.Mae_Comuna().ReadAllFiltrado(id_valor);
            EnviarEstamento();
            EnviarPais();
            return View();
        }

        // POST: Mae_Entidad/Create
        [HttpPost]
        public ActionResult Create2([Bind(Include = "Id_Comuna,Id_Estamento,Desc_Empresa")] Mae_Empresa empresa)
        {
            try
            {
                empresa.Save();
                TempData["mensaje"] = "Guardado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        public ActionResult Delete(int id)
        {
            if (new Mae_Empresa().Find(id) == null)
            {
                TempData["mensaje"] = "No existe usuario";
                return RedirectToAction("Index");
            }
            if (new Mae_Empresa().Delete(id))
            {
                TempData["mensaje"] = "eliminado Correctamente";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "No se ah podido eliminar el usuario";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Mae_Empresa u = new Mae_Empresa().Find(id);
            if (u == null)
            {
                TempData["Mensaje"] = "El usuario no existe";
                return RedirectToAction("Index");
            }
            EnviarComuna();
            EnviarEstamento();
            ViewBag.empresas = new Models.Clases.Mae_Empresa().ReadAllSinFiltro();

            return View(u);
        }
        [HttpPost]
        public ActionResult Edit(Mae_Empresa empresa)
        {
            try
            {
                empresa.Update();
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
