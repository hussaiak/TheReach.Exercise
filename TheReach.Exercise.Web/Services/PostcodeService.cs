using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheReach.Exercise.DataModel.Models;
using TheReach.Exercise.Repository.DBRepository;
using TheReach.Exercise.Web.ViewModel;

namespace TheReach.Exercise.Web.Services
{ 
    public interface IPostcodeService
    {
        Task<IEnumerable<Postcode>> GetPostcodes();
        Task<Postcode> GetPostcode(long id);

        Task<IEnumerable<string>> GetStatesByCountryCode(string countryCode);
        Task<IEnumerable<PostcodeLocality>> GetLocalityByStateCode(string stateCode);
    }
    public class PostcodeService : IPostcodeService
    {
        private IRepository<Postcode> _postcodeRepository;

        public PostcodeService(IRepository<Postcode> postcodeRepository)
        {
            _postcodeRepository = postcodeRepository;
        }

        public async Task<IEnumerable<Postcode>> GetPostcodes()
        {
            return await _postcodeRepository.GetAll();
        }
        public async Task<Postcode> GetPostcode(long id)
        {
            return await _postcodeRepository.Get(id);
        }

        public async Task<IEnumerable<string>> GetStatesByCountryCode(string countryCode)
        {
            var result = await GetPostcodes();
            return result?.Where(e => e.CountryCode == countryCode)?.Select(e => e.State).Distinct();
        }

        public async Task<IEnumerable<PostcodeLocality>> GetLocalityByStateCode(string stateCode)
        {
            var result = await GetPostcodes();
            return  result?.Where(e => e.State == stateCode)?
                .Select(e => new PostcodeLocality
                {
                    Postcode = e.Pcode,
                    Locality = e.Locality
                }).Distinct();
        }
    }
}
