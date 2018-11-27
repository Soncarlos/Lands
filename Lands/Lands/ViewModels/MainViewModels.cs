using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    using ViewModels;
     public class MainViewModels
    {
        #region properties
        public LoginViewModels Login
        { get; set; }
        #endregion

        #region constructor
        public MainViewModels()
        {
            this.Login = new LoginViewModels();

        }
        #endregion

    }
}
