using SqliteTaratorki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SqliteTaratorki.ViewModels
{
    public class AddPersonalViewModel: BasePersonalViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public AddPersonalViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            PersonalInfo = new PersonalInfo();
        }
        private async void OnSave()
        {
            var personal = PersonalInfo;
            await App.PersonalService.AddPersonalAsync(personal);
            await Shell.Current.GoToAsync("..");
        }
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
