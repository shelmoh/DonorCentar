using DonorCentar.Mobile.Validators;
using DonorCentar.Mobile.Views;
using DonorCentar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DonorCentar.Mobile.ViewModels
{
    public class PrimljeneDonacijeViewModel : BaseViewModel
    {
        public ObservableCollection<Donacija> Donacije { get; set; } = new ObservableCollection<Donacija>();
        public ICommand InfoCommand { get; }
       
       

       
       
        public PrimljeneDonacijeViewModel()
        {
            InfoCommand = new Command<Donacija>(OnInfoClicked);
            
            Donacije.Add(new Donacija
            {
                DonacijaId=1,
                TipDonacije = new TipDonacije { Tip = "Hrana" }
                
            });
            Donacije.Add(new Donacija
            {
                DonacijaId = 2,
                TipDonacije = new TipDonacije { Tip = "Lijekovi" }

            });
        }

        private void OnInfoClicked(Donacija obj)
        {
            

        }
    }
}
