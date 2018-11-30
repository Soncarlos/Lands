namespace Lands.ViewModels
{
    public class MainViewModels
    {
        #region properties
        public LoginViewModels Login
        { get;
          set;
        }
        public LandsViewModels Lands 
        { get;
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
                return new MainViewModels();
            }
            return instance;
        }
        #endregion


    }
}
