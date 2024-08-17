
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IMethods;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Methods;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Repositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Services;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Method to output characters encoded to UTF-8 

            RSGymUtility.SetUnicodeConsole();

            IAdminRepository adminRepository = new AdminRepository();
            IPowerUserService powerUserService = new PowerUserService(adminRepository);
            ISimpleUserService simpleUserService = new SimpleUserService(adminRepository);
            IUserRepository userRepository = new UserRepository(adminRepository);
            IEncryptPassword encryptPassword = new EncryptPassword();

            ILoginService loginService = new LoginService(userRepository, encryptPassword);
            IUserService userService = new UserService(userRepository, adminRepository, encryptPassword);
            userService.CreateDefaultUsers();

            IAdminService adminService = new AdminService(adminRepository);

            AppService appService = new AppService(loginService, userService, adminService, adminRepository, powerUserService, simpleUserService);

            appService.RunRSGymProgram();
        }
    }
}
