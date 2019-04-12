using Firebase.Database;
using Firebase.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FUNDOOAPP.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
     public partial class gallarypermition : ContentPage
     {
        MediaFile file;
         public gallarypermition()
         {
            this.InitializeComponent();
         }

        /// <summary>
        /// Handles the Clicked event of the btnPick control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btnPick_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                this.file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (this.file == null)
                    return;
                imgChoosed.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = file.GetStream();
                    return imageStram;
                });
                await StoreImages(file.GetStream());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Clicked event of the btnStore control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btnStore_Clicked(object sender, EventArgs e)
        {
            await StoreImages(file.GetStream());
        }

        /// <summary>
        /// Stores the images.
        /// </summary>
        /// <param name="imageStream">The image stream.</param>
        /// <returns></returns>
        public async Task<string> StoreImages(Stream imageStream)
        {
            FirebaseClient firebaseclint = new FirebaseClient("https://fundooapp-810e7.firebaseio.com/");
            String timeStamp = GetTimestamp(DateTime.Now);
            var stroageImage = await new FirebaseStorage("fundooapp-810e7.appspot.com")
                .Child("XamarinMonkeys")
                .Child("image_" + timeStamp + ".jpg")
                .PutAsync(imageStream);
            string imgurl = stroageImage;
            return imgurl;
        }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}