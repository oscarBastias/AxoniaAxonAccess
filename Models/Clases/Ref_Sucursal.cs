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
        public string direccion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string descripcion { get; set; }

        public string desc_empresa { get; set; }

        axonAccessEntities1 db = new axonAccessEntities1();

        public List<Ref_Sucursal> ReadAllSinFiltro()
        {



            return (from suc in db.Mae_Sucursal
                    join est in db.Ref_Estado on suc.id_estado equals est.id_estado
                    join com in db.Mae_Comuna on suc.id_comuna equals com.id_comuna
                    join emp in db.Mae_Empresa on suc.id_empresa equals emp.id_empresa
                    select new Models.Clases.Ref_Sucursal
                    {
                        id_sucursal=(int)suc.id_sucursal,
                        id_estado=(int)suc.id_estado,
                        id_comuna = (int)suc.id_comuna,
                        id_empresa = (int)suc.id_empresa,
                        desc_empresa=emp.desc_empresa,
                        direccion = suc.direccion,
                        latitud = suc.latitud,
                        longitud = suc.longitud,
                        descripcion = suc.descripcion

                    }).ToList();


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
    }
}