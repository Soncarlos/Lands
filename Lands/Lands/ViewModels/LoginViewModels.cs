
namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    // clase de tipo Interfaz para notificar cambios, actualizacion de componentes.
    public class LoginViewModels : INotifyPropertyChanged
    {
        //Implementaciop de la interfaz por medion de un Evento
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region attributes
        private string password;
        private bool isRunnig;
        private bool isEnabled;
        #endregion


        #region Properties
        public string Email { get; set; }
        public string Password
        {
            get
            {
                return password;
            }
                
            set
            {
            if (password != value)
               password = value;
            //Invoca al delegado Del evento PropertyChanged, refresca,
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
                
             }
        }

        public bool IsRunnig
        {
            // abreviacion  get => isRunnig;
            get
            {
                return isRunnig;
            }

            set
            {
                if (isRunnig != value)
                    isRunnig = value;
                //Invoca al delegado Del evento PropertyChanged, refresca,
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRunnig)));

            }
        }

        public bool IsRemenbered { get; set; }

        public bool IsEnabled

        {
            get
            {
                return isEnabled;
            }

            set
            {
                if (isEnabled != value)
                    isEnabled = value;
                //Invoca al delegado Del evento PropertyChanged, refresca,
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEnabled)));

            }
        }
        #endregion

        #region costructors
        public LoginViewModels()
        {
            IsRemenbered = true;
            IsEnabled = true;

        }
        #endregion

        #region Commands

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }


        // metodo Asincrono
        private async void Login()
        {
            // condicion: si el campo de Email esta vacio y se presiona el boton Login
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                    "You must enter an Email",
                    "Accept");
                         
                return;
            }

            // condicion: si el campo de Password esta vacio y se presiona el boton Login
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert
                  ("Error",
                   "You must enter a Password",
                   "Accept");
                return;
            }

            IsRunnig = true;
            isEnabled = false;

            // condicion: si no coinciden con los valores descritos presiona el boton Login
            if (this.Email != "cespinoza1982@yahoo.es" || this.Password != "1234")
            {
                await Application.Current.MainPage.DisplayAlert
                ("Error",
                 "Email or Password Incorrect",
                 "Accept");

                //Limpia el campo de Password, pero no se visualiza, se debe implementar una interfaz INotifyPropertyChanged
                this.Password = string.Empty;

                return;

            }



        }

        #endregion
    }


}
