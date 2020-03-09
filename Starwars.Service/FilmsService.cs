using Starwars.Model.Models;
using Starwars.Service.IServices;
using Starwars.Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using URF.Core.Services;
using System.Linq;

namespace Starwars.Service
{
    public class FilmsService : Service<Films>, IFilmsService
    {

        private readonly IStarwarsUnitOfWork _unitOfwork;
        public FilmsService(
            IStarwarsUnitOfWork unitOfwork
            ) : base(unitOfwork.FilmsRepository)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task<Films> GetLongestOpeningCrawl()
        {
            return (await _unitOfwork.FilmsRepository.Query().OrderByDescending(c=>c.OpeningCrawl.Length).SelectAsync()).FirstOrDefault();
        }
    }
}