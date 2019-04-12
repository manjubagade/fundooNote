using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FUNDOOAPP.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
      public partial class CameraPermition : ContentPage
      {
       public CameraPermition()
        {
          this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Clicked event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsTakePhotoSupported && CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("alert", "take photo not supported", "ok");
                return;
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Images",
                    Name = DateTime.Now + "_test.jpg"
                });

                if (file == null)
                    return;
                await DisplayAlert("file path", file.Path, "ok");

                MyImage.Source = ImageSource.FromStream(() =>
                {
                    var steam = file.GetStream();
                    return steam;
                });
            }      
        }
    }
}