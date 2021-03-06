﻿namespace Lands.ViewModels
{
    using Lands.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using ViewModels;
    public class LandViewModel: BaseViewModels
    {
        #region Attributes 
        // atributo para que trabaje con el modelo Border
        private ObservableCollection<Border> border;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> languages;
        

        #endregion

        #region Properties
        
        //Una propieda llamada Land de igual al modelo Land, la cual se subbindeara al layout en la LandPage
        public Land Land
        {
         get;
         set;
        }

        public ObservableCollection<Language> Languages
        {
            get { return languages; }
            set { SetValue(ref languages, value); }
        }

        public ObservableCollection <Currency> Currencies
        {
            get{ return currencies; }
            set{ SetValue(ref currencies, value);}
        }
        public ObservableCollection<Border> Borders
        {
            get { return border; }
            set { SetValue(ref border, value); }

        }

        #endregion

        #region Constructor

        public LandViewModel(Land land)
        {
          Land = land;
          LoadBorders();
          Currencies = new ObservableCollection<Currency>(Land.Currencies);
          Languages = new ObservableCollection<Language>(Land.Languages);
          

        }
        #endregion

        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();

            foreach (string border in this.Land.Borders)
            {
                var land = MainViewModels.GetInstance().LandsList.
                                        Where(l => l.Alpha3Code==border).
                                        FirstOrDefault();
                if (land != null)
                {
                    this.Borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name,
                    });
                }
            }
        }
    }
        
    }

