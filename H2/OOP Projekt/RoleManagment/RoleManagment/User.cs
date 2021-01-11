using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RoleManagment
{
    public class User : MySql
    {
        public string username { get; set; }
        public string password { get; private set; }
        public Role role { get; private set; }

        public User(int id = 0) : base()
        {
            try
            {
                var user = this.get("SELECT * FROM user WHERE id = " + (int)id + " LIMIT 1");

                while (user.Read())
                {
                    this.id = user.GetInt32(0);
                    this.username = user.GetString(1);
                    this.password= user.GetString(2);
                    this.role = new Role(user.GetInt32(3));

                }
                user.Close();
            } catch (Exception)
            {
            }

            if(this.id == 0)
            {
                this.id = 0;
                this.role = new Role(0);
            }
        }

        public User(string username) : base()
        {
            try
            {
                var user = this.get("SELECT * FROM user WHERE username = '" + username + "' LIMIT 1");

                while (user.Read())
                {
                    this.id = user.GetInt32(0);
                    this.username = user.GetString(1);
                    this.password = user.GetString(2);
                    this.role = new Role(user.GetInt32(3));
                }
                user.Close();
            }
            catch (Exception)
            {
            }

            if (this.id == 0)
            {
                this.id = 0;
                this.role = new Role(0);
            }
        }

        public override void save()
        {
            if(this.id != 0)
            {
                try
                {
                    this.set("UPDATE user SET username = '"+this.username+"', password = '"+this.password+"', role = " + this.role.id +" WHERE id = " + this.id + "");
                } catch (Exception)
                {
                    throw new Exception("Failed to save user");
                }
            } else
            {
                try
                {
                    this.set("INSERT INTO user(username, password, role) VALUES ('"+this.username+"', '" + this.password + "', " + this.role.id + ")");
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

        public bool checkPassword(string pass)
        {

            if (this.password == this.encryptPassword(pass))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public string encryptPassword(string pass, bool setPassword = false)
        {
            byte[] encodedPassword = new UTF8Encoding().GetBytes(pass);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

            if(setPassword)
            {
                this.password = encoded;
            }

            return encoded;
        }
    }
}
