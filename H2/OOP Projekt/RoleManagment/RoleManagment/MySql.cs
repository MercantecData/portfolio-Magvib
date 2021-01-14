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
        public int id = 0;
        private string db_host = "os.ht";
        private int db_port = 3306;
        private string db_name = "dev";
        private string db_user = "test";
        private string db_pass = "8e607a4752fa2e59413e5790536f2b42";

        MySqlConnection con;

        public MySql(string db_table = "", string search_query = "", string search_data = "")
        {
            this.db_table = db_table;

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
                var sql = this.get("SELECT id, "+ keys + " FROM "+ this.db_table + " WHERE " + search_query + " = '" + search_data + "' LIMIT 1");

                while (sql.Read())
                {
                    this.id = sql.GetInt32(0);

                    int count = 1;
                    foreach (PropertyInfo prop in this.GetType().GetProperties())
                    {
                        try // Bool
                        {
                            prop.SetValue(this, Convert.ToBoolean(sql.GetInt32(count)));
                        } catch
                        {
                            try // Int
                            {
                                prop.SetValue(this, sql.GetInt32(count));
                            } catch
                            {
                                try // String
                                {
                                    prop.SetValue(this, sql.GetString(count));
                                } catch
                                {
                                    try // Class object
                                    {
                                        prop.SetValue(this, Activator.CreateInstance(prop.PropertyType, sql.GetInt32(count)));
                                    } catch
                                    {
                                        try // Empty class object
                                        {
                                            prop.SetValue(this, Activator.CreateInstance(prop.PropertyType));
                                        } catch { }
                                    }
                                }
                            }
                        }
                        count++;
                    }

                }
                sql.Close();
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
                        throw new Exception("Failed to save");
                    }
                }
                else
                {
                    try
                    {
                        this.set("INSERT INTO " + this.db_table + "(" + keys + ") VALUES ("+ values +")");
                        this.id = this.getLastId();
                    }
                    catch (Exception)
                    {
                        throw new Exception("Failed to insert");
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
                    throw new Exception("Failed to delete");
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
                    if (!prop.Name.Substring(0, 3).Contains("db_") && !prop.Name.Substring(0, 2).Contains("x_") && prop.Name != "id")
                    {
                        if(prop.PropertyType.ToString() == "System.Boolean")
                        {
                            ObjData.Add(prop.Name, (bool)prop.GetValue(this) ? "1" : "0");
                        } else
                        {
                            ObjData.Add(prop.Name, (string)prop.GetValue(this));
                        }
                    }                    
                }
                catch
                {
                    try
                    {
                        MySql obj = (MySql)prop.GetValue(this);
                        ObjData.Add(prop.Name, obj.id.ToString());
                    }
                    catch 
                    {
                        try
                        {
                            ObjData.Add(prop.Name, prop.GetValue(this).ToString());
                        }
                        catch { }
                    }
                }
            }

            return ObjData;
        }
    }
}
