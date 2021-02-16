using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    public class School
    {
        public string name { get; private set; }

        public List<Teacher> teachers  { get; private set; }

        public List<OOP2.Class> classes { get; private set; }

        public School(string name)
        {
            this.name = name;
            this.teachers = new List<Teacher>();
            this.classes = new List<Class>();
        }

        public void addClass(Class c)
        {
            this.classes.Add(c);
        }

        public void addTeacher(Teacher t)
        {
            this.teachers.Add(t);
        }

        public Class findClassByTitle(string title)
        {
            foreach (Class c in this.classes)
            {
                if (c.title == title)
                {
                    return c;
                }
            }

            return null;
        }

        public void listClassTitles()
        {

            foreach (Class c in this.classes)
            {
                Console.WriteLine(c.title);
            }
        }

        public Teacher findTeacherByName(string name)
        {
            foreach (Teacher t in this.teachers)
            {
                if(t.name == name)
                {
                    return t;
                }
            }

            return null;
        }

        public void listTeacherNames()
        {

            foreach (Teacher t in this.teachers)
            {
                Console.WriteLine(t.name);
            }
        }

        public Student[] getListofStudents()
        {
            List<Student> sList = new List<Student>();
            
            foreach (Class c in this.classes)
            {
                foreach (Student s in c.students)
                {
                    sList.Add(s);
                }
            }

            return sList.ToArray();
        }

        public Teacher[] getListOfTeachers()
        {
            return this.teachers.ToArray();
        }
    }
}
