using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxonAccessMVC.Models.Clases
{
    public class Mae_Empresa
    {
        public int id_empresa { get; set; }
        public int id_comuna { get; set; }
        public int id_estamento { get; set; }
        public string desc_estamento { get; set; }
        public string desc_empresa { get; set; }
        public string desc_comuna { get; set; }


        axonAccessEntities1 db = new axonAccessEntities1();
        public List<Mae_Empresa> ReadAll(int valor)
        {


            if (valor == 2 || valor==3)
            {
                return (from emp in db.Mae_Empresa
                       join est in db.Ref_Estamento on emp.id_estamento equals est.id_estamento
                        join com in db.Mae_Comuna on emp.id_comuna equals com.id_comuna
                        where emp.id_estamento == 2
                       select new Models.Clases.Mae_Empresa
                       {
                           id_empresa = (int)emp.id_empresa,
                           id_comuna=(int)emp.id_comuna,
                           desc_comuna=com.desc_comuna,
                           desc_empresa= emp.desc_empresa,
                           id_estamento=(int)emp.id_estamento,
                           desc_estamento=est.desc_estamento
                       }).ToList();
            }
            else
            {
                return (from emp in db.Mae_Empresa
                        join est in db.Ref_Estamento on emp.id_estamento equals est.id_estamento
                        join com in db.Mae_Comuna on emp.id_comuna equals com.id_comuna
                        where emp.id_estamento == (valor)
                        select new Models.Clases.Mae_Empresa
                        {
                            id_empresa = (int)emp.id_empresa,
                            id_comuna = (int)emp.id_comuna,
                            desc_comuna = com.desc_comuna,
                            desc_empresa = emp.desc_empresa,
                            id_estamento = (int)emp.id_estamento,
                            desc_estamento = est.desc_estamento
                        }).ToList();
            }

        }
        public List<Mae_Empresa> ReadAllSinFiltro()
        {



                return (from emp in db.Mae_Empresa
                        join est in db.Ref_Estamento on emp.id_estamento equals est.id_estamento
                        join com in db.Mae_Comuna on emp.id_comuna equals com.id_comuna
                        select new Models.Clases.Mae_Empresa
                        {
                            id_empresa = (int)emp.id_empresa,
                            id_comuna = (int)emp.id_comuna,
                            desc_comuna = com.desc_comuna,
                            desc_empresa = emp.desc_empresa,
                            id_estamento = (int)emp.id_estamento,
                            desc_estamento = est.desc_estamento
                        }).OrderByDescending(x => x.id_estamento).ToList();
            

        }
        public bool Save()
        {
            try
            {
                db.SP_INS_EMPRESA(this.id_comuna,this.id_estamento,this.desc_empresa);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public Mae_Empresa Find(int id)
        {
            return this.db.Mae_Empresa.Select(emp => new Mae_Empresa()
            {
                id_empresa = (int)emp.id_empresa,
                id_comuna = (int)emp.id_comuna,
                id_estamento=(int)emp.id_estamento,
                desc_empresa = emp.desc_empresa
            }).Where(us => us.id_empresa == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.sp_upd_estamento(this.id_empresa,this.id_comuna, this.id_estamento, this.desc_empresa);
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
                db.SVC_DELETED_ESTAMENTO(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
