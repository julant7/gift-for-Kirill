using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GiftForSweet.Models;

namespace GiftForSweet.Views
{
    public partial class NotesPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public NotesPage()
        {
            InitializeComponent();
            BindingContext = new Note();
        }


        private async void LoadNote(string value)
        {
            try
            {
                int id = Convert.ToInt32(value);

                Note note = await App.NotesDB.GetNoteAsync(id);

                BindingContext = note;
            }
            catch { }
        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = await App.NotesDB.GetNotesAsync();
            base.OnAppearing();
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NoteAddingPage)); 
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync(
                    $"{nameof(NoteAddingPage)}?{nameof(NoteAddingPage.ItemId)}={note.ID.ToString()}");
            }
        }
        private async void OnSaveButton_Clicked(object sender, EventArgs e)
        {
            Note note = (Note)BindingContext;

            note.Date = DateTime.UtcNow;

            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.NotesDB.SaveNotAsync(note);
            }

            await Shell.Current.GoToAsync("..");
        }
    }
}