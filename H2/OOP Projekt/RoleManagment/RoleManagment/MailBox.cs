using System;
using System.Collections.Generic;
using System.Text;

namespace RoleManagment
{
    public class MailBox : MySql
    {
        public int inbox { get; set; }
        public int sent { get; set; }
        public List<Mail> x_allMails { get; set; }

        public MailBox(int id = 0) : base("mailbox", "id", id.ToString())
        {
            this.x_allMails = new List<Mail>();

            if(this.id != 0)
            {
                var sql = this.get("SELECT id FROM mail WHERE inbox_from = " + this.id + " OR inbox_to = " + this.id);
                while(sql.Read())
                {
                    this.x_allMails.Add(new Mail(sql.GetInt32(0)));
                }
                sql.Close();
            }
        }

        public override void save()
        {

            int inbox_from_count = 0;
            int sent_count = 0;

            foreach (Mail m in x_allMails)
            {

            }

            base.save();
        }
    }
}
