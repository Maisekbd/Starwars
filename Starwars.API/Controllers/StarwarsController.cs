using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Starwars.Model.Models;
using Starwars.Service.IServices;

namespace Starwars.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StarwarsController : ControllerBase
    {
        private readonly ILogger<StarwarsController> _logger;
        private readonly IPeopleService _peopleService;
        private readonly IFilmsService _filmsService;

        public StarwarsController(ILogger<StarwarsController> logger,
            IPeopleService peopleService,
            IFilmsService filmsService)
        {
            _logger = logger;
            _peopleService = peopleService;
            _filmsService = filmsService;
        }

        [HttpGet]
        public async Task<Films> GetLongestOpeningCrawl()
        {
            return await _filmsService.GetLongestOpeningCrawl();
        }

        [HttpGet]
        public async Task<object> GetMostAppeared()
        {
            return await _peopleService.GetMostAppeared();
        }

        [HttpGet]
        public async Task<object> GetSpicesApperedCountInFilm()
        {
            return await _peopleService.GetSpicesApperedCountInFilm();
        }

        [HttpGet]
        public async Task<object> GetSpicesApperedCount()
        {
            return await _peopleService.GetSpicesApperedCount();
        }


        [HttpGet]
        public async Task<object> GetPilotsProvidedByPlant()
        {
            return await _peopleService.GetPilotsProvidedByPlant();
        }

    }


}
