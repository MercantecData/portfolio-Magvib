using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    public class Teacher
    {
        public string name { get; private set; }

        public int age { get; private set; }

        public List<string> subjects { get; private set; }

        public Teacher(string name, int age)
        {
            this.name = name;
            this.age = age;
            this.subjects = new List<string>();
        }

        public void changeName(string name)
        {
            this.name = name;
        }
    }
}
