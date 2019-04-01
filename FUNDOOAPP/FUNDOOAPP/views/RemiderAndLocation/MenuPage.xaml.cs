using Firebase.Database;
using Firebase.Database.Query;
using FUNDOOAPP.Interfaces;
using FUNDOOAPP.Models;
using FUNDOOAPP.Repository;
using FUNDOOAPP.views.Dashbord;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FUNDOOAPP.views.RemiderAndLocation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage
    {
        private NotesRepository notesRepository = new NotesRepository();

        private string noteKeys = string.Empty;

        private FirebaseClient firebaseclint = new FirebaseClient("https://fundooapp-810e7.firebaseio.com/");

        public MenuPage()
		{
            InitializeComponent();
		}
         
        public MenuPage(string noteKey)
        {
            this.noteKeys = noteKey;
            this.UpdateNotes();
            this.InitializeComponent();
        }

        public async void DeleteNotes()
        {
            string uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            Note note = await this.notesRepository.GetNoteByKeyAsync(this.noteKeys, uid);
            await this.firebaseclint.Child("User").Child(uid).Child("Note").Child(noteKeys).DeleteAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            this.DeleteNotes();
            await Navigation.PushModalAsync(new Masterpage());
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