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
    
    public partial class Supplies_Details
    {
        public int ID_supply { get; set; }
        public int ID_products { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Supplies Supplies { get; set; }
    }
}
