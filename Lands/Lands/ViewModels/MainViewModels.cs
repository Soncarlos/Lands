namespace Lands.ViewModels
{
    public class MainViewModels
    {
        
        #region ViewModels
        public LoginViewModels Login
        { get;
          set;
        }
        public LandsViewModels Lands 
        { get;
          set;
        }

        public LandViewModel Land
        {
            get;
            set;

        }


        #endregion

        #region constructor

        public MainViewModels()
        {
            instance = this;
            this.Login = new LoginViewModels();

        }
        #endregion


        #region Singleton de la MainViewModels
        // permitir llamado de la MainViewModels desde cualquier otra clase, 
        //para usar una unica MainViewModels

        private static MainViewModels instance;

        public static MainViewModels GetInstance()
        {
            if(instance==null)
            {
                instance= new MainViewModels();
            }

            return instance;
        }
        #endregion


    }
}
