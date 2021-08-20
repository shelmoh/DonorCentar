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
    public class ObavijestiViewModel : BaseViewModel
    {
        public ObservableCollection<Obavijest> Obavijesti { get; set; } = new ObservableCollection<Obavijest>();
        public ICommand InfoCommand { get; }
       
    

       
       
        public ObavijestiViewModel()
        {
            InfoCommand = new Command<Obavijest>(OnInfoClicked);

            Obavijesti.Add(new Obavijest
            {
                Naslov= "Naslov 1"
                
            });
            Obavijesti.Add(new Obavijest
            {
                Naslov = "Naslov 2"

            });
        }

        private void OnInfoClicked(Obavijest obj)
        {
            
             

        }
    }
}
