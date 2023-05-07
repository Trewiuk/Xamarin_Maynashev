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
    public class NoteViewModel: BaseNoteViewModel
    {
        public Command LoadNoteCommand { get; }
        public ObservableCollection<NoteInfo> NoteInfos { get; }

        public Command AddNoteCommand { get; }

        public Command NoteTappedEdit { get; }
        public Command NoteTappedDelete { get; }
        public NoteViewModel(INavigation _navigation)
        {
            LoadNoteCommand = new Command(async () => await ExecuteLoadNoteCommand());
            NoteInfos = new ObservableCollection<NoteInfo>();
            AddNoteCommand = new Command(OnAddNote);
            NoteTappedEdit = new Command<NoteInfo>(OnEditNote);
            NoteTappedDelete = new Command<NoteInfo>(OnDeleteNote);
            Navigation = _navigation;
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }
        async Task ExecuteLoadNoteCommand()
        {
            try
            {
                IsBusy = true;
                NoteInfos.Clear();
                var noteList = await App.NoteService.GetNotesAsync();
                foreach (var note in noteList)
                {
                    NoteInfos.Add(note);
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
        private async void OnAddNote(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddNotePage));
        }
        private async void OnEditNote(NoteInfo note)
        {
            await Navigation.PushAsync(new AddNotePage(note));
        }
        private async void OnDeleteNote(NoteInfo note)
        {
            if (note == null)
            {
                return;
            }
            await App.NoteService.DeleteNoteAsync(note.NoteId);
            await ExecuteLoadNoteCommand();
        }
    }
}
