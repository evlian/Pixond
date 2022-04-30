using Pixond.Model.Entitites;
using System.Collections.Generic;

namespace Pixond.Model.General.Commands.Users.RegisterUser
{
    public class RegisterUserResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
        public Dictionary<string, List<string>> Errors = new();
    }
}
