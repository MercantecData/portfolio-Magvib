using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace REST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Person.Render(sp1, tName, tDesc, tUrl, tAge);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if(b.Name == "reload")
            {
                Person.Render(sp1, tName, tDesc, tUrl, tAge);
            }

            if(b.Name == "open_url")
            {
                Process.Start("chrome.exe", tUrl.Text);
            }

            if(b.Name == "add")
            {
                Person.Add(tName.Text, tDesc.Text, tUrl.Text, Int32.Parse(tAge.Text));
                tName.Text = "";
                tDesc.Text = "";
                tUrl.Text = "";
                tAge.Text = "";
                Person.Render(sp1, tName, tDesc, tUrl, tAge);
            }

            if(b.Name == "clear")
            {
                tName.Text = "";
                tDesc.Text = "";
                tUrl.Text = "";
                tAge.Text = "";
            }

            if (b.Name == "reset")
            {
                Person.Reset();
                Person.Render(sp1, tName, tDesc, tUrl, tAge);
            }
        }

        public class Person
        {
            public string Name;
            public int Age;
            public string Url;
            public string Description;

            // List
            private static string getListOfPersons = "http://restpublic.junoeuro.dk/service1.svc/getListOfPersons/";
            // Insert
            private static string insertToList = "http://restpublic.junoeuro.dk/service1.svc/AddPerson/name/desc/url/active/age";
            // Reset
            private static string resetList = "http://restpublic.junoeuro.dk/service1.svc/reset/";

            public Person(string name, int age, string url)
            {
                Name = name;
                Age = age;
                Url = url;
            }

            public static void Render(StackPanel sp1, TextBox tName, TextBox tDesc, TextBox tUrl, TextBox tAge)
            {
                sp1.Children.Clear();

                foreach (Person p in getPersons().Reverse())
                {
                    sp1.Children.Add(p.renderButton(p, tName, tDesc, tUrl, tAge));
                }

            }

            private Button renderButton(Person p, TextBox tName, TextBox tDesc, TextBox tUrl, TextBox tAge)
            {
                Button b = new Button();
                b.Content = p.Name;
                b.Tag = p;
                b.Click += (o, i) =>
                {
                    tName.Text = p.Name;
                    tDesc.Text = p.Description;
                    tUrl.Text = p.Url;
                    tAge.Text = p.Age.ToString();
                };

                return b;
            }

            private static Person[] getPersons()
            {
                var json = new WebClient().DownloadString(getListOfPersons);
                Person[] persons = JsonConvert.DeserializeObject<Person[]>(json);

                return persons;
            }

            public static void Add(string Name, string Description, string Url, int Age)
            {
                var url = insertToList.Replace("name", Name).Replace("desc", Description).Replace("url", Url).Replace("active", "true").Replace("age", Age.ToString());
                new WebClient().DownloadString(url);
            }

            public static void Reset()
            {
                new WebClient().DownloadString(resetList);
            }

        }
    }
}
