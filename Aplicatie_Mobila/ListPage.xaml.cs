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
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var rlist = (RezervareList)BindingContext;
            rlist.Data = DateTime.UtcNow;
            await App.Database.SaveRezervareListAsync(rlist);
            await Navigation.PopAsync();  // desch pag precedenta ListEntryPage
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var rlist = (RezervareList)BindingContext;
            await App.Database.DeleteRezervareListAsync(rlist);
            await Navigation.PopAsync();
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RezervarePage((RezervareList)this.BindingContext) //desc RezervarePage pt adaug detalii
            {
                BindingContext = new Clienti()
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var rezervl = (RezervareList)BindingContext;

            listView.ItemsSource = await App.Database.GetListaRezervarisAsync(rezervl.ID);
        }
    }
}