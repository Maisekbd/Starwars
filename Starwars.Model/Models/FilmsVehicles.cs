using System;
using System.Collections.Generic;

namespace Starwars.Model.Models
{
    public partial class FilmsVehicles
    {
        public int FilmId { get; set; }
        public int VehicleId { get; set; }

        public virtual Films Film { get; set; }
        public virtual Vehicles Vehicle { get; set; }
    }
}
