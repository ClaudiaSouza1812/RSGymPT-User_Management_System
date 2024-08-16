using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IMethods;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Methods;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptPassword _encryptPassword;
        private readonly IAdminRepository _adminRepository;

        public UserService(IUserRepository userRepository, IAdminRepository adminRepository, IEncryptPassword encryptPassword)
        {
            _userRepository = userRepository;
            _encryptPassword = encryptPassword;
            _adminRepository = adminRepository;
        }


        //HERE***

        public void CreateDefaultUsers()
        {
            List<User> defaultUsers = new List<User>()
            {
                new AdminUser("Mel", "Magalhães", "999999999", "mel@teste.com", "melmag", _encryptPassword.EncryptPassword("123456"), Enums.EnumUserType.Admin),
                new PowerUser("Paula", "Magalhães", "888888888", "paula@teste.com", "paumag", _encryptPassword.EncryptPassword("123456"), Enums.EnumUserType.PowerUser),
                new SimpleUser("Claudia", "Souza", "777777777", "claudia@teste.com", "clasou", _encryptPassword.EncryptPassword("123456"), Enums.EnumUserType.SimpleUser),
            };

            foreach (var user in defaultUsers)
            {
                if (!CheckNif(user))
                {
                    _adminRepository.AddUser(user);
                }
            }
        }

        public bool CheckNif(User user)
        {
            return _adminRepository.GetAllUsers().Any(u => u.NIF == user.NIF);
        }

        

       
    }
}
