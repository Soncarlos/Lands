namespace Lands.ViewModels
{
    using Lands.Models;
    using System.Collections.ObjectModel;
    using Services;
    using Xamarin.Forms;
    using System.Collections.Generic;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using System;
    using System.Linq;

    public class LandsViewModels : BaseViewModels
    {
        #region Services
        private ApiService apiServices;
        #endregion

        #region Attibutes
        // se crea un observablecolecction porque se va a pintar en un List view
        private List<Land> LandsList;
        private ObservableCollection<LandItemViewModel> lands;
        private bool isRefreshing;
        private string filter;
        

        #endregion

        #region Properties
        public ObservableCollection<LandItemViewModel> Lands
        {
           get { return lands; }
           set { SetValue(ref lands, value); }

        }

        public bool IsRefreshing
        {

          get { return isRefreshing; }
          set { SetValue(ref isRefreshing, value); }

           
        }

        public string Filter
        {
           get { return filter;}
           set { SetValue(ref filter, value);
                Search();
            }
        }


        #endregion

        #region Constructor
        public LandsViewModels()
        {
            apiServices = new ApiService();
            LoadLands();
        }

        
        #endregion

        #region LoadLands Method
        private async void  LoadLands()
        {
            IsRefreshing = true;
            ////Se verifica la conexion a internet, SI ESTA ENCENDIDO EL WIFI O LOS DATOS
            var connection = await apiServices.CheckConnection();
             if (!connection.IsSuccess)
             {
               await Application.Current.MainPage.DisplayAlert
                     ("Error",
                      connection.Message,
                      "Accept");
               // como no hay conexion a internet, se regresa a la pagina anterior
                await Application.Current.MainPage.Navigation.PopAsync();
                IsRefreshing = false;
                return;
             }
          ////Se verifica la conexion a internet, SI HAY SALIDA A INTERNET aun no implementada

            
            var response = await apiServices.GetList<Land>
                ("http://www.restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                 "Error", response.Message, "Accept");
                IsRefreshing = false;
                return;
                
            }
            // Se castea la lista resultante al modelo Land
            LandsList = (List<Land>)response.Result;
            Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel());
            IsRefreshing = false;

        }
        #endregion
        
        #region ToLandItemViewModel Methods
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return LandsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }
        #endregion

        #region Search Method

        private void Search()
        {
            if(string.IsNullOrEmpty(Filter))
            {
                Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel()); 
            }
            else
            {
                Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel().Where(l => l.Name.ToLower().Contains(Filter.ToLower()) ||
                 l.Capital.ToLower().Contains(Filter.ToLower())));
            }
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand => new RelayCommand(LoadLands);
        public ICommand SearchCommmad => new RelayCommand(Search);

        #endregion
    }
}
