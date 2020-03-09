using System;
using System.Collections.Generic;

namespace Starwars.Model.Models
{
    public partial class FilmsStarships
    {
        public int FilmId { get; set; }
        public int StarshipId { get; set; }

        public virtual Films Film { get; set; }
        public virtual Starships Starship { get; set; }
    }
}
