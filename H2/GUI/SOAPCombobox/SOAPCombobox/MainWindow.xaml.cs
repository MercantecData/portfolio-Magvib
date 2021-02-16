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

    public partial class MainWindow : Window
    {
        public Dictionary<String, String> Arr = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();

            RenderList(cb);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Service1Client soapObj = new Service1Client();

            if (b.Name == "BOpen")
            {
                // Opens Url from textbox in google chrome
                Process.Start("chrome.exe", BUrl.Text);
            }

            if(b.Name == "BClear")
            {
                BNavn.Text = "";
                BUrl.Text = "";
                BDesc.Text = "";
            }

            if(b.Name == "BSave")
            {
                // Adds new bookmark to api
                Hjemmeside h = new Hjemmeside();

                h.Navn = BNavn.Text;
                h.Url = BUrl.Text;
                h.Beskrivelse = BDesc.Text;
                soapObj.addHjemmesider(h);

                RenderList(cb);
                BNavn.Text = "";
                BUrl.Text = "";
                BDesc.Text = "";
                MessageBox.Show("Done", "Added to bookmarks");
            }
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            Service1Client soapObj = new Service1Client();

            Hjemmeside[] hArr = soapObj.getHjemmesider();

            try
            {
                Hjemmeside h = hArr[cb.SelectedIndex];
                BNavn.Text = h.Navn;
                BUrl.Text = h.Url;
                BDesc.Text = h.Beskrivelse;
            } catch(Exception) { }
        }

        public void RenderList(ComboBox cb)
        {
            cb.Items.Clear();

            Service1Client soapObj = new Service1Client();

            Hjemmeside[] hArr = soapObj.getHjemmesider();

            foreach (Hjemmeside h in hArr)
            {
                cb.Items.Add(h.Navn);
            }
        }
    }
}
