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
    
    public partial class Hotels
    {
        public Hotels()
        {
            this.HotelsInCities = new HashSet<HotelsInCities>();
        }
    
        public int pkHotel { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<HotelsInCities> HotelsInCities { get; set; }
    }
}
