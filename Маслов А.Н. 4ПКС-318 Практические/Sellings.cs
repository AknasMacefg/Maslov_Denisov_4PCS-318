//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Маслов_А.Н._4ПКС_318_Практические
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sellings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sellings()
        {
            this.Selling_Details = new HashSet<Selling_Details>();
        }
    
        public int ID_продажи { get; set; }
        public int ID_покупателя { get; set; }
        public int ID_сотрудника { get; set; }
        public Nullable<System.DateTime> Дата { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual Employees Employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Selling_Details> Selling_Details { get; set; }
    }
}
