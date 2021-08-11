using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; } = new List<string>();

        // o Modelo está anemico :(
    }
}
