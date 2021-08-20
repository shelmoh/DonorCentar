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
    public class PrimaociViewModel : BaseViewModel
    {
        public ObservableCollection<Primalac> Primaoci { get; set; } = new ObservableCollection<Primalac>();
        public ICommand InfoCommand { get; }
       
   

     
       
        public PrimaociViewModel()
        {
            InfoCommand = new Command<Primalac>(OnInfoClicked);
            
            Primaoci.Add(new Primalac
            {
                Verifikovan=true,
               Korisnik= new Korisnik
               {
                    LicniPodaci= new LicniPodaci
                    {
                        Ime="Naziv primaoca 1"

                    }
               }
              
                
            });
            Primaoci.Add(new Primalac
            {
                Verifikovan = true,
                Korisnik = new Korisnik
                {
                    LicniPodaci = new LicniPodaci
                    {
                        Ime = "Naziv primaoca 2"
                    }
                }

            });
        }

        private void OnInfoClicked(Primalac obj)
        {
            

        }
    }
}
