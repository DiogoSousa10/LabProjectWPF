using System;
using UTAD.Lab.G01.MobileDroid.Services;
using UTAD.Lab.G01.MobileDroid.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UTAD.Lab.G01.MobileDroid
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            
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
