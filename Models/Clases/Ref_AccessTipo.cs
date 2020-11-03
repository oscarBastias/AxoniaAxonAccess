using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxonAccessMVC.Models.Clases
{
    public class Ref_AccessTipo
    {
        public int id_access_tipo { get; set; }
        public string desc_accessTipo { get; set; }


        axonAccessEntities1 db = new axonAccessEntities1();
        public List<Ref_AccessTipo> ReadAll()
        {
            return db.Ref_accessTipo.Select(c => new Ref_AccessTipo()
            {
                id_access_tipo = c.id_access_tipo,
                desc_accessTipo = c.desc_Access_tipo
            }).ToList();
        }
    }
}