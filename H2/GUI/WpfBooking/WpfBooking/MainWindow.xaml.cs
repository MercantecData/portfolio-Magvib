using System;
using System.Collections.Generic;
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
using WpfBooking.ServiceReference1;

namespace WpfBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BookingItem> bookings;
        List<Image> images = new List<Image>();
        Service1Client sc = new Service1Client();

        public MainWindow()
        {
            InitializeComponent();
            images.Add(image1);
            images.Add(image2);
            images.Add(image3);
            images.Add(image4);
            images.Add(image5);
            images.Add(image6);
            images.Add(image7);
            images.Add(image8);
            images.Add(image9);
            images.Add(image10);
            images.Add(image11);
            images.Add(image12);

            sc.CreateBookingNumber(1711, 12);
            bookings = sc.GetBookingItems(1711).ToList();

            int counter = 0;
            foreach (Image i in images)
            {
                if(bookings[counter].State == 1)
                {
                    i.Source = new BitmapImage(new Uri(@"images/SeatClose.png", UriKind.RelativeOrAbsolute));
                } else
                {
                    i.Source = new BitmapImage(new Uri(@"images/SeatOpen.png", UriKind.RelativeOrAbsolute));
                }

                counter++;
            }
        }

        private void Image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 0;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);               
        }

        private void Image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 1;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 2;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 3;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 4;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 5;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 6;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 7;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image9_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 8;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 9;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image11_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 10;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }

        private void Image12_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int pos = 11;
            Image img = (Image)sender;
            changeTilstandAndImage(pos, img);
        }
        private void changeTilstandAndImage(int pos, Image img)
        {            
            if (bookings[pos].State == 0)
            {
                img.Source = new BitmapImage(new Uri(@"images/SeatClose.png", UriKind.RelativeOrAbsolute));
                bookings[pos].State = 1;
            }
            else if (bookings[pos].State == 1)
            {
                img.Source = new BitmapImage(new Uri(@"images/SeatOpen.png", UriKind.RelativeOrAbsolute));
                bookings[pos].State = 0;
            }

            sc.SetBookingItems(1711, bookings.ToArray());
            bookings = sc.GetBookingItems(1711).ToList();
        }
    }
}
