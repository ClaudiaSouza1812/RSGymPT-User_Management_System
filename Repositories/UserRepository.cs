using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IAdminRepository _adminRepository;

        public UserRepository(IAdminRepository adminRepository)
        { 
            _adminRepository = adminRepository;
        }

        public bool CheckUserName(string userName)
        {
            return _adminRepository.GetAllUsers().Any(u => u.Username == userName);
        }

        public User ValidateUser(string userName, string password)
        {
            User user = _adminRepository.GetAllUsers().FirstOrDefault(u => u.Username == userName && u.Password == password);
            return user;
        }

        public bool CheckNif(User user)
        {
            return _adminRepository.GetAllUsers().Any(u => u.NIF == user.NIF);
        }
    }
}
