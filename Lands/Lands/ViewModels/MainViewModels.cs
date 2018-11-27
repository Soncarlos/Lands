namespace Lands.ViewModels
{
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
