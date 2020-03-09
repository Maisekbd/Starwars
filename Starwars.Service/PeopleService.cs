using Starwars.Model.Models;
using Starwars.Service.IServices;
using Starwars.Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URF.Core.Services;

namespace Starwars.Service
{
    public class PeopleService : Service<People>, IPeopleService
    {

        private readonly IStarwarsUnitOfWork _unitOfwork;
        public PeopleService(
            IStarwarsUnitOfWork unitOfwork
            ) : base(unitOfwork.PeopleRepository)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task<Object> GetMostAppeared()
        {
            var list = (await _unitOfwork.FilmsCharactersRepository.Query().Include(c => c.People).SelectAsync())
                .Select(c => new { PeopleId = c.PeopleId, Name = c.People.Name, filmID = c.FilmId }).GroupBy(c => c.PeopleId)
                .Select(c => new { Name = c.First().Name, CountFilms = c.Count() }).OrderByDescending(c => c.CountFilms);
            return list.Where(c => c.CountFilms == list.FirstOrDefault().CountFilms);

        }

        public IQueryable<People> Gets()
        {
            return _unitOfwork.PeopleRepository.Queryable();
        }

        /// <summary>
        /// GetSpicesApperedCount In Film that has most spices
        /// </summary>
        /// <returns></returns>
        public async Task<object> GetSpicesApperedCountInFilm()
        {
            return (await _unitOfwork.FilmsCharactersRepository.Query().Include("People.Species").SelectAsync())
                .Where(c => c.People.Species != null)
                  .Select(c => new { SpeciesId = c.People.SpeciesId, SpeciesName = c.People.Species.Name, PeopleId = c.PeopleId, FilmId = c.FilmId })
                  .GroupBy(c => c.FilmId)
                  .Select(c => new { FilmId = c.Key, appeared = c.Count(), items = c.Select(d => d) })
            .OrderByDescending(c => c.appeared).FirstOrDefault()
            .items.GroupBy(c => c.SpeciesName)
            .Select(c => new { SpeciesName = c.Key, ApperedCount = c.Count() })
            .OrderByDescending(c => c.ApperedCount);
        }

        public async Task<object> GetSpicesApperedCount()
        {
            return (await _unitOfwork.FilmsCharactersRepository.Query().Include("People.Species").SelectAsync())
                .Where(c => c.People.Species != null)
                  .Select(c => new { SpeciesId = c.People.SpeciesId, SpeciesName = c.People.Species.Name, PeopleId = c.PeopleId, FilmId = c.FilmId })
                  .GroupBy(c => c.SpeciesName)
                  .Select(c => new { SpeciesName = c.Key, AppearedCount = c.Count() })
                  .OrderByDescending(c => c.AppearedCount);
        }

        public async Task<object> GetPilotsProvidedByPlant()
        {
            return (await _unitOfwork.VehiclesPilotsRepository.Query()
                .Include("People.HomeworldNavigation").SelectAsync())
                .Select(c => new { PlantName = c.People.HomeworldNavigation.Name, PilotName = c.People.Name })
                .GroupBy(c => c.PlantName)
                .Select(c => new{ PlantName = c.Key, PilotCount = c.Distinct().Count() , PilotNames = c.Distinct().Select(d=>d.PilotName) })
                .OrderByDescending(c=>c.PilotCount);
        }

    }
}