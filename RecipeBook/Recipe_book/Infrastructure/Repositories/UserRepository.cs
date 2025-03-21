using Application.Abstractions;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;
        public UserRepository() { 
            _users = new List<User>();
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public List<User> FindUsers(Predicate<User> predicate)
        {
            return _users.FindAll(predicate);
        }

        public User GetUserById(int id)
        {
            return _users.First(x => x.UserId == id);
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public void RemoveUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}
