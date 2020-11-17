using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.IO;

namespace AxonAccessMVC.Models.Clases
{
    public class Usuario
    {
        public int Id { get; set; }
        public int Id_Role { get; set; }
        public int Id_Estado { get; set; }
        public int Id_Comuna { get; set; }
        public int Id_Empresa { get; set; }
        public int Id_Sucursal { get; set; }
        public int id_access_tipo { get; set; }
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string Nombre { get; set; }
        public string App_Pater { get; set; }
        public string App_Mater { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Mail { get; set; }
        public string Pass { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Cargo { get; set; }
        public string Desc_Role { get; set; }
        public string Cod_Pais { get; set; }
        public string Desc_Sucursal { get; set; }
        public string Desc_Access { get; set; }
        public string Desc_Empresa { get; set; }
        public string Desc_Comuna { get; set; }
        public string Desc_Region { get; set; }
        public string Desc_Pais { get; set; }



        axonAccessEntities1 db = new axonAccessEntities1();
        AxonAccessMVC.Controllers.AuthController au = new Controllers.AuthController();

        public List<Usuario> ReadAll()
        {
            string userMail = HttpContext.Current.User.Identity.Name;
            AxonAccessMVC.Models.Mae_Usuario resss = db.Mae_Usuario.FirstOrDefault
                    (u => u.mail == userMail);
             if (resss.id_role == 4)
            {
                return (from us in db.Mae_Usuario
                        join ro in db.Ref_Role on us.id_role equals ro.id_role
                        join suc in db.Mae_Sucursal on us.id_sucursal  equals suc.id_sucursal
                        join acc in db.Ref_accessTipo on us.id_access_tipo equals acc.id_access_tipo
                        join emp in db.Mae_Empresa on us.id_empresa equals emp.id_empresa
                        where us.id_role==4 || us.id_role==5 
                        select new Models.Clases.Usuario
                        {
                            Id = (int)us.id_usuario,
                            Id_Role = (int)us.id_role,
                            Desc_Role = ro.desc_role,
                            Id_Estado = (int)us.id_estado,
                            Id_Comuna = (int)us.id_comuna,
                            Id_Empresa = (int)us.id_empresa,
                            Rut = (int)us.rut,
                            Dv = us.dv,
                            Nombre = us.nombre,
                            App_Pater = us.app_pater,
                            App_Mater = us.app_mater,
                            Direccion = us.direccion,
                            Telefono = (int)us.telefono,
                            Mail = us.mail,
                            Pass = us.pass,
                            Latitud=us.latitud,
                            Longitud=us.longitud,
                            Cargo=us.cargo,
                            Cod_Pais=us.cod_pais,
                            Id_Sucursal=(int)us.id_sucursal,
                            Desc_Sucursal=suc.descripcion,
                            Desc_Access=acc.desc_Access_tipo,
                            Desc_Empresa=emp.desc_empresa
                            
                        }).OrderBy(x => x.Id_Role).ToList();
            }
            else if ( resss.id_role == 5)
            {
                return (from us in db.Mae_Usuario
                        join ro in db.Ref_Role on us.id_role equals ro.id_role
                        join suc in db.Mae_Sucursal on us.id_sucursal equals suc.id_sucursal
                        join acc in db.Ref_accessTipo on us.id_access_tipo equals acc.id_access_tipo
                        where  us.id_role == 5 && us.mail== userMail
                        select new Models.Clases.Usuario
                        {
                            Id = (int)us.id_usuario,
                            Id_Role = (int)us.id_role,
                            Desc_Role = ro.desc_role,
                            Id_Estado = (int)us.id_estado,
                            Id_Comuna = (int)us.id_comuna,
                            Id_Empresa = (int)us.id_empresa,
                            Rut = (int)us.rut,
                            Dv = us.dv,
                            Nombre = us.nombre,
                            App_Pater = us.app_pater,
                            App_Mater = us.app_mater,
                            Direccion = us.direccion,
                            Telefono = (int)us.telefono,
                            Mail = us.mail,
                            Pass = us.pass,
                            Latitud = us.latitud,
                            Longitud = us.longitud,
                            Cargo = us.cargo,
                            Cod_Pais = us.cod_pais,
                            Id_Sucursal = (int)us.id_sucursal,
                            Desc_Sucursal = suc.descripcion,
                            Desc_Access = acc.desc_Access_tipo

                        }).OrderBy(x => x.Id_Role).ToList();
            }
           else {
                return (from us in db.Mae_Usuario
                        join ro in db.Ref_Role
                        on us.id_role equals ro.id_role  join suc in db.Mae_Sucursal on us.id_sucursal equals suc.id_sucursal
                        join acc in db.Ref_accessTipo on us.id_access_tipo equals acc.id_access_tipo
                        select new Models.Clases.Usuario
                        {
                            Id = (int)us.id_usuario,
                            Id_Role = (int)us.id_role,
                            Desc_Role = ro.desc_role,
                            Id_Estado = (int)us.id_estado,
                            Id_Comuna = (int)us.id_comuna,
                            Id_Empresa = (int)us.id_empresa,
                            Rut = (int)us.rut,
                            Dv = us.dv,
                            Nombre = us.nombre,
                            App_Pater = us.app_pater,
                            App_Mater = us.app_mater,
                            Direccion = us.direccion,
                            Telefono = (int)us.telefono,
                            Mail = us.mail,
                            Pass = us.pass,
                            Latitud = us.latitud,
                            Longitud = us.longitud,
                            Cargo=us.cargo,
                            Cod_Pais = us.cod_pais,
                            Id_Sucursal = (int)us.id_sucursal,
                            Desc_Sucursal=suc.descripcion,
                            Desc_Access=acc.desc_Access_tipo
                        }).OrderBy(x => x.Id_Role).ToList();
            }
           
        }

        public List<Usuario> ReadOne()
        {
            
            string userMail = HttpContext.Current.User.Identity.Name;
            return (from us in db.Mae_Usuario 
                    join ro in db.Ref_Role on us.id_role equals ro.id_role
                    join emp in db.Mae_Empresa on us.id_empresa equals emp.id_empresa
                    join com in db.Mae_Comuna on us.id_comuna equals com.id_comuna
                    join reg in db.Mae_Region on com.id_region equals reg.id_region
                    join pa in db.Mae_Pais on reg.id_pais equals pa.id_pais
                    where us.mail == userMail
                    select new Models.Clases.Usuario
                    {
                        Id = (int)us.id_usuario,
                        Desc_Role = ro.desc_role,
                        Id_Estado = (int)us.id_estado,
                        Id_Comuna = (int)us.id_comuna,
                        Id_Empresa = (int)us.id_empresa,
                        Rut = (int)us.rut,
                        Dv = us.dv,
                        Nombre = us.nombre,
                        App_Pater = us.app_pater,
                        App_Mater = us.app_mater,
                        Direccion = us.direccion,
                        Telefono = (int)us.telefono,
                        Mail = us.mail,
                        Pass = us.pass,
                        Desc_Empresa=emp.desc_empresa,
                        Desc_Comuna=com.desc_comuna,
                        Desc_Pais=pa.desc_pais,
                        Desc_Region=reg.desc_region,
                        Cargo=us.cargo
                    }).ToList();
        }

           public bool Save()
        {
            
            try
            {
                db.SP_INS_USUARIO_MASS(this.Id_Role, this.Id_Estado, this.Id_Comuna, this.Id_Empresa, this.Rut, this.Dv, this.Nombre, this.App_Pater,
                                        this.App_Mater, this.Direccion, this.Telefono, this.Mail, this.Pass,this.Latitud,this.Longitud,this.Cod_Pais,this.Id_Sucursal, this.id_access_tipo);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public class SimpleFileMove
        {
            public static void Main()
            {
                string sourceFile = @"C:\Users\Axonia02\Desktop\Proyecto AxonAcces\web\AxonAccess\AxonAccessMVC\CargasMasivas\CargaMasiva.csv";
                string destinationFile = @"C:\Users\Axonia02\Desktop\Proyecto AxonAcces\web\AxonAccess\AxonAccessMVC\CargasMasivas\Cargadas\CargaMasiva_Movida.csv";

                // To move a file or folder to a new location:
                System.IO.File.Move(sourceFile, destinationFile);
            }
        }

        public bool Autenticar()
        {

            return db.Mae_Usuario
                .Where(u => u.mail == this.Mail
                && u.pass == this.Pass)
                .FirstOrDefault() != null;
        }

        public Usuario Find(int id)
        {
            return this.db.Mae_Usuario.Select(us => new Usuario()
            {
                Id = (int)us.id_usuario,
                Id_Role = (int)us.id_role,
                Id_Estado = (int)us.id_estado,
                Id_Comuna = (int)us.id_comuna,
                Id_Empresa = (int)us.id_empresa,
                Rut = (int)us.rut,
                Dv = us.dv,
                Nombre = us.nombre,
                App_Pater = us.app_pater,
                App_Mater = us.app_mater,
                Direccion = us.direccion,
                Telefono = (int)us.telefono,
                Mail = us.mail,
                Pass = us.pass,
                Latitud=us.latitud,
                Longitud=us.longitud,
                Cod_Pais=us.cod_pais
            }).Where(us => us.Id == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.sp_upd_user(this.Id,this.Id_Role,this.Id_Estado,this.Id_Comuna,this.Id_Empresa,this.Rut,this.Dv,
                                this.Nombre,this.App_Pater,this.App_Mater,this.Direccion,this.Telefono,this.Mail,this.Pass,this.Latitud,this.Longitud,this.Cod_Pais, this.id_access_tipo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                db.SVC_DELETED_USUARIO(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Asign(int id_valor,int ArticleId)
        {
            try
            {
                db.sp_upd_insersion_user(id_valor, ArticleId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
    