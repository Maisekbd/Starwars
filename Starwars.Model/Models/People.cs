using System;
using System.Collections.Generic;
using URF.Core.EF.Trackable;

namespace Starwars.Model.Models
{
    public partial class People : Entity
    {
        public People()
        {
            FilmsCharacters = new HashSet<FilmsCharacters>();
            StarshipsPilots = new HashSet<StarshipsPilots>();
            VehiclesPilots = new HashSet<VehiclesPilots>();
        }

        public int Id { get; set; }
        public string BirthYear { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Edited { get; set; }
        public string EyeColor { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public string Height { get; set; }
        public int? Homeworld { get; set; }
        public string Mass { get; set; }
        public string Name { get; set; }
        public string SkinColor { get; set; }
        public int? SpeciesId { get; set; }

        public virtual Planets HomeworldNavigation { get; set; }
        public virtual Species Species { get; set; }
        public virtual ICollection<FilmsCharacters> FilmsCharacters { get; set; }
        public virtual ICollection<StarshipsPilots> StarshipsPilots { get; set; }
        public virtual ICollection<VehiclesPilots> VehiclesPilots { get; set; }
    }
}
