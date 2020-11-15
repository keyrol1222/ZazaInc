//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZazaInc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            this.Terminars = new HashSet<Terminar>();
            this.Vacaciones = new HashSet<Vacacione>();
        }
    
        public int id_empleado { get; set; }
        public string nombre_empleado { get; set; }
        public string apellido_empleado { get; set; }
        public string posicion_empleado { get; set; }
        public int cedula_empleado { get; set; }
        public string correo_usuario { get; set; }
        public int pago_empleado { get; set; }
        public string horario_empleado { get; set; }
        public Nullable<int> departamento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Terminar> Terminars { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacacione> Vacaciones { get; set; }
        public virtual Departamento Departamento1 { get; set; }
    }
}
