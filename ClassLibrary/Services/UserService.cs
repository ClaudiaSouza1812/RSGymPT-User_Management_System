using ClassLibrary.Interfaces.IRepositories;
using ClassLibrary.Interfaces.IServices;
using ClassLibrary.Models;
using ClassLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services
{
    internal class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string AskUserName()
        {
            RSGymUtility.WriteMessage("Insira seu nome de utilizador: ", "", "\n");

            string userName = Console.ReadLine().ToLower();
            return userName;
        }

        public string AskUserPassword()
        {
            RSGymUtility.WriteMessage("Insira sua palavra-passe: ", "", "\n");

            // Hide the password
            StringBuilder password = new StringBuilder();
            // Get the key pressed
            ConsoleKeyInfo key;

            do
            {
                // Get the key pressed without showing it
                key = Console.ReadKey(true);

                // If the key pressed is not Enter
                if (key.Key != ConsoleKey.Enter)
                {
                    // Append the key pressed to the password
                    password.Append(key.KeyChar);
                    // Show a * in the console
                    RSGymUtility.WriteMessage("*");
                }

            } while (key.Key != ConsoleKey.Enter);

            return password.ToString();
        }

        public List<User> CreateDefaultUsers()
        {
            List<User> defaultUsers = new List<User>()
            {
                new User("Mel Souza Magalhães", "melmag", "123456", Enums.EnumUserType.Admin),
                new User("Paula Magalhães", "paumag", "123456", Enums.EnumUserType.PowerUser),
                new User("Claudia Souza", "clasou", "123456", Enums.EnumUserType.SimpleUser),
            };

            return defaultUsers;
        }

        public User CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User LogInUser()
        {
            RSGymUtility.WriteTitle("Login", "", "\n\n");

            string userName = AskUserName();

            if (!_userRepository.CheckUserName(userName))
            {
                RSGymUtility.WriteMessage("Nome de utilizador inválido ou inexistente.", "", "\n");

                RSGymUtility.PauseConsole();
                return null;
            }

            string password = AskUserPassword();

            User user = ValidateUser(userName, UserUtility.EncryptPassword(password));

            if (user == null)
            {
                RSGymUtility.WriteMessage("Palavra-passe inválida.", "\n", "\n");

                RSGymUtility.PauseConsole();
                return user;
            }

            return user;
        }

        public User ValidateUser(string userName, string password)
        {
            User user = _userRepository.GetAllUsers().FirstOrDefault(u => u.UserName == userName && u.Password == password);
            return user;
        }
    }
}
