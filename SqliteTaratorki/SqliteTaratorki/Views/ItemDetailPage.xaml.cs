using SqliteTaratorki.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SqliteTaratorki.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}