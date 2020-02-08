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
    public partial class PlanesPage : ContentPage
    {
        RestService _restService;
        public PlanesPage()
        {
            InitializeComponent();
            _restService = new RestService();
            planesListView.BeginRefresh();
        }
        
        private void backButtonClicked(object sender, EventArgs e)
        {
            NavigationPage page = new NavigationPage(new MainPage());
            App.Current.MainPage = page;

        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await InitTableView();
        }

        private async Task InitTableView()
        {
            var Planes = await _restService.GetPlanes(Constants.EndPoint + "Planes");
            planesListView.ItemsSource = Planes;
            planesListView.EndRefresh();
            return;
        }
    }


}