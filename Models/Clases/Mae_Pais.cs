using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxonAccessMVC.Models.Clases
{
    public class Mae_Pais
    {
        public int id_pais { get; set; }
        public string desc_pais { get; set; }
        public string cod_pais { get; set; }
        public int id_comuna { get; set; }


        axonAccessEntities1 db = new axonAccessEntities1();
        public List<Mae_Pais> ReadAll()
        {
            return db.Mae_Pais.Select(c => new Mae_Pais()
            {
                id_pais = c.id_pais,
                desc_pais = c.desc_pais,
                cod_pais = c.cod_pais
            }).OrderBy(x => x.desc_pais).ToList();
        }
        public List<Mae_Pais> ReadAllFiltrado(int id)
        {
            return db.Mae_Pais.Select(c => new Mae_Pais()
            {
                id_pais = c.id_pais,
                desc_pais = c.desc_pais,
                cod_pais = c.cod_pais
            }).Where(p => p.id_pais == id).OrderBy(x => x.desc_pais).ToList();
        }
    }
}