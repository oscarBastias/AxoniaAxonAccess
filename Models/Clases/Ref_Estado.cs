using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace AxonAccessMVC.Models.Clases
{
    public class Ref_Estado
    {
        public int id_estado { get; set; }
        public string desc_estado { get; set; }

        axonAccessEntities2 db = new axonAccessEntities2();

        public List<Ref_Estado> ReadAll()
        {
            return db.Ref_Estado.Select(c => new Ref_Estado()
            {
                id_estado = c.id_estado,
                desc_estado = c.desc_estado
            }).ToList();
        }
    }
    

}