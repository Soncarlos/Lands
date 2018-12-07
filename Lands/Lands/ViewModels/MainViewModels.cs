namespace Lands.ViewModels
{
    using Lands.Models;
    using System.Collections.Generic;
    public class MainViewModels
    {
        #region Properties
        // Se crea como propiedad en la MainViewModels, para poder usar la lista, desde cualquier
        //lado de la aplicacion
        public List<Land> LandsList { get; set; }

        #endregion

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
