using SqliteTaratorki.Models;
using SqliteTaratorki.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SqliteTaratorki.ViewModels
{
    public class ClientViewModel : BaseClientViewModel
    {

        public Command LoadClientCommand { get; }
        public ObservableCollection<ClientInfo> ClientInfos { get; }

        public Command AddClientCommand { get; }
        public Command ClientTappedEdit { get; }
        public Command ClientTappedDelete { get; }
        public ClientViewModel(INavigation _navigation) 
        {
            LoadClientCommand = new Command(async()=>await ExecuteLoadClientCommand());
            ClientInfos = new ObservableCollection<ClientInfo>();
            AddClientCommand = new Command(OnAddClient);
            ClientTappedEdit = new Command<ClientInfo>(OnEditClient);
            ClientTappedDelete = new Command<ClientInfo>(OnDeleteClient);
            Navigation = _navigation;
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadClientCommand()
        {
            try
            {
                IsBusy = true;
                ClientInfos.Clear();
                var clientList = await App.ClientService.GetClientsAsync();
                foreach (var client in clientList)
                {
                    ClientInfos.Add(client);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                IsBusy = false;
            }
        }

        private async void OnAddClient(Object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddClientPage));
        }
        private async void OnEditClient(ClientInfo client)
        {
            await Navigation.PushAsync(new AddClientPage(client));
        }
        private async void OnDeleteClient(ClientInfo client)
        {
            if (client == null)
            {
                return;
            }
            await App.ClientService.DeleteClientAsync(client.ClientId);
            await ExecuteLoadClientCommand();
        }
    }
}
