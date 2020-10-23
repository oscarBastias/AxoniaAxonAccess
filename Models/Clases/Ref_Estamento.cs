using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxonAccessMVC.Models.Clases
{
    public class Ref_Estamento
    {
        public int id_estamento { get; set; }
        public string desc_estamento { get; set; }


        axonAccessEntities1 db = new axonAccessEntities1();
        public List<Ref_Estamento> ReadAll()
        {
            return db.Ref_Estamento.Select(c => new Ref_Estamento()
            {
                id_estamento = c.id_estamento,
                desc_estamento = c.desc_estamento
            }).ToList();
        }
    }
}