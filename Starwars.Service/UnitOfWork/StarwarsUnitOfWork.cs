using Microsoft.EntityFrameworkCore;
using Starwars.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using URF.Core.Abstractions.Trackable;
using URF.Core.EF;

namespace Starwars.Service.UnitOfWork
{
    public class StarwarsUnitOfWork : URF.Core.EF.UnitOfWork, IStarwarsUnitOfWork
    {
        public StarwarsUnitOfWork(DbContext context,
            ITrackableRepository<People> peopleRepository,
            ITrackableRepository<Films> filmsRepository,
            ITrackableRepository<FilmsCharacters> filmsCharactersRepository,
            ITrackableRepository<FilmsSpecies> filmsSpeciesRepository,
            ITrackableRepository<VehiclesPilots> vehiclesPilotsRepository
          ) : base(context)
        {
            PeopleRepository = peopleRepository;
            FilmsRepository = filmsRepository;
            FilmsCharactersRepository = filmsCharactersRepository;
            FilmsSpeciesRepository = filmsSpeciesRepository;
            VehiclesPilotsRepository = vehiclesPilotsRepository;
        }

        public ITrackableRepository<People> PeopleRepository { get; }

        public ITrackableRepository<Films> FilmsRepository { get; }

        public ITrackableRepository<FilmsCharacters> FilmsCharactersRepository { get; }

        public ITrackableRepository<FilmsSpecies> FilmsSpeciesRepository { get; }

        public ITrackableRepository<VehiclesPilots> VehiclesPilotsRepository { get; }
    }
}
