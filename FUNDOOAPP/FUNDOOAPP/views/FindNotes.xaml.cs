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
	public partial class FindNotes : ContentPage
	{
        public List<Note> noteData;
        public FindNotes ()
		{
			InitializeComponent ();
            this.GetNoteData();
            list.ItemsSource = noteData;
        }

        private  void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.NewTextValue))
                {
                    list.ItemsSource = this.noteData;
                }
                else
                {
                    list.ItemsSource = this.noteData.Where(x => x.Title.ToLower().Contains(e.NewTextValue.ToLower())
                    && x.Notes.ToLower().Contains(e.NewTextValue.ToLower()));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }

        public  async void GetNoteData()
        {
            var userid = DependencyService.Get<IFirebaseAuthenticator>().User();
            NotesRepository notesRepository = new NotesRepository();
            List<Note> note = await notesRepository.GetNotesAsync(userid);
            note = note.Where(a => a.noteType != NoteType.isArchive && a.noteType != NoteType.isTrash ).ToList();
            this.noteData = note;
        }
    }
}