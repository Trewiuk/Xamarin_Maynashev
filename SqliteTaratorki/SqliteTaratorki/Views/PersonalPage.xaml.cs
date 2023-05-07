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
    public partial class PersonalPage : ContentPage
    {
        readonly PersonalViewModel personalViewModel;
        public PersonalPage()
        {
            InitializeComponent();
            BindingContext = personalViewModel = new PersonalViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            personalViewModel.OnAppearing();
        }
    }
}