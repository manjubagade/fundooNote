using Firebase.Database;
using Firebase.Database.Query;
using FUNDOOAPP.Interfaces;
using FUNDOOAPP.Models;
using FUNDOOAPP.Repository;
using FUNDOOAPP.views.Dashbord;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FUNDOOAPP.DataFile.Enum;

namespace FUNDOOAPP.views.RemiderAndLocation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : PopupPage
    {
        private NotesRepository notesRepository = new NotesRepository();

        private string noteKeys = string.Empty;

        private FirebaseClient firebaseclint = new FirebaseClient("https://fundooapp-810e7.firebaseio.com/");

        public MenuPage(string notekay)
		{
            this.noteKeys = notekay;
            InitializeComponent();
		}
         
        

        public async void DeleteNotes()
        {
            string uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            Note note = await this.notesRepository.GetNoteByKeyAsync(this.noteKeys, uid);
            await this.firebaseclint.Child("User").Child(uid).Child("Note").Child(noteKeys).DeleteAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Note note = new Note();
                var uid = DependencyService.Get<IFirebaseAuthenticator>().User();
                note = await notesRepository.GetNoteByKeyAsync(this.noteKeys, uid);
                note.noteType = NoteType.isTrash;
                await notesRepository.UpdateNoteAsync(note, this.noteKeys, uid);
                await Navigation.PushModalAsync(new Masterpage());
                await PopupNavigation.Instance.PopAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }      
        }
        public async void UpdateNotes()
        {
            string uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            Note note = await this.notesRepository.GetNoteByKeyAsync(this.noteKeys, uid);
            
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync(true);
             PopupNavigation.Instance.PushAsync(new SharePage());     
        }
    }
}