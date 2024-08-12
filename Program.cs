
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IMethods;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Methods;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Repositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Services;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Method to output characters encoded to UTF-8 
            RSGymUtility.SetUnicodeConsole();

            IAdminRepository adminRepository = new AdminRepository();
            IUserRepository userRepository = new UserRepository(adminRepository);
            IEncryptPassword encryptPassword = new EncryptPassword();
            
            IUserService userService = new UserService(userRepository, adminRepository, encryptPassword);
            userService.CreateDefaultUsers();
            IAdminService adminService = new AdminService();

            IAppService appService = new AppService(userService, adminService, adminRepository);

            appService.RunRSGymProgram();

        }
    }
}
