using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxonAccessMVC.Models.Clases
{
    public class Ref_UserAccesscs
    {
        public int id_acceso { get; set; }
        public int id_usuario { get; set; }
        public int id_puerta { get; set; }
        public string desc_access { get; set; }
        public DateTime fecha_acceso { get; set; }
        public int id_usuario2 { get; set; }
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string Nombre { get; set; }
        public string App_Pater { get; set; }
        public string App_Mater { get; set; }
        public int Id_Empresa { get; set; }

        public string Desc_Empresa { get; set; }

        public string Desc_Sucursal { get; set; }

        axonAccessEntities1 db = new axonAccessEntities1();

        public List<Ref_UserAccesscs> ReadAllFiltrado(int id)
        {
            return (from us in db.Mae_Usuario
                    join ro in db.Ref_Role on us.id_role equals ro.id_role
                    join suc in db.Mae_Sucursal on us.id_sucursal equals suc.id_sucursal
                    join acc in db.Ref_accessTipo on us.id_access_tipo equals acc.id_access_tipo
                    join emp in db.Mae_Empresa on us.id_empresa equals emp.id_empresa
                    where emp.id_empresa==id 
                    select new Models.Clases.Ref_UserAccesscs
                    {
                        Nombre=us.nombre,
                        App_Pater=us.app_pater,
                        App_Mater=us.app_mater,
                        Rut=(int)us.rut,
                        Dv=us.dv,
                        Desc_Empresa=emp.desc_empresa,
                        Desc_Sucursal=suc.descripcion,
                        Id_Empresa=emp.id_empresa
                        
                    }).ToList();
        }

        public List<Ref_UserAccesscs> ReadAllAcc(int id)
        {
            return (from puer in db.Mae_Puerta join sucu in db.Mae_Sucursal on puer.id_sucursal equals sucu.id_sucursal
                    where sucu.id_empresa == id
                    select new Models.Clases.Ref_UserAccesscs
                    {
                        Id_Empresa = (int)sucu.id_empresa,
                        Desc_Sucursal =sucu.descripcion,
                        desc_access=puer.desc_puerta
                    }).ToList();
        }
    }
}