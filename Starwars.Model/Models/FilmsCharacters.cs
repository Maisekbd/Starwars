using System;
using System.Collections.Generic;
using URF.Core.EF.Trackable;

namespace Starwars.Model.Models
{
    public partial class FilmsCharacters : Entity
    {
        public int FilmId { get; set; }
        public int PeopleId { get; set; }

        public virtual Films Film { get; set; }
        public virtual People People { get; set; }
    }
}
