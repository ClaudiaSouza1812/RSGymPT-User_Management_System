using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IMethods;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility;
using System;
using System.Text;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncryptPassword _encryptPassword;

        public LoginService(IUserRepository userRepository, IEncryptPassword encryptPassword)
        { 
            _userRepository = userRepository;
            _encryptPassword = encryptPassword;
        }

        public User GetLoginCredentials()
        {
            RSGymUtility.WriteLoginTitle("Login", "", "\n\n");

            string username = AskUsername();
            string password = AskUserPassword();

            User user = CheckLoginCredentials(username, password);

            ShowLoginMessage(user);

            return user;
        }

        public User CheckLoginCredentials(string username, string password)
        {
            if (!_userRepository.CheckUserName(username))
            {
                return null;
            }

            string encryptedPassword = _encryptPassword.EncryptPassword(password);

            User user = _userRepository.ValidateUser(username, encryptedPassword);

            return user;
        }

        public void ShowLoginMessage(User user)
        {
            if (user == null)
            {
                RSGymUtility.WriteMessage("Login inválido, cheque seu nome de usuário e palavra passe.", "\n", "\n");
                RSGymUtility.PauseConsole();
            }
        }



        public string AskUsername()
        {
            string message = "Insira seu nome de utilizador: ";
            RSGymUtility.WriteMessage($"{message}", "", "");

            string userName = Console.ReadLine().ToLower();
            return userName;
        }

        public string AskUserPassword()
        {
            string message = "Insira sua palavra-passe: ";
            RSGymUtility.WriteMessage($"{message}", "\n", "");

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
    }
}
