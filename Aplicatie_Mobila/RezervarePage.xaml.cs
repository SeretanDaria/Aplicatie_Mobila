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
    public partial class RezervarePage : ContentPage
    {
        RezervareList rl;
        public RezervarePage(RezervareList rlist)
        {
            InitializeComponent();
            rl = rlist;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var clienti = (Clienti)BindingContext;
            await App.Database.SaveClientiAsync(clienti); //salv detalii rezerv
            listView.ItemsSource = await App.Database.GetClientisAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var clienti = (Clienti)BindingContext;
            await App.Database.DeleteClientiAsync(clienti); //sterg detalii rezerv
            listView.ItemsSource = await App.Database.GetClientisAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetClientisAsync();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e) //detaliile din lista
        {

            Clienti c;
            if (e.SelectedItem != null)
            {
                c = e.SelectedItem as Clienti;
                var lr = new ListaRezervari()
                {
                    RezervareListID = rl.ID,
                    ClientiID = c.ID
                };
                await App.Database.SaveListaRezervariAsync(lr); //salv in lista de detalii, apoi ListPage
                c.ListaRezervari = new List<ListaRezervari> { lr };

                await Navigation.PopAsync();
            }
        }
    }
}