using DonorCentar.Mobile.Validators;
using DonorCentar.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DonorCentar.Mobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly APIService _servicekorisnici = new APIService("Korisnici");
        private readonly APIService _servicegradovi = new APIService("Gradovi");
        private readonly APIService _servicetipkorisnika = new APIService("TipKorisnika");

        private ValidatableObject<string> email = new ValidatableObject<string>();
        private ValidatableObject<string> korisnickoime = new ValidatableObject<string>();
        private ValidatableObject<string> password = new ValidatableObject<string>();
        private ValidatableObject<string> ime = new ValidatableObject<string>();
        private ValidatableObject<string> prezime = new ValidatableObject<string>();

        private ValidatableObject<string> adresa = new ValidatableObject<string>();
        private ValidatableObject<string> brojtelefona = new ValidatableObject<string>();

        private Model.Grad odabranigrad;
        public ObservableCollection<Model.Grad> Gradovi { get; set; } = new ObservableCollection<Model.Grad>();

        private Model.TipKorisnika odabranitipkorisnika;
        public ObservableCollection<Model.TipKorisnika> TipoviKorisnika { get; set; } = new ObservableCollection<Model.TipKorisnika>();

        public ICommand LoginCommand => new Command(OnLogin);
        public ICommand RegisterCommand => new Command(OnRegister);


        public async Task Init()
        {
            var listgradovi = await _servicegradovi.Get<List<Model.Grad>>(null);
            foreach (var item in listgradovi)
            {
                Gradovi.Add(item);

            }

            var listtipkorisnika = await _servicetipkorisnika.Get<List<Model.TipKorisnika>>(null);
            foreach (var item in listtipkorisnika)
            {
                if(item.Tip!="Administrator")
                TipoviKorisnika.Add(item);

            }
        }

        private async void OnRegister()
        {
            Model.Requests.KorisniciInsertRequest request = new Model.Requests.KorisniciInsertRequest
            {
                
                GradId = odabranigrad.Id,
                
                LicniPodaci = new Model.LicniPodaci
                {
                    Adresa = adresa.Value,
                    BrojTelefona = brojtelefona.Value,
                    Email = email.Value,
                    Ime = ime.Value,
                    Prezime = prezime.Value


                },
                LoginPodaci = new Model.LoginPodaci
                {
                    Sifra = password.Value,
                    KorisnickoIme = korisnickoime.Value
                },
                TipKorisnikaId = odabranitipkorisnika.Id

            };

            var entity = await _servicekorisnici.Insert<Model.Korisnik> (request);

            if(entity!=null)
            {
                await Application.Current.MainPage.DisplayAlert("", "Registracija uspješna.", "OK");
                APIService.Username = korisnickoime.Value;
                APIService.Password = password.Value;
                APIService.Korisnik = entity;
                Application.Current.MainPage = new AppShell();
            }

        }

        private void OnLogin()
        {
            Application.Current.MainPage = new LoginPage();
        }


        #region properties
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
        public ValidatableObject<string> Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (this.email == value)
                {
                    return;
                }

                this.SetProperty(ref this.email, value);
            }
        }
        public ValidatableObject<string> Ime
        {
            get
            {
                return this.ime;
            }

            set
            {
                if (this.ime == value)
                {
                    return;
                }

                this.SetProperty(ref this.ime, value);
            }
        }
        public ValidatableObject<string> Prezime
        {
            get
            {
                return this.prezime;
            }

            set
            {
                if (this.prezime == value)
                {
                    return;
                }

                this.SetProperty(ref this.prezime, value);
            }
        }
        public ValidatableObject<string> Adresa
        {
            get
            {
                return this.adresa;
            }

            set
            {
                if (this.adresa == value)
                {
                    return;
                }

                this.SetProperty(ref this.adresa, value);
            }
        }
        public ValidatableObject<string> BrojTelefona
        {
            get
            {
                return this.brojtelefona;
            }

            set
            {
                if (this.brojtelefona == value)
                {
                    return;
                }

                this.SetProperty(ref this.brojtelefona, value);
            }
        }

        public Model.Grad OdabraniGrad
        {
            get
            {
                return this.odabranigrad;
            }

            set
            {
                if (this.odabranigrad == value)
                {
                    return;
                }

                this.SetProperty( ref this.odabranigrad ,value);
            }
        }
        public Model.TipKorisnika OdabraniTipKorisnika
        {
            get
            {
                return this.odabranitipkorisnika;
            }

            set
            {
                if (this.odabranitipkorisnika == value)
                {
                    return;
                }

                this.SetProperty(ref this.odabranitipkorisnika, value);
            }
        }

        public ValidatableObject<string> KorisnickoIme
        {
            get
            {
                return this.korisnickoime;
            }

            set
            {
                if (this.korisnickoime == value)
                {
                    return;
                }

                this.SetProperty(ref this.korisnickoime, value);
            }
        }
        #endregion 


        private void OnLoginClicked(object obj)
        {
            
            Application.Current.MainPage = new AppShell();

        }
    }
}
