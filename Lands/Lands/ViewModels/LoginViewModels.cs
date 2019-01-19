
namespace Lands.ViewModels
{
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using GalaSoft.MvvmLight.Command;
    using Lands.Services;
    using Lands.Models;

    // clase de tipo Interfaz para notificar cambios, actualizacion de componentes.
    public class LoginViewModels : BaseViewModels
    {
        //Implementaciop de la interfaz por medio de un Evento

        //#region Events

        //public event PropertyChangedEventHandler PropertyChanged;

        //#endregion
        #region Services
        private ApiService apiservices;
        #endregion

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
           get{ return isEnabled; }

            set{ SetValue(ref isEnabled, value); }
        }
        #endregion

        #region costructors
        public LoginViewModels()
        {
            apiservices = new ApiService();
            IsRemenbered = true;
            IsEnabled = true;
            Email = "cespinoza1982@yahoo.es";
            Password = "123456";

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
        #endregion
        #region Methods
        
        private async void Login()
        {
            // condicion: si el campo de Email esta vacio y se presiona el boton Login
            if (string.IsNullOrEmpty(this.Email))
            {
                IsRunnig = false;
                isEnabled = true;
                await Application.Current.MainPage.DisplayAlert
                    ("Error",
                    "You must enter an Email",
                    "Accept");                         
                return;

            }

            // condicion: si el campo de Password esta vacio y se presiona el boton Login
            if (string.IsNullOrEmpty(this.Password))
            {
                IsRunnig = false;
                isEnabled = true;
                await Application.Current.MainPage.DisplayAlert
                  ("Error",
                   "You must enter a Password",
                   "Accept");
                return;

            }
            IsRunnig = true;
            isEnabled = false;

            var connection = await apiservices.CheckConnection();
            if(!connection.IsSuccess)
            {
                IsRunnig = false;
                isEnabled = true;
                await Application.Current.MainPage.DisplayAlert
                 ("Error",
                  connection.Message,
                  "Accept");
                return;
            }

            var token = await apiservices.GetToken
                ("http://169.254.80.80:8020",
                Email,
                Password);

            if(token==null)
            {
                IsRunnig = false;
                isEnabled = true;
                await Application.Current.MainPage.DisplayAlert
                                 ("Error",
                                  "Algo salio mal, intentelo mas tarde",
                                  "Accept");
                return;
            }

            if(string.IsNullOrEmpty(token.AccessToken))
            {
                IsRunnig = false;
                isEnabled = true;
                await Application.Current.MainPage.DisplayAlert
                                ("Error",
                                 token.ErrorDescription,
                                 "Accept");
                Password = string.Empty;
                return;
               
            }

            //antes de Lanzar la nueva Lands Page, se llama al Metodo GetInstance 
            // que esta en MainViewModel
            //se instancia la Propiedad Lands de tipo Landsviewmodels
            var mainViemodel = MainViewModels.GetInstance();
            mainViemodel.Token = token;
            mainViemodel.Lands = new LandsViewModels();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

            IsRunnig = false;
            isEnabled = true;

            Email = string.Empty;
            Password = string.Empty;

            

            
        }

        
    }
    #endregion

}
