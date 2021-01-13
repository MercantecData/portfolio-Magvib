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
    }
}
