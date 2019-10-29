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
        IEnumerable<Country> GetCountries();
        Country GetCountry(long id); 
    }
    public class CountryService : ICountryService
    {
        private IRepository<Country> _countryRepository;

        public CountryService(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IEnumerable<Country> GetCountries()
        {
            return _countryRepository.GetAll();
        }
        public Country GetCountry(long id)
        {
            return _countryRepository.Get(id);
        }
    }
}
