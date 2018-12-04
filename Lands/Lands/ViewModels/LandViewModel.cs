namespace Lands.ViewModels
{
    using Lands.Models;
    using ViewModels;
    public class LandViewModel: BaseViewModels
    {
        #region Properties
        //Una propieda llamada Land de igual al modelo Land, la cual se subbindeara al layout en la LandPage
        public Land Land
        {
         get;
         set;
        }

        #endregion
        public LandViewModel(Land land)
        {
          this.Land = land;
        }
    }
}
