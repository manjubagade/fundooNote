//-----------------------------------------------------------------------
// <copyright file="Notes.xaml.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FUNDOOAPP.views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Firebase.Database;
    using Firebase.Database.Query;
    using FUNDOOAPP.Interfaces;
    using FUNDOOAPP.Models;
    using Rg.Plugins.Popup.Services;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]

    /// <summary>
    /// firebase page
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    public partial class Notes : ContentPage
    {
        /// <summary>
        /// The firebase client
        /// </summary>
        private FirebaseClient firebaseclint = new FirebaseClient("https://fundooapp-810e7.firebaseio.com/");

        /// <summary>
        /// Initializes a new instance of the <see cref="Notes"/> class.
        /// </summary>
        public Notes()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Create notes this instance.
        /// </summary>
        /// <returns>return task</returns>
        public async Task<List<Note>> Createnotes()
        {
            var uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            return (await this.firebaseclint.Child("User").Child(uid).Child("Note").OnceAsync<Note>()).Select(item => new Note
            {
                Title = item.Object.Title,
                Notes = item.Object.Notes
            }).ToList();
        }

        /// <summary>
        /// Application developers can override this method to provide behavior when the back button is pressed.
        /// </summary>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        //protected override bool OnBackButtonPressed()
        //{
        //    var uid = DependencyService.Get<IFirebaseAuthenticator>().User();
        //    var response = this.firebaseclint.Child("User").Child(uid).Child("Note").PostAsync<Note>(new Note() { Title = title.Text, Notes = notess.Text });
        //    base.OnBackButtonPressed();
        //    return false;
        //}

         protected override void OnDisappearing()
        {
            var uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            var response = this.firebaseclint.Child("User").Child(uid).Child("Note").PostAsync<Note>(new Note() { Title = title.Text, Notes = notess.Text });
            base.OnDisappearing();
        }
    }
}