using System;
using System.Collections.Generic;
using System.Text;

namespace RoleManagment
{
    public class MailBox : MySql
    {
        //public User user { get; set; }
        public int inbox { get; set; }
        public int sent { get; set; }
        public MailBox(int id = 0) : base("mailbox", "id", id.ToString())
        {

        }
    }
}
