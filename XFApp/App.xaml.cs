using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFApp.Services;
using XFApp.Views;
using XFApp.Bootstrap;
using XFApp.Contracts;

namespace XFApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            XF.Material.Forms.Material.Init(this);
           
            AppContainer.RegisterDependencies();

            MainPage = new MainPage();

            Init();

        }

        private async void Init()
        {
           
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
