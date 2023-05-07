using SqliteTaratorki.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqliteTaratorki.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientPage : ContentPage
    {
        readonly ClientViewModel clientViewModel;
        public ClientPage()
        {
            InitializeComponent();
            BindingContext = clientViewModel = new ClientViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            clientViewModel.OnAppearing();
        }
    }
}