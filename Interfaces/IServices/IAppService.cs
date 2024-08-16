using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices
{
    internal interface IAppService
    {

        void RunRSGymProgram();
        void RunLoginMenu();
        Dictionary<string, string> ShowLoginMenu();
        int GetUserChoice(string chosenMenu);
        void ShowMenu(string menu);
        void ShowMenuByuserProfile();

        string ValidateLoginMenu(Dictionary<string, string> loginMenu, int key);
        void ShowLogo(string status);
        void ShowLogoMessage(string status);
        void RunMainMenu();
        void RunAdminMainMenu();
        (int, string) ValidateMenu(Dictionary<int, string> mainMenu, int menuKey);
        Dictionary<int, string> ShowAdminMainMenu();
        void RunAdminSubmenu(string menuAction);
        void RunCreateSubmenu();
        void RunChangeSubmenu();
        void RunSearchMenu();
        Dictionary<int, string> ShowSearchMenu();
        void RunSearchSubmenu(string menuAction);
        void SearchById();
        void SearchByName();
        void RunListSubmenu();

        void RunAdminChangeMenu(User user);
        Dictionary<int, string> ShowAdminChangeMenu(User user);
        void RunAdminChangeSubmenu(string menuAction, User user);
        void RunPowerUserMainMenu();
        Dictionary<int, string> ShowPowerUserMainMenu();
        void RunSimpleUserMainMenu();
        Dictionary<int, string> ShowSimpleUserMainMenu();
        
    }
}
