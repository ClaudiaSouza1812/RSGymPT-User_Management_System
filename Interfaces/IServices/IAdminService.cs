using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using System.Collections.Generic;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IServices
{
    public interface IAdminService 
    {
        User CreateUser();
        string DefineFirstName(string menu);
        string DefineLastName(string menu);
        string AskUserName(string menu);
        string AskUserLastName(string menu);
        bool CheckName(string name);
        string DefineNif();
        (bool, User) CheckNif(string nif);
        string DefineEmail();
        bool CheckEmail(string email);
        string DefineUsername();
        bool CheckUsername(string userName);
        string DefinePassword();
        bool CheckPassword(string password);
        EnumUserProfile DefineProfile();
        User GetUserToChange();
        int AskUserId(string menu);
        (bool, int) CheckInt(string id);
        void ChangeUser(User user, string property);
        void ChangeEmail(User user, string property);
        void ChangeUsername(User user, string property);
        void ChangePassword(User user, string property);
        void ChangeProfile(User user, string property);
        void ListUserById(User user);
        void ListUsers(List<User> users);
        void ListUserToChange(User user);
        void ListAllUsers();
        bool KeepGoing();
    }
}
