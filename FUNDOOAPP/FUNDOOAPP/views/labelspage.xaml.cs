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
         public labelspage()
         {
         this.InitializeComponent();
       }
        Firebasedata firebasedata = new Firebasedata();

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
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

        /// <summary>
        /// Handles the CheckChanged event of the CheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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