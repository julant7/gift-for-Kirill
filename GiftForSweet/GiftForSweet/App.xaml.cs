using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GiftForSweet.Data;
using System.IO;

[assembly: ExportFont("Roboto-Black.ttf", Alias ="Roboto-Black")]
namespace GiftForSweet
{
    public partial class App : Application
    {
        static NotesDB notesDB;
        public static NotesDB NotesDB
        {
            get
            {
                if (notesDB == null)
                {
                    notesDB = new NotesDB(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "NotesDatabase.db3"));
                }
                return notesDB;
            }
        }
        public App()
        {
            Device.SetFlags(new string[] { "AppTheme_Experimental" });
            InitializeComponent();
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
