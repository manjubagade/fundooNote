//-----------------------------------------------------------------------
// <copyright file="UpdateNote.xaml.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FUNDOOAPP.views
{
    using System;
    using System.Diagnostics;
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
    using static FUNDOOAPP.DataFile.Enum;

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
            ToolbarItems.Clear();
            if (note.noteType == NoteType.isNote)
            {
                ToolbarItems.Add(this.archived);
                ToolbarItems.Add(this.alaram);
                ToolbarItems.Add(this.pincard);
            }
            else if (note.noteType == NoteType.isArchive)
            {
                ToolbarItems.Add(this.unarchived);
            }
            else if (note.noteType == NoteType.isTrash)
            {
                ToolbarItems.Add(this.deleted);
                ToolbarItems.Add(this.Restoredata);
            }
        }

        /// <summary>
        /// DeleteNotes this instance
        /// </summary>
        public async void DeleteNotes()
        {
            string uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            Note note = await this.notesRepository.GetNoteByKeyAsync(this.noteKeys, uid);
            Delete delete = new Delete();
           // delete.Trash(note);
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
        //protected override async void OnDisappearing()
        //{
        //    var uid = DependencyService.Get<IFirebaseAuthenticator>().User();

        //    Note newnote = new Note()
        //    {
        //        Title = editor.Text,
        //        Notes = editorNote.Text
        //    };
        //    await this.notesRepository.UpdateNoteAsync(newnote, this.noteKeys, uid);

        //    base.OnDisappearing();
        //}

        /// <summary>
        /// Delete_Clicked this instance
        /// </summary>
        /// <param name="sender">name</param>
        /// <param name="e">name p</param>
        private async void Delete_Clicked(object sender, EventArgs e)
        {
            this.DeleteNotes();
            await Navigation.PushModalAsync(new Masterpage()); 
        }

        /// <summary>
        /// this Listview_Clicked instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Listview_Clicked(object sender, EventArgs e)
        {
           // PopupNavigation.Instance.PushAsync(new MenuPage(noteKeys));
        }

        /// <summary>
        /// this ImageButton_Clicked instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new MenuPage(this.noteKeys));
        }

        /// <summary>
        /// this Bell_btn_Clicked instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bell_btn_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Remainder());
        }

        /// <summary>
        /// this Archived_Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Archived_Clicked(object sender, EventArgs e)
        {
            string uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            Note note = await this.notesRepository.GetNoteByKeyAsync(this.noteKeys, uid);
            note.noteType = NoteType.isArchive;
            await notesRepository.UpdateNoteAsync(note, this.noteKeys, uid);
            await Navigation.PushAsync(new Masterpage());
        }

        /// <summary>
        /// this ToolbarItem_Clicked instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            string uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            Note note = await notesRepository.GetNoteByKeyAsync(this.noteKeys, uid);
            note.noteType = NoteType.isArchive;
            await this.notesRepository.UpdateNoteAsync(note, this.noteKeys, uid);
            await Navigation.PushModalAsync(new Masterpage());
        }

        /// <summary>
        /// this Nodification_Clicked instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> EventArgs</param>
        private void Nodification_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Remainder());
        }

        /// <summary>
        /// this Deleted_Clicked instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Deleted_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Question?", "Delete this note forever", "Delete", "Cancel");
           if (answer == true)
            {
                this.DeleteNotes();
                await Navigation.PushModalAsync(new Masterpage());
            }
            else
            {
                await Navigation.PushModalAsync(new Masterpage());
            }
        }

        /// <summary>
        /// this Restoredata_Clicked instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> task</param>
        private async void Restoredata_Clicked(object sender, EventArgs e)
        {
            var uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            Note newnote = new Note()
            {
                Title = editor.Text,
                Notes = editorNote.Text
            };
          await this.notesRepository.UpdateNoteAsync(newnote, this.noteKeys, uid);
            await Navigation.PushModalAsync(new Masterpage());
        }

        private async void Unarchived_Clicked_1(object sender, EventArgs e)
        {
            var uid = DependencyService.Get<IFirebaseAuthenticator>().User();

            Note newnote = new Note()
            {
                Title = editor.Text,
                Notes = editorNote.Text
            };
            await this.notesRepository.UpdateNoteAsync(newnote, this.noteKeys, uid);
            await Navigation.PushModalAsync(new Masterpage());
        }
    }
} 