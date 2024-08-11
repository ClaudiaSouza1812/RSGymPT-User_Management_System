using ClassLibrary.Interfaces.IModels;
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
    internal class AppService : IAppService
    {
        public IUser _user;
        public readonly IUserService _userService;
        

        public AppService(IUserService userService)
        { 
            _userService = userService;
        }


        public void RunMainMenu()
        {
            /*
            switch (_user.UserType)
            {
                case Enums.EnumUserType.Admin:
                    RunAdminMainMenu();
                    break;
                case Enums.EnumUserType.PowerUser:
                    RunPowerUserMainMenu();
                    break;
                case Enums.EnumUserType.SimpleUser:
                    RunSimpleUserMainMenu();
                    break;
            }
            */
            throw new NotImplementedException();
        }

        public void RunLoginMenu()
        {
            // Show the login menu
            Dictionary<string, string> loginMenu = ShowLoginMenu();

            string loginAction;
            int loginKey;

            do
            {
                loginKey = GetUserChoice("login", string.Empty);
                loginAction = ValidateLoginMenu(loginMenu, loginKey);

                if (loginAction == "Sair")
                {
                    ShowLogo("end", "Obrigada");
                    return;
                }

                if (loginAction == "Login")
                {
                    _user = _userService.LogInUser();
                }

            } while (loginAction != "Sair" && _user == null);

            if (_user != null)
            {
                // Show the RSGymPT logo
                ShowLogo("begin", _user.Name);

                // Run the main menu
                RunMainMenu();
            }
            
        }

        // Get user menu number choice
        public int GetUserChoice(string chosenMenu, string userName)
        {
            int menuNumber;
            bool status;
            do
            {
                Console.Clear();

                ShowMenu(chosenMenu, userName);

                RSGymUtility.WriteMessage("Número: ", "\n", "");
                string answer = Console.ReadLine();

                status = int.TryParse(answer, out menuNumber);

                if (!status)
                {
                    RSGymUtility.WriteMessage("Digite um número válido.", "\n");
                }

            } while (!status);

            return menuNumber;
        }

        // Show the chosen menu
        public void ShowMenu(string menu, string userName)
        {
            if (menu == "login")
            {
                ShowLoginMenu();
            }
            else
            {
                ShowMainMenu(userName);
            }
        }

        // Function to show and return the main menu
        public Dictionary<string, Dictionary<string, string>> ShowMainMenu(string userName)
        {
            Console.Clear();

            RSGymUtility.WriteTitle("RSGymPT Menu de navegação", "", "\n\n");
            RSGymUtility.WriteMessage($"{userName}, Digite o número da \nopção desejada e aperte 'Enter'", "", "\n\n");

            Dictionary<string, Dictionary<string, string>> mainMenu = new Dictionary<string, Dictionary<string, string>>()
            {
                { "Pedido", new Dictionary<string, string>()
                    {
                        {"1", "Registar" },
                        {"2", "Alterar" },
                        {"3", "Eliminar" },
                        {"4", "Listar" },
                        {"5", "Terminar" }
                    }
                },
                { "Personal Trainer", new Dictionary<string, string>()
                    {
                        {"6", "Pesquisar" },
                        {"7", "Listar" }
                    }
                },
                { "Utilizador", new Dictionary<string, string>()
                    {
                        {"8", "Listar" },
                        {"9", "Logout" }
                    }
                }
            };

            foreach (KeyValuePair<string, Dictionary<string, string>> menu in mainMenu)
            {
                RSGymUtility.WriteTitle($"{menu.Key}", "", "\n");

                foreach (KeyValuePair<string, string> subMenu in menu.Value)
                {
                    RSGymUtility.WriteMessage($"({subMenu.Key}) - {subMenu.Value}", "", "\n");
                }
            }

            return mainMenu;
        }


        // Validate the login menu
        public string ValidateLoginMenu(Dictionary<string, string> loginMenu, int key)
        {
            string action;
            bool status;

            status = loginMenu.TryGetValue(key.ToString(), out action);

            if (status)
            {
                return action;
            }

            RSGymUtility.WriteMessage($"Escolha um número válido.", "\n", "\n");

            RSGymUtility.PauseConsole();

            return string.Empty;
        }

        // Show RSGymPT logo
        public void ShowLogo(string status, string userName)
        {
            Console.Clear();

            RSGymUtility.WriteTitle("RSGymPT APP", "", "\n\n");

            Console.ForegroundColor = ConsoleColor.Yellow;

            string[] logo =
            {
                "-------------------------------",
                "|  _____    _____   ___       |",
                "| | |   |  |  ___| | _/|      |",
                "| | |___|  | |___  |___|      |",
                "| | |\\\\    |___  |  | |       |",
                "| | | \\\\    ___| |  | |´ ' `\\ |",
                "| |_|  \\\\  |_____|  |_______/ |",
                "|                             |",
                "-------------------------------"
            };

            foreach (string item in logo)
            {
                RSGymUtility.WriteMessage($"{item}\n");
            }

            ShowLogoMessage(status, userName);

            Console.ForegroundColor = ConsoleColor.White;
        }

        // Function to show and return the login menu
        public Dictionary<string, string> ShowLoginMenu()
        {
            Console.Clear();

            RSGymUtility.WriteTitle("RSGymPT Login Menu", "", "\n\n");
            RSGymUtility.WriteMessage($"Digite o número da opção e aperte 'Enter'", "", "\n\n");

            Dictionary<string, string> loginMenu = new Dictionary<string, string>()
            {
                {"1", "Login" },
                {"2", "Sair" }
            };

            foreach (KeyValuePair<string, string> item in loginMenu)
            {
                RSGymUtility.WriteMessage($"({item.Key}) - {item.Value}", "", "\n");
            }

            return loginMenu;
        }

        // Show RSGymPT logo message
        public void ShowLogoMessage(string status, string userName)
        {
            string message01 = $"Bem vindo(a)! {userName}!\n\tVamos treinar?";
            string message02 = $"{userName}, até a próxima!";

            if (status == "begin")
            {
                RSGymUtility.WriteMessage($"{message01.PadLeft(15 - (message01.Length / 2) + message01.Length, ' ')}", "", "\n\n");

                RSGymUtility.PauseConsole();
            }
            else
            {
                RSGymUtility.WriteMessage($"{message02.PadLeft(15 - (message02.Length / 2) + message02.Length, ' ')}", "", "\n");

                RSGymUtility.PauseConsole();
            }
        }

        public void RunRSGymProgram()
        {
            RunLoginMenu();
        }
    }
}
