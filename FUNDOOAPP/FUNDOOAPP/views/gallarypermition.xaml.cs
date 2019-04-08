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
        public gallarypermition ()
		{
			InitializeComponent ();
		}
        private async void btnPick_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (file == null)
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
        private async void btnStore_Clicked(object sender, EventArgs e)
        {
            await StoreImages(file.GetStream());
        }
        public async Task<string> StoreImages(Stream imageStream)
        {
            String timeStamp = GetTimestamp(DateTime.Now);
            var stroageImage = await new FirebaseStorage("fundooapp-810e7.appspot.com")
                .Child("XamarinMonkeys")
                .Child("image_" + timeStamp + ".jpg")
                .PutAsync(imageStream);
            string imgurl = stroageImage;
            return imgurl;
        }

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

    }
}