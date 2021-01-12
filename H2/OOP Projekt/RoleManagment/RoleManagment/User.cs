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

        public User(int id = 0) : base("user", "id", id.ToString())
        {
        }

        public User(string username) : base("user", "username", username)
        {
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

        public static List<User> getAllUsers()
        {
            List<User> users = new List<User>();

            User u = new User();

            var usersData = u.get("SELECT id FROM user");

            while (usersData.Read())
            {
                users.Add(new User(usersData.GetInt32(0)));
            }
            usersData.Close();

            return users;
        }
    }
}
