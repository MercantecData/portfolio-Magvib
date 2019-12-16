using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Ebay
{
    public class Database
    {
        List<User> users = new List<User>();

        public void AddUser(int id, string name, string password)
        {
            users.Add(new User(id, name, password));
        }

        public void ClearUsers()
        {
            users.Clear();
        }

        public void ListUsers()
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine("{0}. {1}", users[i].id, users[i].name);
            }
        }
    }
}
