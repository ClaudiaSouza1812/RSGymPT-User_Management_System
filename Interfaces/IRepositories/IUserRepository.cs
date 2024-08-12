using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IRepositories
{
    internal interface IUserRepository
    {
        #region Methods and Functions

        bool CheckUserName(string userName);
        List<User> GetAllUsers();
        

        #endregion
    }
}
