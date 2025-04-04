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

        private const string FilePath = "Users.txt";
        private List<User> _users;
        public UserRepository() {
            _users = LoadUsers();
        }

        private void SaveUsers()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    foreach (var user in _users)
                    {
                        sw.WriteLine($"{user.UserId}.{user.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private List<User> LoadUsers()
        {
            var users = new List<User>();
            try
            {
                if (!File.Exists(FilePath))
                {
                    try
                    {
                        File.WriteAllText(FilePath, "");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    return users;
                }
                else
                {
                    using (StreamReader sr = new StreamReader(FilePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var parts = line.Split('.');
                            users.Add(new User
                            {

                                UserId = int.Parse(parts[0]),
                                Name = parts[1]
                            });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            return users;
        }
        public void AddUser(User user)
        {
            _users.Add(user);
            SaveUsers();
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
                SaveUsers();
            }
        }
    }
}
