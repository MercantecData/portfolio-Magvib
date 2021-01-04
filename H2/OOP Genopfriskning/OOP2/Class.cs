using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    public class Class
    {
        public string title { get; private set; }

        public Teacher mainTeacher { get; private set; }

        public List<Student> students { get; private set; }

        public Class(string title, Teacher teacher = null)
        {
            this.title = title;
            this.mainTeacher = teacher;
            this.students = new List<Student>();
        }

        public void changeTitle(string title)
        {
            this.title = title;
        }

        public void setTeacher(Teacher t)
        {
            this.mainTeacher = t;
        }

        public void addStudent(Student s)
        {
            this.students.Add(s);
        }

        public Student findStudentByName(string name)
        {
            foreach (Student s in this.students)
            {
                if (s.name == name)
                {
                    return s;
                }
            }

            return null;
        }

        public void listStudentNames()
        {

            foreach (Student s in this.students)
            {
                Console.WriteLine(s.name);
            }
        }
    }
}
