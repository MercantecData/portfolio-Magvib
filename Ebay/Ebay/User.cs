﻿using System;
namespace Ebay
{
    public class User
    {
        public int id;
        public string name;
        private string password;

        public User(int id, string name, string password)
        {
            this.id = id;
            this.name = name;
            this.password = password;
        }
    }
}
