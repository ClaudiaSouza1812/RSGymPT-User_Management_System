using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IModels;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Services
{
    public class AppService : IAppService
    {
        public static User _currentUser;
        private User user;
        public readonly IUserService _userService;
        public readonly IAdminService _adminService;
        public readonly IAdminRepository _adminRepository;

        public AppService() { }

        public AppService(IUserService userService, IAdminService adminService, IAdminRepository adminRepository)
        {
            _userService = userService;
            _adminService = adminService;
            _adminRepository = adminRepository;
        }

        static string currentUser = UpdateScreenUserType();

        public void RunMainMenu()
        {
            
            switch (_currentUser.UserType)
            {
                case EnumUserType.Admin:
                    RunAdminMainMenu();
                    break;
                    /*
                case Enums.EnumUserType.PowerUser:
                    RunPowerUserMainMenu();
                    break;
                case Enums.EnumUserType.SimpleUser:
                    RunSimpleUserMainMenu();
                    break;
                    */
            }
            
        }

        public void RunAdminMainMenu()
        {
            // Show the main menu
            Dictionary<int, string> adminMainMenu = ShowAdminMainMenu();

            int menuKey;
            (int, string) menuAction;

            // Run the main menu
            
            menuKey = GetUserChoice("main");
            menuAction = ValidateAdminMainMenu(adminMainMenu, menuKey);
                
            RunAdminSubmenu(menuAction.Item2);
               
            /*
            // Show the RSGymPT logo
            ShowLogo("end", _currentUser);

            RunLoginMenu();
            */
        }

        public void RunAdminChangeMenu()
        {

            do
            {
                // Show the admin change menu
                Dictionary<int, string> adminChangeMenu = ShowAdminChangeMenu();

                int menuKey;
                (int, string) menuAction;

                // Run the main menu

                menuKey = GetUserChoice("change");
                menuAction = ValidateAdminChangeMenu(adminChangeMenu, menuKey);

                if (menuAction.Item2 == "Sair")
                {
                    break;
                }

                RunAdminChangeSubmenu(menuAction.Item2);

            } while (_adminService.KeepGoing());


            RunAdminMainMenu();

            /*
            // Show the RSGymPT logo
            ShowLogo("end", _currentUser);

            RunLoginMenu();
            */
        }

        // Method to run the order submenu
        public void RunAdminSubmenu(string menuAction)
        {
            switch (menuAction)
            {
                case "Registar":
                    do
                    {
                        user = _adminService.CreateUser();
                        if (user != null)
                        {
                            _adminRepository.AddUser(user);

                            RSGymUtility.WriteMessage("Utilizador criado com sucesso.", "\n", "\n");
                            RSGymUtility.PauseConsole();
                            RunMainMenu();
                        }
                        else
                        {
                            RSGymUtility.WriteMessage("Nenhum utilizador criado.", "\n", "\n");
                            RSGymUtility.PauseConsole();
                            RunMainMenu();
                        }
                    } while (_adminService.KeepGoing());
                    
                    break;
                case "Alterar":
                    user = _adminService.GetUserToChange();
                    if (user != null)
                    {
                        RunAdminChangeMenu();
                    }
                    else
                    {
                        RunAdminMainMenu();
                    }
                    break;

                /*
                case "Listar":
                    RunOrderSubmenuDelete();
                    _adminService.KeepGoing();
                    break;
                */
                case "Terminar":
                    ShowLogo("end");
                    break;
                
                    
            }
        }

        // Method to run the order submenu
        public void RunAdminChangeSubmenu(string menuAction)
        {
            _adminService.ChangeUser(user, menuAction);
        }
                   

        // Validate the main menu
        internal (int, string) ValidateAdminMainMenu(Dictionary<int, string> adminMainMenu, int menuKey)
        {
            foreach (KeyValuePair<int, string> menu in adminMainMenu)
            {
                if (menu.Key == menuKey)
                {
                    return (menu.Key, menu.Value);
                }
            }

            return (-1, string.Empty);
        }

        // Validate the change menu
        internal (int, string) ValidateAdminChangeMenu(Dictionary<int, string> adminChangeMenu, int menuKey)
        {
            foreach (KeyValuePair<int, string> menu in adminChangeMenu)
            {
                if (menu.Key == menuKey)
                {
                    return (menu.Key, menu.Value);
                }
            }

            return (-1, string.Empty);
        }

        public void RunLoginMenu()
        {
            // Show the login menu
            Dictionary<string, string> loginMenu = ShowLoginMenu();

            string loginAction;
            int loginKey;

            do
            {
                loginKey = GetUserChoice("login");
                loginAction = ValidateLoginMenu(loginMenu, loginKey);

                if (loginAction == "Sair")
                {
                    ShowLogo("end");
                    return;
                }

                if (loginAction == "Login")
                {
                    _currentUser = _userService.LogInUser();
                }

            } while (loginAction != "Sair" && _currentUser == null);

            if (_currentUser != null)
            {
                // Show the RSGymPT logo
                ShowLogo("begin");

                // Run the main menu
                RunMainMenu();
            }
            
        }

        // Get user menu number choice
        public int GetUserChoice(string chosenMenu)
        {
            int menuNumber;
            bool status;
            do
            {
                Console.Clear();

                ShowMenu(chosenMenu);

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
        public void ShowMenu(string menu)
        {
            if (menu == "login")
            {
                ShowLoginMenu();
            }
            else if (menu == "main")
            {
                ShowAdminMainMenu();
            }
            else if (menu == "change")
            {
                ShowAdminChangeMenu();
            }
        }

        // Function to show and return the main menu
        public Dictionary<int, string> ShowAdminMainMenu()
        {
            Console.Clear();

            RSGymUtility.WriteTitle($"RSGymPT Menu de navegação", "", "\n\n");
            RSGymUtility.WriteMessage("Digite o número da \nopção desejada e aperte 'Enter'", "", "\n\n");

            Dictionary<int, string> mainMenu = new Dictionary<int, string>()
            {   
                {1, "Registar" },
                {2, "Alterar" },
                {3, "Pesquisar" },
                {4, "Listar" },
                {5, "Terminar" }
            };

            foreach (KeyValuePair<int, string> menu in mainMenu)
            {
                RSGymUtility.WriteMessage($"({menu.Key}) - {menu.Value}", "", "\n");
            }
            
            return mainMenu;
        }

        public Dictionary<int, string> ShowAdminChangeMenu()
        {
            Console.Clear();

            RSGymUtility.WriteTitle($"RSGymPT Menu de alteração", "", "\n\n");
            RSGymUtility.WriteMessage("Digite o número da opção \ndesejada e aperte 'Enter'", "", "\n\n");

            Dictionary<int, string> changeMenu = new Dictionary<int, string>()
            {
                {1, "Email" },
                {2, "Username" },
                {3, "Password" },
                {4, "Perfil" },
                {5, "Sair" }
            };

            foreach (KeyValuePair<int, string> menu in changeMenu)
            {
                RSGymUtility.WriteMessage($"({menu.Key}) - {menu.Value}", "", "\n");
            }

            return changeMenu;
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
        public void ShowLogo(string status)
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
            UpdateScreenUserType();
            ShowLogoMessage(status, currentUser);

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string UpdateScreenUserType()
        {
            if (_currentUser == null)
            {
                return currentUser = "Convidado";
            }
            else
            {
                return currentUser = _currentUser.UserType.ToString(); 
            }
            
        }

        // Function to show and return the login menu
        public Dictionary<string, string> ShowLoginMenu()
        {
            Console.Clear();

            RSGymUtility.WriteTitle("RSGymPT Login Menu", "", "\n\n");
            RSGymUtility.WriteMessage($"Digite o número da opção desejada e aperte 'Enter'", "", "\n\n");

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
            string message01 = $"Bem vindo(a)! {userName}!";
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
