using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace RoleManagment
{
    public abstract class MySql
    {
        public string db_table { get; set; }
        public int id { get; set; }
        public string db_host { get; private set; }
        public int db_port { get; private set; }
        public string db_name { get; private set; }
        public string db_user { get; private set; }
        public string db_pass { get; private set; }

        MySqlConnection con;

        public MySql(string db_table = "", string search_query = "", string search_data = "", int id = 0, string db_host = "os.ht", int db_port = 3306, string db_name = "dev", string db_user = "test", string db_pass = "8e607a4752fa2e59413e5790536f2b42")
        {
            this.db_table = db_table;
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

            Dictionary<string, string> ObjData = getProperties();

            string keys = String.Join(", ", ObjData.Keys);
            string values = "'";
            values += String.Join("', '", ObjData.Values);
            values += "'";

            List<string> sets = new List<string>();

            foreach (KeyValuePair<string, string> o in ObjData)
            {
                if(o.Value == null)
                {
                    continue;
                }
                try
                {
                    sets.Add(o.Key + " = '" + o.Value.Replace("'", "") + "'");
                }
                catch (Exception) { }
            }

            if(this.db_table != "" && search_query != "" && search_data != "")
            {
                var user = this.get("SELECT id, "+ keys + " FROM "+ this.db_table + " WHERE " + search_query + " = '" + search_data + "' LIMIT 1");

                while (user.Read())
                {
                    this.id = user.GetInt32(0);

                    int count = 1;
                    foreach (PropertyInfo prop in this.GetType().GetProperties())
                    {
                        try
                        {
                            prop.SetValue(this, user.GetInt32(count));
                        } catch (Exception)
                        {
                            try
                            {
                                prop.SetValue(this, user.GetString(count));
                            } catch (Exception)
                            {
                                try
                                {
                                    prop.SetValue(this, Activator.CreateInstance(prop.PropertyType, user.GetInt32(count)));
                                } catch (Exception) { }
                            }
                        }
                        count++;
                    }

                }
                user.Close();
            }

        }

        // Saves all information to the database
        public virtual void save()
        {
            Dictionary<string, string> ObjData = getProperties();

            string keys = String.Join(", ", ObjData.Keys);

            string values = "'";
            values += String.Join("', '", ObjData.Values); // make a check if empty
            values += "'";
            values = values.Replace("''", "'0'");

            List<string> sets = new List<string>();

            foreach (KeyValuePair<string, string> o in ObjData)
            {
                if (o.Value == null) { continue; }
                try
                {
                    sets.Add(o.Key + " = '" + o.Value.Replace("'", "") + "'");
                } catch (Exception) { }
            }

            if (this.db_table != "")
            {
                if (this.id != 0)
                {
                    try
                    {
                        this.set("UPDATE " + this.db_table + " SET "+ String.Join(", ", sets) + " WHERE id = " + this.id + "");
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
                        this.set("INSERT INTO user("+ keys + ") VALUES ("+ values +")");
                        this.id = this.getLastId();
                    }
                    catch (Exception)
                    {
                        throw new Exception("Failed to insert user");
                    }
                }
            }
        }

        // Deletes the instance in the database
        public virtual void delete()
        {
            if (this.id != 0 && this.db_table != "")
            {
                try
                {
                    this.set("DELETE FROM "+this.db_table+" WHERE id = '" + this.id + "'");
                }
                catch (Exception)
                {
                    throw new Exception("Failed to delete user");
                }
            }
        }

        // Gets the last id that was inserted into the database
        public int getLastId()
        {
            var id = this.get("SELECT LAST_INSERT_ID();");
            while (id.Read())
            {
                return (int)id.GetInt32(0);
            }

            return 0;
        }

        // Function to get sql querys like SELECT
        public MySqlDataReader get(string sql)
        {
            MySqlDataReader rdr = new MySqlCommand(sql, this.con).ExecuteReader();

            return rdr;
        }

        // Function like the get function but with no return for UPDATE and DELETE
        public void set(string sql)
        {
            new MySqlCommand(sql, this.con).ExecuteScalar();
        }

        // Gets the propperties for a class.
        public Dictionary<string, string> getProperties()
        {
            Dictionary<string, string> ObjData = new Dictionary<string, string>();

            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                try
                {

                    if (!prop.Name.Contains("db_") && !prop.Name.Contains("x_") && !prop.Name.Contains("id"))
                    {
                        ObjData.Add(prop.Name, (string)prop.GetValue(this));
                    }                    
                }
                catch (Exception)
                {
                    try
                    {
                        //PropertyInfo test = prop.GetValue(this);
                        //Console.WriteLine(prop.GetValue(this).GetType());
                        //ObjData.Add(prop.Name, (string)prop.GetValue(this));

                        //Object obj = Activator.CreateInstance(prop.PropertyType, prop.GetValue(this));
                        //MySql test = (MySql)obj;
                        //ObjData.Add(prop.Name, test.id.ToString());

                        //MySql obj = (MySql)Activator.CreateInstance(typeof(MySql), prop.GetValue(this));
                        //Console.WriteLine(obj.id.ToString());
                        //ObjData.Add(prop.Name, obj.id.ToString());

                        MySql obj = (MySql)prop.GetValue(this);
                        //Console.WriteLine(obj.id.ToString());
                        ObjData.Add(prop.Name, obj.id.ToString());
                    }
                    catch (Exception) { }
                }
            }

            return ObjData;
        }
    }
}
