using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SqliteTaratorki.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xn--19-glcee8avbj.xn--p1ai/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}