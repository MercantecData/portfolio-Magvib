using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

namespace ArrayOfStrings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public class Website
    {
        public string name;
        public string url;
        public string color;

        public Website(string name, string url, string color)
        {
            this.name = name;
            this.url = url;
            this.color = color;
        }

        public Button getButton(TextBox t1)
        {
            // New button object
            Button b = new Button();

            // Button name
            b.Content = this.name;

            // Button color
            b.Background = new BrushConverter().ConvertFromString(this.color) as Brush;

            // Button action
            b.Click += (s, e) =>
            {
                // Sets testbox to the url
                t1.Text = this.url;
            };

            return b;
        }
    }

    public partial class MainWindow : Window
    {
        public Dictionary<String, String> Arr = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();

            // ----- Saves and gets the data in a file
            string data = "Danmarks Radio;www.dr.dk;#f7e76f;TV2;www.tv2.dk;#3daed1;YouTube;www.youtube.com;#b042db;CNN;www.cnn.com;#cf2183;NBC;www.nbc.com;#21cf4d";
            String[] dataArray = data.Split(';');
            
            System.IO.File.WriteAllLines(@"Data.txt", dataArray);
            dataArray = System.IO.File.ReadAllLines(@"Data.txt");

            // Sets all urls into objects
            List<Website> websites = new List<Website>();
            for (int i = 0; i < dataArray.Count(); i++)
            {
                Website w = new Website(dataArray[i], dataArray[i + 1], dataArray[i + 2]);
                
                websites.Add(w);
                sp.Children.Add(w.getButton(t1));

                i = i+2;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Opens Url from textbox in google chrome
            Process.Start("chrome.exe", t1.Text);
        }
    }
}
