using Alzapp.Data;
using Alzapp.ViewModels;
using Alzapp.Views;
using System;
using System.IO;
using Xamarin.Forms;

namespace Alzapp
{
    public partial class App : Application
    {
        //Para poder generar una MasterPage (Para poder tener un Menu deslizante) y poder navegar
        public static NavigationPage Navigator { get; internal set; }

        //Para generar la conexion con el SQLite
        static SQLiteHelper db;
        public App()
        {
            InitializeComponent();
            Sharpnado.Tabs.Initializer.Initialize(false, false);
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            MainViewModel.GetInstance().Principal = new PrincipalViewModel();
            Application.Current.MainPage = new NavigationPage(new PrincipalPage());
        }
        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Alzapp.db3"));

                }
                return db;
            }
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
