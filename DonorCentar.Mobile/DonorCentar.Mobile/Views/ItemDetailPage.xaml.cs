using DonorCentar.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DonorCentar.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}