//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BasovHotel
{
    using System;
    using System.Collections.Generic;
    
    public partial class List_of_services
    {
        public int id_los { get; set; }
        public Nullable<int> Client { get; set; }
        public Nullable<int> Service { get; set; }
        public Nullable<int> num_of_service_render { get; set; }
        public Nullable<int> Staff_id { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Services Services { get; set; }
    }
}