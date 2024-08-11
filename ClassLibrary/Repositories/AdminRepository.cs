using ClassLibrary.Interfaces.IRepositories;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary.Repositories
{
    internal class AdminRepository : IAdminRepository
    {
        private readonly List<User> _users;

        public AdminRepository(List<User> users)
        { 
            _users = users;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsersByName(string name)
        {
            return _users.Where(u => u.UserName == name);
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }
    }
}
