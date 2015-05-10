using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CodeTalk.WindowsPhone.Resources;
using CodeTalk.WindowsPhone.ViewModel;
using Microsoft.Phone.Maps.Toolkit;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;

namespace CodeTalk.WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();


            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            var viewModel = new CarViewModel();
            await viewModel.InitializeData();
            this.DataContext = viewModel;


            MapLayer layer = new MapLayer();
            var pts = new List<GeoCoordinate>();
            foreach (var item in viewModel.Cars)
            {
                Pushpin pushpin = new Pushpin();
                pushpin.GeoCoordinate = new System.Device.Location.GeoCoordinate(item.latitude, item.longitude);


                MapOverlay overlay = new MapOverlay();
                overlay.Content = pushpin;
                overlay.GeoCoordinate = new System.Device.Location.GeoCoordinate(item.latitude, item.longitude);
                layer.Add(overlay);

                pts.Add(new System.Device.Location.GeoCoordinate(item.latitude, item.longitude));
            }

            map.Layers.Clear();
            map.Layers.Add(layer);

            map.SetView(LocationRectangle.CreateBoundingRectangle(pts));

            base.OnNavigatedTo(e);
        }

        private void MapPivotItem_Loaded(object sender, RoutedEventArgs e)
        {

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}