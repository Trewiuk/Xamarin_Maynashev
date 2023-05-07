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
    public partial class NotePage : ContentPage
    {
        NoteViewModel noteViewModel;
        public NotePage()
        {
            InitializeComponent();
            BindingContext = noteViewModel = new NoteViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            noteViewModel.OnAppearing();
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}