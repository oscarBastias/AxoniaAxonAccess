using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public string Desc_Puerta { get; set; }


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
                        Id_Empresa=emp.id_empresa,
                        id_usuario=us.id_usuario
                        
                    }).ToList();
        }

        public List<Ref_UserAccesscs> ReadAllAcc(int id, int id_us)
        {
            var subc = (from pu in db.Mae_Puerta
                        join refa in db.Ref_UserAccess on pu.id_puerta equals refa.id_puerta
                        join maesu in db.Mae_Sucursal on pu.id_sucursal equals maesu.id_sucursal
                        where refa.id_usuario==id_us
                        select refa.id_puerta);

            return (from puer in db.Mae_Puerta join sucu in db.Mae_Sucursal on puer.id_sucursal equals sucu.id_sucursal
                    where sucu.id_empresa == id && !subc.Contains(puer.id_puerta) 
                    select new Models.Clases.Ref_UserAccesscs
                    {
                        Id_Empresa = (int)sucu.id_empresa,
                        id_puerta=(int)puer.id_puerta,
                        Desc_Sucursal =sucu.descripcion,
                        desc_access=puer.desc_puerta,
                        id_usuario = id_us
                    }).ToList();


        }
        public List<Ref_UserAccesscs> ReadAllAcces()
        {
            return (from a in db.Ref_UserAccess 
                    join b in db.Mae_Usuario on a.id_usuario equals b.id_usuario
                    join c in db.Mae_Puerta on a.id_puerta equals c.id_puerta
                    join d in db.Mae_Sucursal on c.id_sucursal equals d.id_sucursal
                    join e in db.Mae_Empresa on d.id_empresa equals e.id_empresa
                    select new Models.Clases.Ref_UserAccesscs
                    {
                        id_acceso=a.id_acceso,
                        id_usuario=(int)a.id_usuario,
                        Nombre=b.nombre,
                        App_Pater=b.app_pater,
                        App_Mater=b.app_mater,
                        Desc_Empresa=e.desc_empresa,
                        Desc_Sucursal=d.descripcion,
                        Desc_Puerta=c.desc_puerta,
                        id_puerta =(int)a.id_puerta,
                        desc_access=a.desc_access,
                        fecha_acceso=(DateTime)a.fecha_acceso

                    }).OrderByDescending(x=>x.Desc_Empresa).ToList();
        }
        
        public List<Ref_UserAccesscs> ReadUser2(int id)
        {
            return (from a in db.Ref_UserAccess
                    join b in db.Mae_Usuario on a.id_usuario equals b.id_usuario
                    join c in db.Mae_Puerta on a.id_puerta equals c.id_puerta
                    join d in db.Mae_Sucursal on c.id_sucursal equals d.id_sucursal
                    join e in db.Mae_Empresa on d.id_empresa equals e.id_empresa
                    where a.id_usuario == id
                    select new Models.Clases.Ref_UserAccesscs
                    {
                        id_acceso = a.id_acceso,
                        id_usuario = (int)a.id_usuario,
                        Nombre = b.nombre,
                        App_Pater = b.app_pater,
                        App_Mater = b.app_mater,
                        Desc_Empresa = e.desc_empresa,
                        Desc_Sucursal = d.descripcion,
                        Desc_Puerta = c.desc_puerta,
                        id_puerta = (int)a.id_puerta,
                        desc_access = a.desc_access,
                        fecha_acceso = (DateTime)a.fecha_acceso
                    }).OrderByDescending(x => x.fecha_acceso).ToList();
        }
        public List<Ref_UserAccesscs> ReadUser()
        {
            return (from a in db.Mae_Usuario
                    select new Models.Clases.Ref_UserAccesscs
                    {
                        id_usuario = (int)a.id_usuario,
                        Nombre = a.nombre,
                        App_Pater = a.app_pater,
                        App_Mater = a.app_mater,
                        Rut = (int)a.rut
                    }).OrderByDescending(x => x.Nombre).ToList();
        }
        public List<Ref_UserAccesscs> Find(string nom)
        {
            return (from a in db.Mae_Usuario
                    where a.nombre == nom
                    select new Models.Clases.Ref_UserAccesscs
                    {
                        id_usuario = (int)a.id_usuario,
                        Nombre = a.nombre,
                        App_Pater = a.app_pater,
                        App_Mater = a.app_mater,
                        Rut = (int)a.rut
                    }).OrderByDescending(x => x.Nombre).ToList();
        }

        public List<Ref_UserAccesscs> ReadEmp()
        {
            return (from a in db.Mae_Empresa
                    select new Models.Clases.Ref_UserAccesscs
                    {
                        Id_Empresa = (int)a.id_empresa,
                        Desc_Empresa = a.desc_empresa
                    }).OrderByDescending(x => x.Desc_Empresa).ToList();
        }

        public List<Ref_UserAccesscs> ReadEmp2(int id)
        {
            return (from a in db.Ref_UserAccess
                    join b in db.Mae_Usuario on a.id_usuario equals b.id_usuario
                    join c in db.Mae_Puerta on a.id_puerta equals c.id_puerta
                    join d in db.Mae_Sucursal on c.id_sucursal equals d.id_sucursal
                    join e in db.Mae_Empresa on d.id_empresa equals e.id_empresa
                    where e.id_empresa == id
                    select new Models.Clases.Ref_UserAccesscs
                    {
                        id_usuario = (int)a.id_usuario,
                        Nombre = b.nombre,
                        App_Pater = b.app_pater,
                        App_Mater = b.app_mater,
                        Desc_Empresa = e.desc_empresa,
                        Desc_Sucursal = d.descripcion,
                        Desc_Puerta = c.desc_puerta,
                        id_puerta = (int)a.id_puerta,
                        desc_access = a.desc_access,
                        fecha_acceso=(DateTime)a.fecha_acceso
                    }).OrderByDescending(x => x.Nombre).ToList();
        }

        public List<Ref_UserAccesscs> FindEmp(string nom)
        {
            return (from a in db.Mae_Empresa
                    where a.desc_empresa == nom
                    select new Models.Clases.Ref_UserAccesscs
                    {
                        Id_Empresa=(int)a.id_empresa,
                        Desc_Empresa=a.desc_empresa
                    }).OrderByDescending(x => x.Desc_Empresa).ToList();
        }

    }
}