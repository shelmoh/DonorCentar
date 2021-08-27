using DonorCentar.Mobile.ViewModels;
using DonorCentar.Mobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace DonorCentar.Mobile
{
    public partial class AppShellPartner : Xamarin.Forms.Shell
    {
        public AppShellPartner()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(InfoObavijestiPage), typeof(InfoObavijestiPage));




        }



        private  void OnMenuItemClicked(object sender, EventArgs e)
        {
           
            Application.Current.MainPage = new LoginPage();
        }
    }
}
