//-----------------------------------------------------------------------
// <copyright file="UpdateNote.xaml.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FUNDOOAPP.views
{
    using System;
    using Firebase.Database;
    using Firebase.Database.Query;
    using FUNDOOAPP.Interfaces;
    using FUNDOOAPP.Models;
    using FUNDOOAPP.Repository;
    using FUNDOOAPP.views.Dashbord;
    using FUNDOOAPP.views.RemiderAndLocation;
    using Rg.Plugins.Popup.Services;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]

    /// <summary>
    /// this class UpdateNote instance
    /// </summary>
    public partial class UpdateNote : ContentPage
    {
        /// <summary>
        /// this class UpdateNote instance
        /// </summary>
        private string noteKeys = string.Empty;

        /// <summary>
        /// NotesRepository this instance
        /// </summary>
        private NotesRepository notesRepository = new NotesRepository();

        /// <summary>
        /// FirebaseClient this instance
        /// </summary>
        private FirebaseClient firebaseclint = new FirebaseClient("https://fundooapp-810e7.firebaseio.com/");

        /// <summary>
        /// UpdateNote this instance
        /// </summary>
        /// <param name="noteKey">note Key</param>
        public UpdateNote(string noteKey)
        {
            this.noteKeys = noteKey;
            this.UpdateNotes();
            this.InitializeComponent();
        }

        /// <summary>
        /// UpdateNotes this instance
        /// </summary>
        public async void UpdateNotes()
        {
            string uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            Note note = await this.notesRepository.GetNoteByKeyAsync(this.noteKeys, uid);
            editor.Text = note.Title;
            editorNote.Text = note.Notes;
        }

        /// <summary>
        /// DeleteNotes this instance
        /// </summary>
        public async void DeleteNotes()
        {
            string uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            Note note = await this.notesRepository.GetNoteByKeyAsync(this.noteKeys, uid);
            Delete delete = new Delete();
            delete.Trash(note);
            await this.firebaseclint.Child("User").Child(uid).Child("Note").Child(this.noteKeys).DeleteAsync();
        }

        /// <summary>
        /// OnBackButtonPressed this instance
        /// </summary>
        /// <returns>return task</returns>
        protected override bool OnBackButtonPressed()
        {
            if (Device.RuntimePlatform.Equals(Device.Android))
            {
                var uid = DependencyService.Get<IFirebaseAuthenticator>().User();

                Note newnote = new Note()
                {
                    Title = editor.Text,
                    Notes = editorNote.Text
                };
                this.notesRepository.UpdateNoteAsync(newnote, this.noteKeys, uid);

                return base.OnBackButtonPressed();
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Delete_Clicked this instance
        /// </summary>
        /// <param name="sender">name</param>
        /// <param name="e">name</param>
        private async void Delete_Clicked(object sender, EventArgs e)
        {
            this.DeleteNotes();
            await Navigation.PushModalAsync(new Masterpage());
        }

       
        private void Listview_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new MenuPage());
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new MenuPage());
        }

        private void Bell_btn_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Remainder());
        }
    }
}