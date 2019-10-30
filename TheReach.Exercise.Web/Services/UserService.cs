using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheReach.Exercise.DataModel.Models;
using TheReach.Exercise.Repository.DBRepository;
using TheReach.Exercise.Web.ViewModel;

namespace TheReach.Exercise.Web.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<bool> SubmitUserApplication(UserDetails userDetails);
        Task<User> GetUser(long id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(long id);
    }

    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<bool> SubmitUserApplication(UserDetails userDetails)
        {
            var result = true;
            try
            {
                var fullName = userDetails.FullName?.Split(" ");
                var users = await GetUsers();
                var user = new User
                {
                    Id = users?.Count() > 0 ? Convert.ToInt32(users?.LastOrDefault()?.Id) + 1 : 1,
                    FirstName = fullName.Count() > 0 ? fullName[0] : string.Empty,
                    LastName = fullName.Count() > 0 ? fullName[1] : string.Empty,
                    Country = userDetails.Country,
                    Locality = userDetails.Locality,
                    State = userDetails.State,
                    Postcode = userDetails.Postcode 
                };
                _userRepository.Insert(user);
            }
            catch(Exception ex)
            {
                //log exception
                result = false;
            }
            return result;
        }
        public async Task<User> GetUser(long id)
        {
            return await _userRepository.Get(id);
        }
        public void InsertUser(User user)
        {
            _userRepository.Insert(user);
        }
        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public async void DeleteUser(long id)
        {
            User user =  await GetUser(id);
            _userRepository.Remove(user);
            _userRepository.SaveChanges();
        }
    }
}
