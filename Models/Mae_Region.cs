//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AxonAccessMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mae_Region
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mae_Region()
        {
            this.Mae_Comuna = new HashSet<Mae_Comuna>();
        }
    
        public int id_region { get; set; }
        public string desc_region { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mae_Comuna> Mae_Comuna { get; set; }
    }
}
