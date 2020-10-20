using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AxonAccessMVC.Models;
using AxonAccessMVC.Models.Clases;

namespace AxonAccessMVC.Controllers
{
    [Authorize]
    public class Ref_RoleController : Controller
    {
        // GET: Ref_Role

        
        public ActionResult Index()
        {
            List<Models.Clases.Ref_Role> lst;
            using (axonAccessEntities1 db=new axonAccessEntities1())
            {
                lst = (from d in db.Ref_Role
                       select new Models.Clases.Ref_Role
                       {
                           id_role = d.id_role,
                           desc_role = d.desc_role
                       }).ToList();
            }
            return View(lst);


        }
    }
}