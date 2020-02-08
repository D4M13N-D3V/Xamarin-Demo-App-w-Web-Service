using BookYoPlanes.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookYoPlanes
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void planesButtonClicked(object sender, EventArgs e)
        {
            NavigationPage page = new NavigationPage(new PlanesPage());
            App.Current.MainPage = page;
        }

        private void newBookingButtonClicked(object sender, EventArgs e)
        {
            NavigationPage page = new NavigationPage(new NewBookingPage());
            App.Current.MainPage = page;
        }

        private void contactButtonClicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("tel:13368820297"));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            NavigationPage page = new NavigationPage(new MyBookingsPage());
            App.Current.MainPage = page;
        }
    }
}
