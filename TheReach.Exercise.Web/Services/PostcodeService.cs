using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheReach.Exercise.DataModel.Models;
using TheReach.Exercise.Repository.DBRepository;

namespace TheReach.Exercise.Web.Services
{ 
    public interface IPostcodeService
    {
        IEnumerable<Postcode> GetPostcodes();
        Postcode GetPostcode(long id);
    }
    public class PostcodeService : IPostcodeService
    {
        private IRepository<Postcode> _postcodeRepository;

        public PostcodeService(IRepository<Postcode> postcodeRepository)
        {
            _postcodeRepository = postcodeRepository;
        }

        public IEnumerable<Postcode> GetPostcodes()
        {
            return _postcodeRepository.GetAll();
        }
        public Postcode GetPostcode(long id)
        {
            return _postcodeRepository.Get(id);
        }
    }
}
