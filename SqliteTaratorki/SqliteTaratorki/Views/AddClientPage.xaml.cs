using SqliteTaratorki.Models;
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
    public partial class AddClientPage : ContentPage
    {
        
        public ClientInfo ClientInfo {get; set;}
        public AddClientPage()
        {
            InitializeComponent();
            BindingContext = new AddClientViewModel();

        }
        public AddClientPage(ClientInfo clientInfo)
        {
            InitializeComponent();
            BindingContext = new AddClientViewModel();

            

            if (clientInfo != null)
            {
                ((AddClientViewModel)BindingContext).ClientInfo = clientInfo;
            }
        }

        
    }
}