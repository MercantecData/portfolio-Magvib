using System;
using System.Collections.Generic;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace RoleManagment
{
    public abstract class MySql
    {
        public int id { get; set; }
        
        public string db_host { get; private set; }
        public int db_port { get; private set; }
        public string db_name { get; private set; }

        public string db_user { get; private set; }
        public string db_pass { get; private set; }

        MySqlConnection con;

        public MySql(int id = 0, string db_host = "os.ht", int db_port = 3306, string db_name = "dev", string db_user = "test", string db_pass = "8e607a4752fa2e59413e5790536f2b42")
        {
            this.id = id;
            this.db_host = db_host;
            this.db_port = db_port;
            this.db_name = db_name;
            this.db_user = db_user;
            this.db_pass = db_pass;

            string cs = "server=" + this.db_host + ";user=" + this.db_user + ";database=" + this.db_name + ";port=" + this.db_port + ";password=" + this.db_pass;

            try {
                this.con = new MySqlConnection(cs);
                this.con.Open();
            } catch (Exception)
            {
                Console.WriteLine("Can't connect to db");
            }
        }

        public abstract void save();

        public abstract void delete();

        public int getLastId()
        {
            var id = this.get("SELECT LAST_INSERT_ID();");
            while (id.Read())
            {
                return (int)id.GetInt32(0);
            }

            return 0;
        }

        public MySqlDataReader get(string sql)
        {
            MySqlDataReader rdr = new MySqlCommand(sql, this.con).ExecuteReader();

            return rdr;
        }

        public void set(string sql)
        {
            new MySqlCommand(sql, this.con).ExecuteScalar();
        }
    }
}
