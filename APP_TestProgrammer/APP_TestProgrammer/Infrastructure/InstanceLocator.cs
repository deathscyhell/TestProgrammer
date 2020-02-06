using APP_TestProgrammer.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace APP_TestProgrammer.Infrastructure
{
    public class InstanceLocator
    {
        #region Properties
        public MainViewModel Main { get; set; }
        #endregion

        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
