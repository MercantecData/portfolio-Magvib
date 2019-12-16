using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

// Execute Command
// new MySqlCommand("UPDATE users SET name = 'Magnus' WHERE id = 1", con).ExecuteScalar();

namespace Ebay
{
    class Program
    {
        static void Main(string[] args)
        {
            Database test = new Database();

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
