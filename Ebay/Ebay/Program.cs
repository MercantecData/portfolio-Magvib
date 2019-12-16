using System;
using MySql.Data.MySqlClient;

namespace Ebay
{
    class Users
    {
        int id;
        string name;
        string password;

        public Users(int id, string name, string password)
        {
            this.id = id;
            this.name = name;
            this.password = password;
        }
    }

    class Database
    {
        Users user;

        public Database(Users user)
        {
            this.user = user;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string cs = @"server=localhost;userid=root;password=toor;database=csharp";
            using var con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT id, name FROM users";
            using var cmd = new MySqlCommand(sql, con);

            // new MySqlCommand("UPDATE users SET name = 'Magnus' WHERE id = 1", con).ExecuteScalar();

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("{0}. {1}", rdr.GetInt32(0), rdr.GetString(1));
            }

            Console.ReadLine();
        }
    }
}
