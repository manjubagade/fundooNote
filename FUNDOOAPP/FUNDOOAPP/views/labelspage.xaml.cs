using FUNDOOAPP.Database;
using Plugin.InputKit.Shared.Controls;
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
	public partial class labelspage : ContentPage
	{
		public labelspage ()
		{
			InitializeComponent ();
		}
        Firebasedata firebasedata = new Firebasedata();
        protected async override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                var alllabels = await firebasedata.GetAllLabels();
                lstLabels.ItemsSource = alllabels;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void CheckBox_CheckChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            IList<string> list = new List<string>();
            if (checkbox.IsChecked)
            {
                checkbox.Color = Color.Black;
            }
        }
    }
}