using System;
using System.Collections.Generic;
using System.Text;

namespace RoleManagment
{
    public class Role : MySql
    {
        public string role { get; private set; }
        public string prefix { get; private set; }

        public Role(int id = 0) : base()
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

        public Role(string name = "") : base()
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

        public override void save()
        {
            if (this.id != 0)
            {
                try
                {
                    this.set("UPDATE role SET role = '" + this.role + "', prefix = '" + this.prefix + "' WHERE id = " + this.id + "");
                }
                catch (Exception)
                {
                    throw new Exception("Failed to save user");
                }
            }
            else
            {
                try
                {
                    this.set("INSERT INTO user(role, prefix) VALUES ('" + this.role + "', '" + this.prefix + "')");
                    this.id = this.getLastId();
                }
                catch (Exception)
                {
                    throw new Exception("Failed to insert user");
                }
            }
        }

        public override void delete()
        {
            if (this.id != 0)
            {
                try
                {
                    this.set("DELETE FROM user WHERE id = '" + this.id + "'");
                }
                catch (Exception)
                {
                    throw new Exception("Failed to delete user");
                }
            }
        }
    }
}
