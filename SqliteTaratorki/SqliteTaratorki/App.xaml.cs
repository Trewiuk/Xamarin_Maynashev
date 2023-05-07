using SqliteTaratorki.Services;
using SqliteTaratorki.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace SqliteTaratorki
{
    public partial class App : Application
    {
        static NoteService _noteService;
        public static NoteService NoteService
        {
            get
            {
                if (_noteService == null)
                {
                    _noteService = new NoteService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Note.db3"));
                }
                return _noteService;
            }
        }
        static PersonalService _personalService;
        public static PersonalService PersonalService
        {
            get
            {
                if (_personalService == null)
                {
                    _personalService = new PersonalService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Personal.db3"));
                }
                return _personalService;
            }
        }
        static ClientService _clientService;
        public static ClientService ClientService 
        {
            get
            {
                if (_clientService == null)
                {
                    _clientService = new ClientService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Client.db3"));
                }
                return _clientService;
            }
        }


        static CabinetService _cabinetService;
        public static CabinetService CabinetService
        {
            get 
            {
                if(_cabinetService==null)
                {
                    _cabinetService = new CabinetService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Cabinet.db3"));
                }
                return _cabinetService;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
