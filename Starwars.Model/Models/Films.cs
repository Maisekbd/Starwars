using System;
using System.Collections.Generic;
using URF.Core.EF.Trackable;

namespace Starwars.Model.Models
{
    public partial class Films :Entity
    {
        public Films()
        {
            FilmsCharacters = new HashSet<FilmsCharacters>();
            FilmsPlanets = new HashSet<FilmsPlanets>();
            FilmsSpecies = new HashSet<FilmsSpecies>();
            FilmsStarships = new HashSet<FilmsStarships>();
            FilmsVehicles = new HashSet<FilmsVehicles>();
        }

        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public string Director { get; set; }
        public DateTime? Edited { get; set; }
        public int? EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Producer { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Title { get; set; }

        public virtual ICollection<FilmsCharacters> FilmsCharacters { get; set; }
        public virtual ICollection<FilmsPlanets> FilmsPlanets { get; set; }
        public virtual ICollection<FilmsSpecies> FilmsSpecies { get; set; }
        public virtual ICollection<FilmsStarships> FilmsStarships { get; set; }
        public virtual ICollection<FilmsVehicles> FilmsVehicles { get; set; }
    }
}
