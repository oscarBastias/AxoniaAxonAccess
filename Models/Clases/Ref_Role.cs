using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AxonAccessMVC.Models.Clases
{
    public class Ref_Role
    {
        public int id_role { get; set; }
        public string desc_role { get; set; }


        axonAccessEntities1 db = new axonAccessEntities1();
        public List<Ref_Role> ReadAll()
        {
            return db.Ref_Role.Select(c => new Ref_Role()
            {
                id_role = c.id_role,
                desc_role = c.desc_role
            }).ToList();
        }
    }

}