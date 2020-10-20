using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxonAccessMVC.Models.Clases
{
    public class Mae_Comuna
    {
        public int id_comuna { get; set; }
        public int id_region { get; set; }
        public string desc_comuna { get; set; }


        axonAccessEntities1 db = new axonAccessEntities1();
        public List<Mae_Comuna> ReadAll()
        {
            return db.Mae_Comuna.Select(c => new Mae_Comuna()
            {
                id_comuna = c.id_comuna,
                id_region = (int)c.id_region,
                desc_comuna= c.desc_comuna
            }).ToList();
        }
    }
}
