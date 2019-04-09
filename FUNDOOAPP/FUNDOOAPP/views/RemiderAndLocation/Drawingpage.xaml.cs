using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FUNDOOAPP.views.RemiderAndLocation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Drawingpage : ContentPage
	{
		public Drawingpage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
          Stream image=  await PadView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Jpeg);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            PadView.Clear();
        }
    } 
}