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

        public string desc_pais { get; set; }
        public int id_pais { get; set; }

        axonAccessEntities1 db = new axonAccessEntities1();
        public List<Mae_Comuna> ReadAll()
        {
            return db.Mae_Comuna.Select(c => new Mae_Comuna()
            {
                id_comuna = c.id_comuna,
                id_region = (int)c.id_region,
                desc_comuna= c.desc_comuna
            }).OrderBy(x => x.desc_comuna).ToList();
        }
        public List<Mae_Comuna> ReadAllFiltrado(int id)
        {
            return (from com in db.Mae_Comuna
                    join reg in db.Mae_Region on com.id_region equals reg.id_region
                    join pa in db.Mae_Pais on reg.id_pais equals pa.id_pais
                    select new Models.Clases.Mae_Comuna
                    {
                        id_comuna = (int)com.id_comuna,
                        id_region = (int)com.id_region,
                        id_pais = (int)pa.id_pais,
                        desc_comuna = com.desc_comuna,
                        desc_pais = pa.desc_pais

                    }).Where(p => p.id_pais==id).OrderByDescending(x => x.id_comuna).ToList();
        }
    }
}
