using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Ebay
{
    class User
    {
        int id;
        string name;
        string password;

        public string GetName()
        {
            return name;
        }

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
            User user = new User(id, name, password);
            users.Add(new User(id, name, password));
        }

        public void ListUsers()
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine(users[i].GetName());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string cs = @"server=localhost;userid=root;password=toor;database=csharp";
            using var con = new MySqlConnection(cs);
            con.Open();

            string userString = "SELECT * FROM users";
            using var cmd = new MySqlCommand(userString, con);

            // new MySqlCommand("UPDATE users SET name = 'Magnus' WHERE id = 1", con).ExecuteScalar();
            Database test = new Database();


            using MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                test.AddUser(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2));
                // Console.WriteLine("{0}. {1}", rdr.GetInt32(0), rdr.GetString(1));
            }
            test.ListUsers();

            Console.ReadLine();
        }
    }
}
