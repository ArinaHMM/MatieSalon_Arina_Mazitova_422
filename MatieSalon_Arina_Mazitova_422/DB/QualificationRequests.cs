//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MatieSalon_Arina_Mazitova_422.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class QualificationRequests
    {
        public int RequestID { get; set; }
        public int MasterID { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
        public int StatusID { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual RequestStatuses RequestStatuses { get; set; }
    }
}
