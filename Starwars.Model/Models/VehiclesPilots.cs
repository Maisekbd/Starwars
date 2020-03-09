using System;
using System.Collections.Generic;
using URF.Core.EF.Trackable;

namespace Starwars.Model.Models
{
    public partial class VehiclesPilots : Entity
    {
        public int VehicleId { get; set; }
        public int PeopleId { get; set; }

        public virtual People People { get; set; }
        public virtual Vehicles Vehicle { get; set; }
    }
}
