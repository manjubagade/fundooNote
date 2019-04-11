using FUNDOOAPP.Interfaces;
using FUNDOOAPP.Models;
using FUNDOOAPP.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FUNDOOAPP.DataFile.Enum;

namespace FUNDOOAPP.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchNotes : ContentPage
    {
        public List<Note> noteData;
        public SearchNotes()
        {
            InitializeComponent();
            Getdata();
            list.ItemsSource = noteData;
        }
        public async void Getdata()
        {
            var userid = DependencyService.Get<IFirebaseAuthenticator>().User();
            NotesRepository notesRepository = new NotesRepository();
            List<Note> note = await notesRepository.GetNotesAsync(userid);
            note = note.Where(a => a.noteType != NoteType.isArchive && a.noteType!=NoteType.isTrash).ToList();
            noteData = note;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(e.NewTextValue))
            {
                list.ItemsSource = noteData;
            }
            else
            {
                list.ItemsSource = noteData.Where(x => (x.Title.ToLower().Contains(e.NewTextValue.ToLower())
                && x.Notes.ToLower().Contains(e.NewTextValue.ToLower())) || x.Title.ToLower().Contains(e.NewTextValue.ToLower()) 
                || x.Notes.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }
    } 
}