using System;
using System.Collections.Generic;
using System.Text;

namespace RoleManagment
{
    public class Role : MySql
    {
        public string role { get; set; }
        public string prefix { get; set; }

        public Role(int id = 0) : base("role", "id", id.ToString())
        {
        }

        public Role(string name = "") : base("role", "role", name)
        {
        }
    }
}
