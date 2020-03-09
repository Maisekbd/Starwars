using Starwars.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URF.Core.Abstractions.Services;

namespace Starwars.Service.IServices
{
    public interface IPeopleService : IService<People>
    {
        public IQueryable<People> Gets();

        public Task<Object> GetMostAppeared();

        public Task<object> GetSpicesApperedCountInFilm();

        public Task<object> GetSpicesApperedCount();

        public Task<object> GetPilotsProvidedByPlant();
    }
}