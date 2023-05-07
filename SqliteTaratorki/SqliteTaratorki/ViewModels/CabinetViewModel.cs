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
    public class CabinetViewModel : BaseCabinetViewModel
    {
        public Command LoadCabinetCommand { get; }
        public ObservableCollection<CabinetInfo> CabinetInfos { get; }

        public Command AddCabinetCommand { get; }

        public Command CabinetTappedEdit { get; }
        public Command CabinetTappedDelete { get; }
        public CabinetViewModel(INavigation _navigation) 
        {
            LoadCabinetCommand = new Command(async()=> await ExecuteLoadCabinetCommand());
            CabinetInfos = new ObservableCollection<CabinetInfo>();
            AddCabinetCommand = new Command(OnAddCabinet);
            CabinetTappedEdit = new Command<CabinetInfo>(OnEditCabinet);
            CabinetTappedDelete = new Command<CabinetInfo>(OnDeleteCabinet);
            Navigation = _navigation;
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadCabinetCommand() 
        {
            try
            {
                IsBusy = true;
                CabinetInfos.Clear();
                var cabList = await App.CabinetService.GetCabinetsAsync();
                foreach (var cab in cabList)
                {
                    CabinetInfos.Add(cab);
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

        private async void OnAddCabinet(object obj) 
        {
            await Shell.Current.GoToAsync(nameof(AddCabinetPage));
        }
        private async void OnEditCabinet(CabinetInfo cab)
        {
            await Navigation.PushAsync(new AddCabinetPage(cab));
        }
        private async void OnDeleteCabinet(CabinetInfo cab)
        {
            if (cab == null)
            {
                return;
            }
            await App.CabinetService.DeleteCabinetAsync(cab.CabinetId);
            await ExecuteLoadCabinetCommand();
        }



    }
}
