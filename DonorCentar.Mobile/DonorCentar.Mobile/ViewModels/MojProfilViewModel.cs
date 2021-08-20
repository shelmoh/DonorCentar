using DonorCentar.Mobile.Validators;
using DonorCentar.Mobile.Views;
using DonorCentar.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DonorCentar.Mobile.ViewModels
{
    public class MojProfilViewModel : BaseViewModel
    {
        
        private Korisnik korisnik;
        private ValidatableObject<string> password;

        public MojProfilViewModel()
        {
            Korisnik = new Korisnik
            {
                LoginPodaci= new LoginPodaci
                {
                    KorisnickoIme="username"
                },
                LicniPodaci = new LicniPodaci
                {
                    Adresa = "Adresa",
                    Email = "email@email.com",
                    BrojTelefona = "02345651",
                    Ime = "Ime",
                    Prezime = "Prezime"

                }
            };



        }

        public ValidatableObject<string> Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password == value)
                {
                    return;
                }

                this.SetProperty(ref this.password, value);
            }
        }
        public Korisnik Korisnik
        {
            get
            {
                return this.korisnik;
            }

            set
            {
                if (this.korisnik == value)
                {
                    return;
                }

                this.SetProperty(ref this.korisnik, value);
            }
        }

       

        private void OnLoginClicked(object obj)
        {
            
            

        }
    }
}
