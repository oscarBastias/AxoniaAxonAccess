using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxonAccessMVC.Models.Clases
{
    public class Mae_Puerta
    {
        public int id_puerta { get; set; }
        public int id_sucursal { get; set; }
        public string desc_puerta { get; set; }
        public string desc_sucursal { get; set; }
        public string desc_empresa { get; set; }


        axonAccessEntities2 db = new axonAccessEntities2();
        public List<Mae_Puerta> ReadAll()
        {
            return (from puer in db.Mae_Puerta
                    join suc in db.Mae_Sucursal on puer.id_sucursal equals suc.id_sucursal
                    join emp in db.Mae_Empresa on suc.id_empresa equals emp.id_empresa
                    select new Models.Clases.Mae_Puerta
                    {
                        id_puerta = puer.id_puerta,
                        id_sucursal = (int)puer.id_sucursal,
                        desc_puerta = puer.desc_puerta,
                        desc_sucursal = suc.descripcion,
                        desc_empresa=emp.desc_empresa
                    }).ToList();
        }
        public List<Mae_Puerta> ReadAllFiltrado(int id)
        {
            return db.Mae_Puerta.Select(c => new Mae_Puerta()
            {
                id_puerta = c.id_puerta,
                id_sucursal = (int)c.id_sucursal,
                desc_puerta = c.desc_puerta
            }).Where(p => p.id_sucursal == id).OrderBy(x => x.id_puerta).ToList();
        }

        public bool Save()
        {

                try
                {
                    db.SP_INS_PUERTA(this.id_sucursal,this.desc_puerta);
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
        }

        public Mae_Puerta Find(int id)
        {
            return this.db.Mae_Puerta.Select(pu => new Mae_Puerta()
            {
                id_puerta = (int)pu.id_puerta,
                id_sucursal = (int)pu.id_sucursal,
                desc_puerta = pu.desc_puerta,
            }).Where(pu => pu.id_puerta==id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.sp_upd_puerta(this.id_puerta,this.id_sucursal,this.desc_puerta);
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
                db.SVC_DELETED_PUERTA(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}