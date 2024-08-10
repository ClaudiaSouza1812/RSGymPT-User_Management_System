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

        public int Id { get; }
        private static  int NextId { get; set; } = 1;
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public EnumUserType UserType { get; set; }

        #endregion

        internal string FullUser => $"(Id): {Id}\n(Nome): {Name}\n(Nome de utilizador): {UserName}\n(Tipo de Usuário): {UserType}";

        public User() 
        {
            Id = NextId++;
            Name = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            UserType = EnumUserType.SimpleUser;
        }

        public User(string name, string userName, string password, EnumUserType userType) : base()
        {
            Name = name;
            UserName = userName;
            Password = password;
            UserType = userType;
        }

    }
}
