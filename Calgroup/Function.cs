//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Calgroup
{
    using System;
    using System.Collections.Generic;
    
    public partial class Function
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Function()
        {
            this.Functions1 = new HashSet<Function>();
            this.Permissions = new HashSet<Permission>();
        }
    
        public string ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int DisplayOrder { get; set; }
        public string ParentId { get; set; }
        public bool Status { get; set; }
        public string IconCss { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Function> Functions1 { get; set; }
        public virtual Function Function1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
