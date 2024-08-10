using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces.IServices
{
    public interface IUserService
    {
        #region Methods and Functions

        User CreateUser(User user);
        string AskUserName();
        string AskUserPassword();
        User ValidateUser(string userName, string password);
        User LogInUser(string userName, string password);
        List<User> CreateDefaultUsers();

        #endregion



        


    }
}
