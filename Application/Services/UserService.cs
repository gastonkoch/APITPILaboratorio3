using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMainRepository _mainRepository;
        public UserService(IMainRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        public List<User> GetUsers()
        {
            return _mainRepository.GetUsers();
        }

        public User GetUserById(int id)
        {
            return _mainRepository.GetUserById(id);
        }

        public User GetUserByName(string name)
        {
            return _mainRepository.GetUserByName(name);
        }

        public User GetUserByType(UserType type)
        {
            return _mainRepository.GetUserByType(type);
        }

        public User CreateUser(User user)
        {
            return _mainRepository.CreateUser(user);
        }

        public void UpdateUser(User user)
        {
            _mainRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _mainRepository.DeleteUser(id);
        }

        public void ActiveUser(int id)
        {
            _mainRepository.ActiveUser(id);
        }
    }
}
