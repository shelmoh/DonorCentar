using DonorCentar.Mobile.ViewModels;
using DonorCentar.Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DonorCentar.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        
        }

        private  void OnMenuItemClicked(object sender, EventArgs e)
        {
           
            Application.Current.MainPage = new LoginPage();
        }
    }
}
