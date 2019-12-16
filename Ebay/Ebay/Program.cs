using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Ebay
{
    class User
    {
        public int id;
        public string name;
        private string password;

        public User(int id, string name, string password)
        {
            this.id = id;
            this.name = name;
            this.password = password;
        }
    }

    class Database
    {
        List<User> users = new List<User>();

        public void AddUser(int id, string name, string password)
        {
            users.Add(new User(id, name, password));
        }

        public void ListUsers()
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine("{0}. {1}", users[i].id, users[i].name);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Database test = new Database();
            // new MySqlCommand("UPDATE users SET name = 'Magnus' WHERE id = 1", con).ExecuteScalar();

            string cs = @"server=localhost;userid=root;password=toor;database=csharp";
            using var con = new MySqlConnection(cs);
            con.Open();

            string userString = "SELECT * FROM users";
            using var cmd = new MySqlCommand(userString, con);


            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                test.AddUser(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
            }
            test.ListUsers();

            Console.ReadLine();
        }
    }
}
