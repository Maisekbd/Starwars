using Starwars.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using URF.Core.Abstractions;
using URF.Core.Abstractions.Trackable;

namespace Starwars.Service.UnitOfWork
{
   public interface IStarwarsUnitOfWork : IUnitOfWork
    {
        public ITrackableRepository<People> PeopleRepository { get; }

        public ITrackableRepository<Films> FilmsRepository { get; }

        public ITrackableRepository<FilmsCharacters> FilmsCharactersRepository { get; }

        public ITrackableRepository<FilmsSpecies> FilmsSpeciesRepository { get; }

        public ITrackableRepository<VehiclesPilots> VehiclesPilotsRepository { get; }
    }
}

