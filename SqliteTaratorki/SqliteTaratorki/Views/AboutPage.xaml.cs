using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteTaratorki.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Button_Cabinet(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CabinetPage());
        }

        private void Button_Client(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ClientPage());
        }

        private void Button_Personal(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PersonalPage());
        }

        private void Button_Note(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotePage());
        }
    }
}