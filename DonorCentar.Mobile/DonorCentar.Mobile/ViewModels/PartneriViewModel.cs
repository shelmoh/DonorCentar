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
    public class PartneriViewModel : BaseViewModel
    {
        public ObservableCollection<Partner> Partneri { get; set; } = new ObservableCollection<Partner>();
        public ICommand InfoCommand { get; }
       
   

     
       
        public PartneriViewModel()
        {
            InfoCommand = new Command<Partner>(OnInfoClicked);
            
            Partneri.Add(new Partner
            {
               
               Korisnik= new Korisnik
               {
                   Grad= new Grad
                   {
                       Naziv="Mostar"
                   },
                    LicniPodaci= new LicniPodaci
                    {
                        Ime="Naziv part 1"

                    }
               }
              
                
            });
            Partneri.Add(new Partner
            {
                
                Korisnik = new Korisnik
                {
                    Grad = new Grad
                    {
                        Naziv = "Tuzla"
                    },
                    LicniPodaci = new LicniPodaci
                    {
                        Ime = "Naziv part 2"
                    }
                }

            });
        }

        private void OnInfoClicked(Partner obj)
        {
            

        }
    }
}
