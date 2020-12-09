using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxonAccessMVC.Models.Clases
{
    public class Ref_Sucursal
    {
        public int id_sucursal { get; set; }
        public int id_estado { get; set; }
        public int id_comuna { get; set; }
        public int id_empresa { get; set; }
        public int id_pais { get; set; }
        public string direccion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string descripcion { get; set; }
        public string desc_estamento { get; set; }
        public string desc_empresa { get; set; }
        public string desc_pais { get; set; }

        axonAccessEntities2 db = new axonAccessEntities2();

        public List<Ref_Sucursal> ReadAll()
        {
            return (from suc in db.Mae_Sucursal
                    join est in db.Ref_Estado on suc.id_estado equals est.id_estado
                    join com in db.Mae_Comuna on suc.id_comuna equals com.id_comuna
                    join reg in db.Mae_Region on com.id_region equals reg.id_region 
                    join pa  in db.Mae_Pais   on reg.id_pais   equals pa.id_pais
                    join emp in db.Mae_Empresa on suc.id_empresa equals emp.id_empresa
                    join sta in db.Ref_Estamento on emp.id_estamento equals sta.id_estamento
                    select new Models.Clases.Ref_Sucursal
                    {
                        id_sucursal = (int)suc.id_sucursal,
                        id_estado = (int)suc.id_estado,
                        id_comuna = (int)suc.id_comuna,
                        id_empresa = (int)suc.id_empresa,
                        id_pais = (int)pa.id_pais,
                        desc_pais  = pa.desc_pais,
                        desc_empresa = emp.desc_empresa,
                        direccion = suc.direccion,
                        latitud = suc.latitud,
                        longitud = suc.longitud,
                        desc_estamento = sta.desc_estamento,
                        descripcion = suc.descripcion

                    }).OrderByDescending(x => x.id_empresa).ToList();
        }

        public List<Ref_Sucursal> ReadAllFiltrado(int id)
        {
            return (from suc in db.Mae_Sucursal
                    join est in db.Ref_Estado on suc.id_estado equals est.id_estado
                    join com in db.Mae_Comuna on suc.id_comuna equals com.id_comuna
                    join reg in db.Mae_Region on com.id_region equals reg.id_region
                    join pa in db.Mae_Pais on reg.id_pais equals pa.id_pais
                    join emp in db.Mae_Empresa on suc.id_empresa equals emp.id_empresa
                    join sta in db.Ref_Estamento on emp.id_estamento equals sta.id_estamento
                    select new Models.Clases.Ref_Sucursal
                    {
                        id_sucursal = (int)suc.id_sucursal,
                        id_estado = (int)suc.id_estado,
                        id_comuna = (int)suc.id_comuna,
                        id_empresa = (int)suc.id_empresa,
                        id_pais = (int)pa.id_pais,
                        desc_pais = pa.desc_pais,
                        desc_empresa = emp.desc_empresa,
                        direccion = suc.direccion,
                        latitud = suc.latitud,
                        longitud = suc.longitud,
                        desc_estamento = sta.desc_estamento,
                        descripcion = suc.descripcion

                    }).Where(p => p.id_empresa == id).OrderByDescending(x => x.id_sucursal).ToList();
        }

        public bool Save()
        {
            try
            {
                db.SP_INS_SUCURSAL(this.id_estado, this.id_comuna, this.id_empresa, this.direccion, this.latitud, this.longitud, this.descripcion);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public Ref_Sucursal Find(int id)
        {
            return this.db.Mae_Sucursal.Select(suc => new Ref_Sucursal()
            {
                id_sucursal = (int)suc.id_sucursal,
                id_estado =(int)suc.id_estado ,
                id_comuna = (int)suc.id_comuna,
                id_empresa =(int)suc.id_empresa,
                direccion =suc.direccion,
                latitud =suc.latitud,
                longitud =suc.longitud,
                descripcion = suc.descripcion
            }).Where(us => us.id_sucursal == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.sp_upd_sucursal(this.id_sucursal, this.id_estado, this.id_comuna, this.id_empresa, this.direccion, this.latitud, this.longitud,this.descripcion);
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
                db.SVC_DELETED_SUCURSAL(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}