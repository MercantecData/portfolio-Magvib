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
            try
            {
                var role = this.get("SELECT * FROM role WHERE id = " + (int)id + " LIMIT 1");

                while (role.Read())
                {
                    this.id = role.GetInt32(0);
                    this.role = role.GetString(1);
                    this.prefix = role.GetString(2);
                }
                role.Close();
            }
            catch (Exception)
            {
                this.id = 0;
            }
        }

        public Role(string name = "") : base("role", "role", name)
        {
            try
            {
                var role = this.get("SELECT * FROM role WHERE role = '" + name + "' LIMIT 1");

                while (role.Read())
                {
                    this.id = role.GetInt32(0);
                    this.role = role.GetString(1);
                    this.prefix = role.GetString(2);
                }
                role.Close();
            }
            catch (Exception)
            {
                this.id = 0;
            }
        }
    }
}
