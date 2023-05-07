using SqliteTaratorki.ViewModels;
using SqliteTaratorki.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SqliteTaratorki
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AddCabinetPage), typeof(AddCabinetPage));
            Routing.RegisterRoute(nameof(AddClientPage), typeof(AddClientPage));
            Routing.RegisterRoute(nameof(AddPersonalPage), typeof(AddPersonalPage));
            Routing.RegisterRoute(nameof(AddNotePage), typeof(AddNotePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
           
           
                await Shell.Current.GoToAsync("//LoginPage");
          
        }
    }
}
