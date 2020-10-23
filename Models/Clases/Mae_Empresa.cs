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


            if (valor == 2)
            {
                return (from emp in db.Mae_Empresa
                       join est in db.Ref_Estamento on emp.id_estamento equals est.id_estamento
                        join com in db.Mae_Comuna on emp.id_comuna equals com.id_comuna
                        where emp.id_estamento == (valor)
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
    }
}
