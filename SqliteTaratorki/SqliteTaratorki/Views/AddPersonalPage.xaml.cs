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
    public partial class AddPersonalPage : ContentPage
    {
        public PersonalInfo PersonalInfo { get; set; }
        public AddPersonalPage()
        {
            InitializeComponent();
            BindingContext = new AddPersonalViewModel();
        }
        public AddPersonalPage(PersonalInfo personalInfo)
        {
            InitializeComponent();
            BindingContext = new AddPersonalViewModel();

            if (personalInfo != null)
            {
                ((AddPersonalViewModel)BindingContext).PersonalInfo = personalInfo;
            }
        }
    }
}