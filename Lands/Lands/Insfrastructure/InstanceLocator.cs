using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Insfrastructure
{
    using ViewModels;
    
    public class InstanceLocator
    {
        #region Property
        public MainViewModels Main
        { get; set; }

        #endregion

        #region constructors

        public InstanceLocator()
        {
          this.Main = new MainViewModels();

        }

        #endregion
    }
}
