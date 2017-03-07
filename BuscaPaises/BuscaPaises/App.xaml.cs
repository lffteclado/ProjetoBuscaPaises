using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BuscaPaises
{
    public partial class App : Application
    {
        private MainPage _mainPage;
        public App()
        {
            _mainPage = new BuscaPaises.MainPage();

            InitializeComponent();

            MainPage = _mainPage;

            //MainPage = new BuscaPaises.MainPage();
        }

        protected override void OnStart()
        {
            _mainPage.Load();

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
