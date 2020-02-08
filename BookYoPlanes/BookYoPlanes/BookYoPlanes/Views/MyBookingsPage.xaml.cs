using BookYoPlanes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookYoPlanes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyBookingsPage : ContentPage
    {
        RestService _restService;
        public MyBookingsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            _restService = new RestService();
            base.OnAppearing();
            await InitTableView();
        }

        private async Task InitTableView()
        {
            var Bookings = await _restService.GetBookings(Constants.EndPoint + "Booking/ForUser?bookerId=Demo_User");
            bookingsListView.ItemsSource = Bookings;
            bookingsListView.EndRefresh();
            return;
        }

        private void goBackButtonClicked(object sender, EventArgs e)
        {

            NavigationPage page = new NavigationPage(new MainPage());
            App.Current.MainPage = page;
        }
    }
}