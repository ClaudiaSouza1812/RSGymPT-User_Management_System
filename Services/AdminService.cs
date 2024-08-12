using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IModels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Services
{
    internal class AdminService : IAdminService
    {
        
        public User CreateUser()
        {
            User user = new User();

            (user.Name, user.LastName) = DefineFullName();

            if (string.IsNullOrEmpty(user.Name))
            {
                return null;
            }
            

            user.NIF = DefineNif();

            if (string.IsNullOrEmpty(user.NIF))
            {
                return null;
            }

            user.Email = DefineEmail();

            if (string.IsNullOrEmpty(user.Email))
            {
                return null;
            }

            (user.UserName, user.Password) = DefineFullAccess();

            if (string.IsNullOrEmpty(user.UserName))
            {
                return null;
            }

            return user;
        }

        public void DefineUserType(User user)
        {
            throw new NotImplementedException();
        }

        public void ListAllUsers()
        {
            throw new NotImplementedException();
        }

        public void ListUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void ListUsersByName(string name)
        {
            throw new NotImplementedException();
        }

        public (string, string) DefineFullName()
        {
            string name, lastName;
            do
            {
                Console.Clear();

                RSGymUtility.WriteTitle($"RSGymPT Menu de navegação", "", "\n\n");

                RSGymUtility.WriteMessage("Insira o nome do utilizador: ", "", "\n");

                name = Console.ReadLine().ToLower();

                RSGymUtility.WriteMessage("Insira o sobrenome do utilizador: ", "", "\n");

                lastName = Console.ReadLine().ToLower();

                if (!CheckFullName(name, lastName))
                {
                    RSGymUtility.WriteMessage("Nome vazio, com espaço ou com caracteres inválidos", "", "\n");
                }
                else
                {
                    return (char.ToUpper(name[0]) + name.Substring(1), char.ToUpper(lastName[0]) + lastName.Substring(1));
                }

            } while (KeepGoing());
            
            return (string.Empty, string.Empty);
        }

        public bool CheckFullName(string name, string lastName)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }
            if (name.Any(c => char.IsDigit(c) || !char.IsLetter(c)) || lastName.Any(c => char.IsDigit(c) || !char.IsLetter(c)))
            {
                return false;
            }
            return true;
        }

        
        public string DefineNif()
        {
            string nif;
            do
            {
                Console.Clear();

                RSGymUtility.WriteMessage("Insira o NIF do utilizador com 9 números: ", "", "\n");

                string answer = Console.ReadLine().ToLower();

                bool isNumber = int.TryParse(answer, out int _);

                if (!isNumber || answer.Length != 9)
                {
                    RSGymUtility.WriteMessage("Digite um NIF válido.", "\n");
                }
                else
                {
                    nif = answer;
                    return nif;
                }

            } while (KeepGoing());

            return string.Empty;
        }

        public string DefineEmail()
        {
            string email;
            do
            {
                Console.Clear();

                RSGymUtility.WriteMessage("Exemplo de email válido: teste@teste.com", "", "\n");

                RSGymUtility.WriteMessage("Insira o email do utilizador: ", "", "\n");

                email = Console.ReadLine().ToLower();

                if (!CheckEmail(email))
                {
                    RSGymUtility.WriteMessage("Insira um email válido", "", "\n");
                }
                else
                {
                    return email;
                }

            } while (KeepGoing());

            return string.Empty;
        }

        public bool CheckEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                return false;
            }
            return true;
        }

        public (string, string) DefineFullAccess()
        {
            string userName, password;
            do
            {
                Console.Clear();

                RSGymUtility.WriteMessage("Defina o username com 6 caracteres e sem espaços.", "\n", "\n");

                RSGymUtility.WriteMessage("Username: ", "", "\n");

                userName = Console.ReadLine().ToLower();

                RSGymUtility.WriteMessage("Defina a password com 6 caracteres e sem espaços.", "\n", "\n");

                RSGymUtility.WriteMessage("Password: ", "", "\n");

                password = Console.ReadLine().ToLower();


                if (!CheckUserName(userName))
                {
                    RSGymUtility.WriteMessage("Digite um username válido.", "\n");
                }
                else if (!CheckPassword(password))
                {
                    RSGymUtility.WriteMessage("Digite uma password válida.", "\n");
                }
                else
                {
                    return (userName, password);
                }

            } while (KeepGoing());

            return (string.Empty, string.Empty);
        }

        public bool CheckUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName) || userName.Length != 6)
            {
                return false;
            }
            return true;
        }

        public bool CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password) || password.Length != 6)
            {
                return false;
            }
            return true;
        }

        // Function to ask and return the user choice
        public bool KeepGoing()
        {
            RSGymUtility.WriteMessage("Continuar? (s/n): ", "\n");

            string answer = Console.ReadLine().ToLower();

            if (answer == "s")
            {
                return true;
            }
            if (answer == "n")
            {
                return false;
            }
            return true;
        }
    }
}
