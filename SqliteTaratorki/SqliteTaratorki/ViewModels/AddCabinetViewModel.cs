using SqliteTaratorki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SqliteTaratorki.ViewModels
{
    public class AddCabinetViewModel : BaseCabinetViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public AddCabinetViewModel() 
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();


            CabinetInfo = new CabinetInfo();

        }

        

        private async void OnSave()
        {
            var cabinet = CabinetInfo;
            await App.CabinetService.AddCabinetAsync(cabinet);
            await Shell.Current.GoToAsync("..");
        }
        private async void OnCancel()
        {
          await Shell.Current.GoToAsync("..");
        }
    }
}
