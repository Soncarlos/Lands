
namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    // clase de tipo Interfaz para notificar cambios, actualizacion de componentes.
    public class LoginViewModels : BaseViewModels
    {
        //Implementaciop de la interfaz por medion de un Evento

        //#region Events

        //public event PropertyChangedEventHandler PropertyChanged;

        //#endregion

        #region attributes
        private string email;
        private string password;
        private bool isRunnig;
        private bool isEnabled;
        #endregion


        #region Properties

        public string Email
        {
            get { return email; }

            set { SetValue(ref email, value); }

        }

        public string Password
        {
            get
            { return password; }

            set { SetValue(ref password, value);

            }
        }

        public bool IsRunnig
        {
            // abreviacion  get => isRunnig;
            get
            { return isRunnig; }

            set
            {
                SetValue(ref isRunnig, value);

            }
        }

        public bool IsRemenbered { get; set; }

        public bool IsEnabled

        {
            get
            { return isEnabled; }

            set
            {
                SetValue(ref isEnabled, value);

            }
        }
        #endregion

        #region costructors
        public LoginViewModels()
        {
            IsRemenbered = true;
            IsEnabled = true;
            Email= "cespinoza1982@yahoo.es";
            Password = "1234";



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
        /// <summary>
        /// 
        /// </summary>
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

                IsRunnig = false;
                isEnabled = true;
                await Application.Current.MainPage.DisplayAlert
                ("Error",
                 "Email or Password Incorrect",
                 "Accept");

                //Limpia el campo de Password, pero no se visualiza, se debe implementar una interfaz INotifyPropertyChanged
                this.Password = string.Empty;

                return;

            }
              // envia un mensaje de exito
                IsRunnig = false;
               isEnabled = true;
               //await Application.Current.MainPage.DisplayAlert
               // ("OK",
               //  "fuck Yeahhh",
               //  "Accept");

            Email = string.Empty;
            Password = string.Empty;

            //antes de Lanzar la nueva Lands Page, se llama al Metodo GetInstance 
            // que esta en MainViewModel
            //se instancia la Propiedad Lands de tipo Landsviewmodels
            MainViewModels.GetInstance().Lands= new LandsViewModels();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

        }

        #endregion
    }


}
