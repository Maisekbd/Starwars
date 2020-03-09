using System;
using System.Collections.Generic;

namespace Starwars.Model.Models
{
    public partial class StarshipsPilots
    {
        public int StarshipId { get; set; }
        public int PeopleId { get; set; }

        public virtual People People { get; set; }
        public virtual Starships Starship { get; set; }
    }
}
