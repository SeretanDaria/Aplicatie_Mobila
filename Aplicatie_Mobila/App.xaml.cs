using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Aplicatie_Mobila.Data;
using System.IO;

namespace Aplicatie_Mobila
{
    public partial class App : Application
    {
        static  RezervareListDatabase database;
        public static RezervareListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   RezervareListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RezervareList.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage()); //desch ListEntryPage
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
