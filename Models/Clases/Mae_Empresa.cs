using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxonAccessMVC.Models.Clases
{
    public class Mae_Empresa
    {
        public int id_empresa { get; set; }
        public int id_comuna{ get; set; }
        public string desc_empresa { get; set; }


        axonAccessEntities1 db = new axonAccessEntities1();
        public List<Mae_Empresa> ReadAll()
        {
            return db.Mae_Empresa.Select(c => new Mae_Empresa()
            {
                id_empresa = c.id_empresa,
                id_comuna = (int)c.id_comuna,
                desc_empresa = c.desc_empresa
            }).ToList();
        }
    }
    
}
