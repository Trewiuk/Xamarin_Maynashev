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
    public partial class AddNotePage : ContentPage
    {
        public NoteInfo NoteInfo { get; set; }
        public AddNotePage()
        {

            InitializeComponent();
            BindingContext = new AddNoteViewModel();
            
        }
        public AddNotePage(NoteInfo noteInfo)
        {

            InitializeComponent();
            BindingContext = new AddNoteViewModel();

            if (noteInfo != null)
            {
                ((AddNoteViewModel)BindingContext).NoteInfo = noteInfo;
            }

        }
        
    }
}