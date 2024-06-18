using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public User GetUserByName(string name);
        public User CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int id);
        public void ActiveUser(int id);
    }
}
