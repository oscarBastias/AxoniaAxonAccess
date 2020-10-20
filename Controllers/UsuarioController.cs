using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AxonAccessMVC.Models;
using AxonAccessMVC.Models.Clases;
using Usuario= AxonAccessMVC.Models.Clases.Usuario;
using Ref_Estado = AxonAccessMVC.Models.Clases.Ref_Estado;
using Ref_Role = AxonAccessMVC.Models.Clases.Ref_Role;

namespace AxonAccessMVC.Controllers
{
    public class UsuarioController : Controller
    {
        public Usuario usuario;

        // GET: Usuario
        public ActionResult Index()
        {
            ViewBag.usuarios = new Usuario().ReadOne();

            return View();
        }

        public ActionResult Lista()
        {
            ViewBag.usuarios = new Usuario().ReadAll();

            return View();
        }

        public ActionResult CargaMasiva()
        {
            return View(new List<Usuario>());
        }

        [HttpPost]
        public ActionResult CargaMasiva(HttpPostedFileBase postedFile)
        {
            List<Usuario> customers = new List<Usuario>();
            if (postedFile != null)
            {
                string path = Server.MapPath("~/CargasMasivas/CargaMasiva.csv");

                string csvData = System.IO.File.ReadAllText(path);
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        customers.Add(new Usuario
                        {
                            Id_Role = Convert.ToInt32(row.Split(';')[0]),
                            Id_Estado = Convert.ToInt32(row.Split(';')[1]),
                            Id_Comuna = Convert.ToInt32(row.Split(';')[2]),
                            Id_Empresa = Convert.ToInt32(row.Split(';')[3]),
                            Rut = Convert.ToInt32(row.Split(';')[4]),
                            Dv = row.Split(';')[5],
                            Nombre = row.Split(';')[6],
                            App_Pater = row.Split(';')[7],
                            App_Mater = row.Split(';')[8],
                            Direccion = row.Split(';')[9],
                            Telefono = Convert.ToInt32(row.Split(';')[10]),
                            Mail = row.Split(';')[11],
                            Pass = row.Split(';')[12],
                            Latitud=row.Split(';')[13],
                            Longitud= row.Split(';')[14],

                        });
                    }
                }
                
            }
            
            return View(customers);
        }

        public ActionResult Create()
        {
            EnviarEstados();
            EnviarRoeles();
            EnviarComuna();
            EnviarEmpresa();
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id_Role,Id_Estado,Id_Comuna,Id_Empresa,Rut,Dv,Nombre,App_Pater,App_Mater,Direccion,Telefono,Mail,Pass,Latitud,Longitud")]Usuario usuario)
        {
            try
            {
                usuario.Save();
                TempData["mensaje"] = "Guardado correctamente";
                return RedirectToAction("Lista");
            }
            catch
            {
                return View("Create");
            }

        }

        private void EnviarEstados()
        {
            ViewBag.estados = new Ref_Estado().ReadAll();
        }

        private void EnviarRoeles()
        {
            ViewBag.roles = new Models.Clases.Ref_Role().ReadAll();
        }

        private void EnviarComuna()
        {
            ViewBag.comunas = new Models.Clases.Mae_Comuna().ReadAll();
        }

        private void EnviarEmpresa()
        {
            ViewBag.empresas = new Models.Clases.Mae_Empresa().ReadAll();
        }

        public ActionResult Delete(int id)
        {
            if(new Usuario().Find(id) == null)
            {
                TempData["mensaje"] = "No existe usuario";
                return RedirectToAction("Lista");
            }
            if(new Usuario().Delete(id))
            {
                TempData["mensaje"] = "eliminado Correctamente";
                return RedirectToAction("Lista");
            }
            TempData["mensaje"] = "No se ah podido eliminar el usuario";
            return RedirectToAction("Lista");
        }

        public ActionResult Edit(int id)
        {
            Usuario u = new Usuario().Find(id);
            if (u == null)
            {
                TempData["Mensaje"]="El usuario no existe";
                return RedirectToAction("Lista");
            }
            EnviarComuna();
            EnviarEmpresa();
            EnviarEstados();
            EnviarRoeles();
            return View(u);
        }
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                usuario.Update();
                TempData["mensaje"] = "Modificado correctamente";
                return RedirectToAction("Lista");
            }
            catch
            {
                return View("Lista");
            }
        }

    }
}