using DonorCentar.Mobile.Validators;
using DonorCentar.Mobile.Validators.Rules;
using DonorCentar.Mobile.Views;
using DonorCentar.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DonorCentar.Mobile.ViewModels
{
    public class MojProfilViewModel : BaseViewModel
    {

        private readonly APIService _servicekorisnici = new APIService("Korisnici");

        private ValidatableObject<string> email = new ValidatableObject<string>();
        private Korisnik korisnik;
        private ValidatableObject<string> password = new ValidatableObject<string>();
        private ValidatableObject<string> ime = new ValidatableObject<string>();
        private ValidatableObject<string> prezime = new ValidatableObject<string>();

        private ValidatableObject<string> adresa = new ValidatableObject<string>();
        private ValidatableObject<string> brojtelefona = new ValidatableObject<string>();

        public MojProfilViewModel()
        {
            SpremiCommand = new Command(async () => await OnSpremiClicked());
        }

        private async Task OnSpremiClicked()
        {
            var request = new Model.Requests.KorisniciUpdateRequest
            {
                GradId = korisnik.GradId,
                LicniPodaci = new LicniPodaci
                {
                    Adresa = Adresa.Value,
                    BrojTelefona = BrojTelefona.Value,
                    Email = Email.Value,
                    Ime = Ime.Value,
                    Prezime = Prezime.Value,
                    ProfilnaSlika = korisnik.LicniPodaci.ProfilnaSlika
                },
                LoginPodaci = new LoginPodaci
                {
                    Sifra = Password.Value,
                    KorisnickoIme = korisnik.LoginPodaci.KorisnickoIme
                },
                TipKorisnikaId = korisnik.TipKorisnikaId
            };

             var entity = await _servicekorisnici.Update<Korisnik>(korisnik.Id, request);
            if(entity!=null)
            {
                await Application.Current.MainPage.DisplayAlert("Poruka", "Izmjena je uspješno sačuvana.", "OK");
                if (!string.IsNullOrEmpty(Password.Value))
                    APIService.Password = password.Value;
                APIService.Korisnik = entity;
            }

            
        }

        public ICommand SpremiCommand { get; }


        public async Task Init()
        {
            await UcitajKorisnika();
            AddValidationRules();


        }




        private async Task UcitajKorisnika()
        {
            var k= await _servicekorisnici.Get<Korisnik>(null,"Profil");
            korisnik = k;

            Email = new ValidatableObject<string> { Value = k.Email };
            Password = new ValidatableObject<string> { Value = "" };
            Adresa = new ValidatableObject<string> { Value = k.LicniPodaci.Adresa };
            Ime = new ValidatableObject<string> { Value = k.Ime };
            Prezime = new ValidatableObject<string> { Value = k.Prezime };
            BrojTelefona = new ValidatableObject<string> { Value = k.LicniPodaci.BrojTelefona };








        }




        public bool AreFieldsValid()
        {
            bool isEmailValid = this.Email.Validate();
            
            bool isAdresaValid = this.Adresa.Validate();
            bool isBrojValid = this.BrojTelefona.Validate();
            bool isImeValid = this.Ime.Validate();

            

            return isEmailValid  && isAdresaValid && isBrojValid && isImeValid;
        }




        private void AddValidationRules()
        {
         
            this.Adresa.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Adresa potrebna" });
            this.Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email potreban" });
            this.BrojTelefona.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Broj telefona potreban" });
            this.Ime.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Ime potrebno" });
          

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

        

     

        #endregion
    }

}
