//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReservationsDolphinDiscoveryII.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class HotelsInCities
    {
        public int pkHotelsInCitiespkHotelsInCities { get; set; }
        public int fkHotel { get; set; }
        public int fkCity { get; set; }
    
        public virtual Cities Cities { get; set; }
        public virtual Hotels Hotels { get; set; }
    }
}
