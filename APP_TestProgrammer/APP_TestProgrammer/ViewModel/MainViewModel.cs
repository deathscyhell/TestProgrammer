using APP_TestProgrammer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace APP_TestProgrammer.ViewModel
{
    public class MainViewModel
    {
        #region properties
        public Dashboard_ViewModel Dashboard { get; set; }

        #region List
        public List<Employees> List_Employees { get; set; }
        public List<Profile> List_Profile { get; set; }
        public List<Position> List_Position{ get; set; }
        #endregion
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            this.Dashboard = new Dashboard_ViewModel();
        }
        #endregion

        #region Singleton
        public static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion 
        
        

    }
}
