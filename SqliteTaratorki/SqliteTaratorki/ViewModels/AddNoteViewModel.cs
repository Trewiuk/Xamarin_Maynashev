using SqliteTaratorki.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SqliteTaratorki.ViewModels
{
    class AddNoteViewModel: BaseNoteViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public AddNoteViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            NoteInfo = new NoteInfo();            
        }
        private async void OnSave()
        {
            var note = NoteInfo;
            await App.NoteService.AddNoteAsync(note);
            await Shell.Current.GoToAsync("..");
        }
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
