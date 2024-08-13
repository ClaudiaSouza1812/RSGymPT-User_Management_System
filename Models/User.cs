using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Enums;
using CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS11_OOP_P2_2_M02_ClaudiaSouza.Models
{
    public class User : IUser
    {
        #region Scalar Properties

        public static int NextId = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NIF { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual EnumUserType UserType { get; set; }

        #endregion

        internal virtual string FullUser => $"(Id): {Id}\n(Nome): {Name}\n(Nome de utilizador): {Username}\n(Usuário): {UserType}";

        public User() 
        {
            Id = NextId++;
            Name = string.Empty;
            LastName = string.Empty;
            NIF = string.Empty;
            Email = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            UserType = EnumUserType.SimpleUser;
        }

        public User(string name, string lastName, string nif, string email, string userName, string password, EnumUserType userType) : this()
        {
            Name = name;
            LastName = lastName;
            NIF = nif;
            Email = email;
            Username = userName;
            Password = password;
            UserType = userType;
        }

    }
}
