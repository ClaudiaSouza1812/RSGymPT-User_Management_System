using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices
{
    public interface IAdminService
    {
        User CreateUser();
        void ChangeUser(User user, string property);
        void ListAllUsers();
        User GetUserToChange();
        int AskUserId(string menu);
        string AskUserName(string menu);
        string AskUserLastName(string menu);

        (string, string) DefineFullName(string menu);
        string DefineNif();
        string DefineEmail();
        string DefineUsername();
        string DefinePassword();
        EnumUserType DefineUserType();


        bool CheckName(string name);
        bool CheckEmail(string email);
        bool CheckUsername(string userName);
        bool CheckPassword(string password);
        (bool, int) CheckInt(string id);
        (bool, User) CheckNif(string nif);

        bool KeepGoing();
        void ListUserById(User user);
        void ListUsers(List<User> users);
        void ListUserToChange(User user);

    }
}
