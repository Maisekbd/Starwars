using System;
using System.Collections.Generic;

namespace Starwars.Model.Models
{
    public partial class Planets
    {
        public Planets()
        {
            FilmsPlanets = new HashSet<FilmsPlanets>();
            People = new HashSet<People>();
        }

        public int Id { get; set; }
        public string Climate { get; set; }
        public DateTime? Created { get; set; }
        public string Diameter { get; set; }
        public DateTime? Edited { get; set; }
        public string Gravity { get; set; }
        public string Name { get; set; }
        public string OrbitalPeriod { get; set; }
        public string Population { get; set; }
        public string RotationPeriod { get; set; }
        public string SurfaceWater { get; set; }
        public string Terrain { get; set; }

        public virtual ICollection<FilmsPlanets> FilmsPlanets { get; set; }
        public virtual ICollection<People> People { get; set; }
    }
}
