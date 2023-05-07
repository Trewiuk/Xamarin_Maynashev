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
    public partial class CabinetPage : ContentPage
    {
        readonly CabinetViewModel cabinetViewModel;
        public CabinetPage()
        {
            InitializeComponent();
            BindingContext = cabinetViewModel = new CabinetViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            cabinetViewModel.OnAppearing();
        }
    }
}