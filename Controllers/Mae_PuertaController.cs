using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ref_Estamento = AxonAccessMVC.Models.Clases.Ref_Estamento;
using Mae_Empresa = AxonAccessMVC.Models.Clases.Mae_Empresa;
using Ref_Sucursal = AxonAccessMVC.Models.Clases.Ref_Sucursal;
using AxonAccessMVC.Models.Clases;

namespace AxonAccessMVC.Controllers
{
    public class Mae_PuertaController : Controller
    {
        // GET: Mae_Puerta
        public ActionResult Index()
        {
            EnviarEstamento();

            return View();
        }
        public ActionResult Lista()
        {
            ViewBag.puertas = new Mae_Puerta().ReadAll();

            return View();
        }
        [HttpPost]
        public ActionResult Create(int id_valor)
        {
            ViewBag.empresas = new Mae_Empresa().ReadAll(id_valor);
            return View();
        }

        [HttpPost]
        public ActionResult Create2(int id_valor)
        {
            ViewBag.sucursals = new Ref_Sucursal().ReadAllFiltrado(id_valor);
            return View();
        }

        [HttpPost]
        public ActionResult Create3([Bind(Include = "Id_Sucursal,Desc_Puerta")] Mae_Puerta mae_puerta)
        {
            mae_puerta.Save();
            return RedirectToAction("Lista");
        }

        public ActionResult Delete(int id)
        {
            if (new Mae_Puerta().Find(id) == null)
            {
                TempData["mensaje"] = "No existe usuario";
                return RedirectToAction("Lista");
            }
            if (new Mae_Puerta().Delete(id))
            {
                TempData["mensaje"] = "eliminado Correctamente";
                return RedirectToAction("Lista");
            }
            TempData["mensaje"] = "No se ah podido eliminar el usuario";
            return RedirectToAction("Lista");
        }

        public ActionResult Edit(int id)
        {
            Mae_Puerta u = new Mae_Puerta().Find(id);
            if (u == null)
            {
                TempData["Mensaje"] = "El usuario no existe";
                return RedirectToAction("Lista");
            }

            ViewBag.sucursals = new Ref_Sucursal().ReadAll();
            return View(u);
        }
        [HttpPost]
        public ActionResult Edit(Mae_Puerta puerta)
        {
            try
            {
                puerta.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Lista");
            }
            catch
            {
                return View("Lista");
            }
        }

        private void EnviarEstamento()
        {
            ViewBag.estamentos = new Ref_Estamento().ReadAll();
        }
        private void EnviarSucursal()
        {
            ViewBag.sucursals = new Ref_Sucursal().ReadAll();
        }
    }
}