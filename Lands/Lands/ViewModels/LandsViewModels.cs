namespace Lands.ViewModels
{
    using Lands.Models;
    using System.Collections.ObjectModel;
    using Services;
    using Xamarin.Forms;
    using System.Collections.Generic;

    public class LandsViewModels: BaseViewModels
    {

        #region Services
        private ApiService apiServices;

        #endregion
        #region Attibutes
        // se crea un observablecolecction porque se va a pintar en un List view
        private ObservableCollection<Land> lands;
        #endregion

        #region Properties
        public ObservableCollection<Land> Lands
        {
            get {return lands;}
            set {SetValue(ref lands,  value );}

        }
        #endregion

        #region Constructor
        public LandsViewModels()
        {
            apiServices = new ApiService();
            LoadLands();
        }
        #endregion

        #region Methods
        // 
        private async void LoadLands()
        {

            var response = await apiServices.GetList<Land>(
                "http://www.restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                 "Error", response.Message, "Accept");
                return;
               
            }
            // Se castea la lista resultante al modelo Land
            var Mylist = (List<Land>)response.Result;

            Lands = new ObservableCollection<Land>(Mylist);



        }
        #endregion

        
    }
}
