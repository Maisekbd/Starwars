using System;
using System.Collections.Generic;
using URF.Core.EF.Trackable;

namespace Starwars.Model.Models
{
    public partial class FilmsSpecies :Entity
    {
        public int FilmId { get; set; }
        public int SpeciesId { get; set; }

        public virtual Films Film { get; set; }
        public virtual Species Species { get; set; }
    }
}
