using System;
using System.Collections.Generic;
using OOP2;
using Terminal.Gui;

namespace OOP2Test
{
    class Program
    {
		public static List<School> schools = new List<School>();

		static void Main(string[] args)
        {
			// Mercantec
            School mercantec = new School("Mercantec");

            mercantec.addTeacher(new Teacher("Mads", 30));
            mercantec.addTeacher(new Teacher("Jonas", 38));
            mercantec.addTeacher(new Teacher("Peter", 40));

			mercantec.addClass(new Class("Dansk", mercantec.findTeacherByName("Mads")));

            var dClass = mercantec.findClassByTitle("Dansk");

            dClass.changeTitle("Matematik");

            dClass.addStudent(new Student("Magnus", 19));
            dClass.addStudent(new Student("Michael", 23));

            dClass.setTeacher(mercantec.findTeacherByName("Jonas"));

            dClass.findStudentByName("Michael").changeName("Kasper");

			schools.Add(mercantec);

			// Overlund skole
			School oSkole = new School("Overlund SKole");

			oSkole.addTeacher(new Teacher("Peter", 40));

			oSkole.addClass(new Class("Dansk", oSkole.findTeacherByName("Peter")));
			var classDa = oSkole.findClassByTitle("Dansk");
			classDa.addStudent(new Student("Jesper", 19));
			classDa.addStudent(new Student("Oliver", 23));


			schools.Add(oSkole);

			// Gui 
			Application.Init();
            var top = Application.Top;
			top.Add(renderEditor());
			top.Add(renderList());
			top.Add(renderMenu());
			Application.Run();

		}

		public static List<string> listSchools()
        {
			List<string> schoolsName = new List<string>();

			foreach (School s in schools)
            {
				schoolsName.Add(s.name);
				foreach (Class c in s.classes)
                {
					schoolsName.Add("----------");
					schoolsName.Add("Class: " + c.title);
					schoolsName.Add("Teacher: " + c.mainTeacher.name);
					
					foreach (Student stu in c.students)
                    {
						schoolsName.Add("Student: " + stu.name);

					}
				}
				schoolsName.Add("");
			}

			return schoolsName;
        }

		public static MenuBar renderMenu()
        {
			var menu = new MenuBar(new MenuBarItem[] {
				new MenuBarItem ("_New", new MenuItem [] {
					new MenuItem ("_School", "", null),
				}),
				new MenuBarItem ("_Edit", new MenuItem [] {
					new MenuItem ("_School", "", null),
				})
			});

			return menu;
		}
		public static Window renderEditor()
		{
			var editor = new Window("Editor")
			{
				X = 40,
				Y = 1,
				Width = Dim.Fill(),
				Height = Dim.Fill()
			};

			var create = new Button(1, 1, "Create");

			create.Clicked += () =>
			{
				schools.Add(new School("waasd"));
			};

			editor.Add(
				create
			);

			return editor;
		}

		public static Window renderList()
        {
			var list = new Window("List")
			{
				X = 0,
				Y = 1,
				Width = 40,
				Height = Dim.Fill()
			};

			list.Add(
				new ListView(new Rect(1, 1, 20, 20), listSchools())
			); ;

			return list;
		}
	}
}
