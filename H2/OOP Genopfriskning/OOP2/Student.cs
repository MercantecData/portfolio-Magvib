using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    public class Student
    {
        public string name { get; private set; }

        public int age { get; private set; }

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void changeName(string name)
        {
            this.name = name;
        }
    }
}
