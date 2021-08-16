using DonorCentar.Mobile.Validators;
using DonorCentar.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DonorCentar.Mobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        
        private ValidatableObject<string> email;
        private ValidatableObject<string> password;
        public ICommand LoginCommand => new Command(OnLogin);

        private void OnLogin()
        {
            Application.Current.MainPage = new LoginPage();
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

       

        private void OnLoginClicked(object obj)
        {
            
            Application.Current.MainPage = new AppShell();

        }
    }
}
