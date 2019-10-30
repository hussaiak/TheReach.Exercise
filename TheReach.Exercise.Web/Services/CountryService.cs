using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheReach.Exercise.DataModel.Models;
using TheReach.Exercise.Repository.DBRepository;

namespace TheReach.Exercise.Web.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountry(long id); 
    }
    public class CountryService : ICountryService
    {
        private IRepository<Country> _countryRepository;

        public CountryService(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _countryRepository.GetAll();
        }
        public async Task<Country> GetCountry(long id)
        {
            return await _countryRepository.Get(id);
        }
    }
}
