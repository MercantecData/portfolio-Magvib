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
using ArrayOfStrings.ServiceReference2;

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

        public Website(string name, string url, string color = null)
        {
            this.name = name;
            this.url = url;
            this.color = color;
        }

        public static void RenderList(StackPanel sp, TextBox t1)
        {
            sp.Children.Clear();

            Service1Client soapObj = new Service1Client();

            Hjemmeside[] hArr = soapObj.getHjemmesider();

            foreach (Hjemmeside h in hArr)
            {
                sp.Children.Add(new Website(h.Navn, h.Url).getButton(t1));
            }
        }

        public Button getButton(TextBox t1)
        {
            // New button object
            Button b = new Button();

            // Button name
            b.Content = this.name;

            // Button color
            if(this.color != null)
            {
                b.Background = new BrushConverter().ConvertFromString(this.color) as Brush;
            }

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

            Website.RenderList(sp, t1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Service1Client soapObj = new Service1Client();

            if (b.Name == "b1")
            {
                // Opens Url from textbox in google chrome
                Process.Start("chrome.exe", t1.Text);
            }

            if(b.Name == "BSave")
            {
                // Adds new bookmark to api
                Hjemmeside h = new Hjemmeside();

                h.Navn = BNavn.Text;
                h.Url = BUrl.Text;
                soapObj.addHjemmesider(h);

                MessageBox.Show("Done", "Added to bookmarks");
                Website.RenderList(sp, t1);
            }
        }
    }
}
