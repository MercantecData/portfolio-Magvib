using System;
using System.Collections.Generic;
using System.Text;

namespace RoleManagment
{
    public class Mail : MySql
    {
        public int inbox_from { get; set; }
        public int inbox_to { get; set; }

        public string title { get; set; }

        public string message { get; set; }

        public bool seen { get; set; }

        public Mail(int id = 0) : base("mail", "id", id.ToString())
        {

        }

        public User from()
        {
            int id = 0;
            var sql = this.get("SELECT user.id FROM user LEFT JOIN mailbox ON mailbox.id = user.mailbox LEFT JOIN mail ON mail.inbox_from = mailbox.id WHERE mail.inbox_from = " + this.inbox_from + ";");
            while (sql.Read())
            {
                id = sql.GetInt32(0);
            }
            sql.Close();
            return new User(id);
        }
    }
}
