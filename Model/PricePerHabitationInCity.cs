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
    
    public partial class PricePerHabitationInCity
    {
        public int pkPricePerHabitation { get; set; }
        public int fkCity { get; set; }
        public int fkStagesAndAges { get; set; }
        public int fkRoom { get; set; }
        public decimal price { get; set; }
    
        public virtual Cities Cities { get; set; }
        public virtual Rooms Rooms { get; set; }
        public virtual StagesAndAges StagesAndAges { get; set; }
    }
}
