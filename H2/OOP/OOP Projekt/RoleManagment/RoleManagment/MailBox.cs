﻿using System;
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
            //this.updateMails();
        }

        public void updateMails()
        {
            if (this.id != 0)
            {
                this.x_allMails.Clear();
                var sql = this.get("SELECT id FROM mail WHERE inbox_from = " + this.id + " OR inbox_to = " + this.id);
                while (sql.Read())
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

            this.updateMails();

            foreach (Mail m in this.x_allMails)
            {
                if(m.inbox_from == this.id)
                {
                    inbox_from_count++;
                }

                if (m.inbox_to == this.id && m.seen == false)
                {
                    sent_count++;
                }
            }

            this.inbox = sent_count;
            this.sent = inbox_from_count;

            base.save();
        }

        public override void delete()
        {
            this.updateMails();

            foreach (Mail m in x_allMails)
            {
                m.delete();
            }

            base.delete();
        }
    }
}
