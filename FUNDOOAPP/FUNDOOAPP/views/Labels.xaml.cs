using FUNDOOAPP.Database;
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
	public partial class Labels : ContentPage
	{
        Firebasedata firebase = new Firebasedata();
		public Labels ()
        {
          InitializeComponent();
         }

        protected async override void OnAppearing()
        {
            try
            {
                //// Overiding base class on appearing 
                base.OnAppearing();

                //// Listing all the person in the list
                var allLabels = await firebase.GetAllLabels();
                lstLabels.ItemsSource = allLabels;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                await firebase.CreateLabel(txtLabel.Text);

                //// Empty the placeholder
                txtLabel.Text = string.Empty;
                var allLabels = await firebase.GetAllLabels();
                lstLabels.ItemsSource = allLabels;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
    }
}