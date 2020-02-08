using BookYoPlanes.Models;
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
    public partial class NewBookingPage : ContentPage
    {
        public List<Plane> Planes { get; private set; }
        public string ImageFile { get; set; }
        RestService _restService;
        public NewBookingPage()
        {
            InitializeComponent();
            _restService = new RestService();
            BindingContext = this;
        }

        private void goBackButtonClicked(object sender, EventArgs e)
        {

            NavigationPage page = new NavigationPage(new MainPage());
            App.Current.MainPage = page;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = (Plane)picker.SelectedItem;
            planePreview.Source = selectedItem.ImageFile;
            seats.Text = selectedItem.Seats.ToString();
            luggage.Text = selectedItem.Luggage.ToString();
            golfbags.Text = selectedItem.GolfSets.ToString();
            skibags.Text = selectedItem.SkiSets.ToString();
            if (selectedItem.Pets == true)
            {
                pet.Text = "Y";
            }
            else
            {
                pet.Text = "N";
            }
            if (selectedItem.Wifi == true)
            {
                wifi.Text = "Y";
            }
            else
            {
                wifi.Text = "N";
            }
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await InitPicker();
        }

        private async Task InitPicker()
        {
            Planes = await _restService.GetPlanes(Constants.EndPoint + "Planes");
            planePicker.ItemsSource = Planes;
            return;
        }

        private async void submitBooking(object sender, EventArgs e)
        {
            var selectedItem = (Plane)planePicker.SelectedItem;
            var planeId = selectedItem.Id;
            var startDate = checkInDate.Date.ToString();
            var endDate = checkOutDate.Date.ToString();
            await _restService.Post(Constants.EndPoint + "Bookings/Add?planeId="+planeId+"&bookerId=Demo_User&startDate="+startDate+"&endDate="+endDate);
            NavigationPage page = new NavigationPage(new MyBookingsPage());
            App.Current.MainPage = page;
        }
    }
}