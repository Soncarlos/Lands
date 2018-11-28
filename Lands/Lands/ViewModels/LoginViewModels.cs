
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
        private bool isrunnig;
        #endregion


        #region Properties
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRunnig { get; set; }
        public bool IsRemenbered { get; set; }
        public bool IsEnabled { get; set; }
        #endregion

        #region costructors
        public LoginViewModels()
        {
            this.IsRemenbered = true;

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
