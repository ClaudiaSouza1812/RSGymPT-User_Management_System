using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IModels
{
    

    public interface IUser
    {
        #region Scalar Properties
        int Id { get; }
        string Name { get; }
        string LastName { get; }
        string NIF { get; }
        string Email { get; }
        string Username { get; }
        string Password { get; }
        EnumUserProfile UserProfile { get; }
        #endregion

    }
}
