
namespace Lands.ViewModels
{
    using System.Windows.Input;

   public class LoginViewModels
    {
         
        #region Properties
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRunnig { get; set; }
        public bool IsRemenbered { get; set; }
        #endregion

        #region costructors
        public LoginViewModels()
        {
            this.IsRemenbered = true;

        }
        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }     

        #endregion
   }

    
}
