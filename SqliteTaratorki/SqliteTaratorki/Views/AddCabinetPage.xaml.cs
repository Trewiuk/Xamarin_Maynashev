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
    public partial class AddCabinetPage : ContentPage
    {
        public CabinetInfo CabinetInfo { get; set; }
        public AddCabinetPage()
        {
            InitializeComponent();
            BindingContext = new AddCabinetViewModel();
        }

        public AddCabinetPage(CabinetInfo cabinetInfo)
        {
            InitializeComponent();
            BindingContext = new AddCabinetViewModel();

            if (cabinetInfo != null)
            {
                ((AddCabinetViewModel)BindingContext).CabinetInfo = cabinetInfo;
            }
        }
    }
}