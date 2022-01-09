using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicatie_Mobila.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aplicatie_Mobila
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEntryPage : ContentPage
    {
        public ListEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetRezervareListsAsync();
        }
        async void OnRezervareListAddedClicked(object sender, EventArgs e) //event pe toolbar
        {
            await Navigation.PushAsync(new ListPage //desc lista noua pt o rezervare
            {
                BindingContext = new RezervareList()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListPage
                {
                    BindingContext = e.SelectedItem as RezervareList
                });
            }
        }
    }
}