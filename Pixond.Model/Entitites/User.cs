using System;
using System.Text.Json.Serialization;

namespace Pixond.Model.Entitites
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
