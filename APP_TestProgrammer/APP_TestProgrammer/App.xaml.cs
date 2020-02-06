using APP_TestProgrammer.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APP_TestProgrammer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Dashboard_Page();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
