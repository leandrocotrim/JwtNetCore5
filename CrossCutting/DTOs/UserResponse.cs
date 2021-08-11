using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CrossCutting.DTOs
{
    public class UserResponse
    {
        public string Username { get; set; }

        [JsonIgnore]
        public List<string> Roles { get; set; } = new List<string>();
        public string Token { get; set; }
    }
}
