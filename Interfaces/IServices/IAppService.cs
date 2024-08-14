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
        string ValidateLoginMenu(Dictionary<string, string> loginMenu, int key);

        void ShowLogo(string status);
        void ShowMenu(string menu);
        void ShowMainMenu();
        Dictionary<int, string> ShowAdminMainMenu();
        Dictionary<int, string> ShowPowerUserMainMenu();
        Dictionary<int, string> ShowSimpleUserMainMenu();
        void ShowLogoMessage(string status, string userName);

        void RunAdminMainMenu();
        void RunAdminSubmenu(string menuAction);
        void RunAdminChangeSubmenu(string menuAction);
        void RunAdminSearchMenu();
        void RunAdminSearchSubmenu(string menuAction);

        // main menus
        void RunMainMenu();
        /*
        void RunAdminMainMenu();
        void RunPowerUserMainMenu();
        void RunSimpleUserMainMenu();
        */
    }
}
