using SqliteTaratorki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SqliteTaratorki.ViewModels
{
    public class AddClientViewModel: BaseClientViewModel
    {
        public Command SaveCommand { get; }

        public Command CancelCommand { get; }
        public AddClientViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            ClientInfo = new ClientInfo();


        }

        private async void OnSave()
        {
            var client = ClientInfo;
            await App.ClientService.AddClientAsync(client);
            await Shell.Current.GoToAsync("..");
        }
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
