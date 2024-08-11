using ClassLibrary.Enums;
using ClassLibrary.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class User : IUser
    {
        #region Scalar Properties

        public int Id { get; private set; }
        public int NextId { get; private set; } = 1;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NIF { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual EnumUserType UserType { get; set; }

        #endregion

        internal virtual string FullUser => $"(Id): {Id}\n(Nome): {Name}\n(Nome de utilizador): {UserName}\n(Usuário): {UserType}";

        public User() 
        {
            Id = NextId++;
            Name = string.Empty;
            LastName = string.Empty;
            NIF = string.Empty;
            Email = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            UserType = EnumUserType.SimpleUser;
        }

        public User(string name, string lastName, string nif, string email, string userName, string password, EnumUserType userType) : this()
        {
            Name = name;
            LastName = lastName;
            NIF = nif;
            Email = email;
            UserName = userName;
            Password = password;
            UserType = userType;
        }

    }
}
