using Starwars.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using URF.Core.Abstractions.Services;

namespace Starwars.Service.IServices
{
    public interface IFilmsService : IService<Films>
    {
        public Task<Films> GetLongestOpeningCrawl();
    }
}