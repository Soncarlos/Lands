
namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Models;
    using Lands.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LandItemViewModel :Land
    {
        #region Command
        public ICommand SelectLandCommand => new RelayCommand(SelectLand);
        #endregion

        #region SelectLand Method
        private async void SelectLand()
        {
            MainViewModels.GetInstance().Land = new LandViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandPage());
        } 
        #endregion
    }

}
