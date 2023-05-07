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
    public class PersonalViewModel: BasePersonalViewModel
    {
        public Command LoadPersonalCommand { get; }
        public ObservableCollection<PersonalInfo> PersonalInfos { get; }

        public Command AddPersonalCommand { get; }
        public Command PersonalTappedEdit { get; }
        public Command PersonalTappedDelete { get; }
        public PersonalViewModel(INavigation _navigation)
        {
            LoadPersonalCommand = new Command(async () => await ExecuteLoadPersonalCommand());
            PersonalInfos = new ObservableCollection<PersonalInfo>();
            AddPersonalCommand = new Command(OnAddPersonal);
            PersonalTappedEdit = new Command<PersonalInfo>(OnEditPersonal);
            PersonalTappedDelete = new Command<PersonalInfo>(OnDeletePersonal);
            Navigation = _navigation;
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
        async Task ExecuteLoadPersonalCommand()
        {
            try
            {
                IsBusy = true;
                PersonalInfos.Clear();
                var personalList = await App.PersonalService.GetPersonalsAsync();
                foreach (var personal in personalList)
                {
                    PersonalInfos.Add(personal);
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
        private async void OnAddPersonal(Object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddPersonalPage));
        }
        private async void OnEditPersonal(PersonalInfo personal)
        {
            await Navigation.PushAsync(new AddPersonalPage(personal));
        }
        private async void OnDeletePersonal(PersonalInfo personal)
        {
            if (personal == null)
            {
                return;
            }
            await App.PersonalService.DeletePersonalAsync(personal.PersonalId);
            await ExecuteLoadPersonalCommand();
        }
    }
}
