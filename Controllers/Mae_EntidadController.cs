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

                ViewBag.entidades = new Mae_Empresa().ReadAll(id_valor);

                return View("IndexSelect1");

        }

        private void EnviarEstamento()
        {
            ViewBag.estamento = new Ref_Estamento().ReadAll();
        }

        // GET: Mae_Entidad/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mae_Entidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mae_Entidad/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mae_Entidad/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mae_Entidad/Edit/5
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

        // GET: Mae_Entidad/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mae_Entidad/Delete/5
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
