//-----------------------------------------------------------------------
// <copyright file="CameraPermition.xaml.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FUNDOOAPP.views.RemiderAndLocation
{
    using FUNDOOAPP.Interfaces;
    using FUNDOOAPP.Repository;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
   
    [XamlCompilation(XamlCompilationOptions.Compile)]

    /// <summary>
    /// this Remainder instance
    /// </summary>
    public partial class Remainder
     {
        /// <summary>
        /// this notesRepository instance
        /// </summary>
        NotesRepository notesRepository = new NotesRepository();

        /// <summary>
        /// this Remainder instance
        /// </summary>
        public Remainder()
         {
            this.InitializeComponent();
            mypicker.Items.Add("Does not repeat");
            mypicker.Items.Add("Daily");
            mypicker.Items.Add("Weekly");
            mypicker.Items.Add("Monthly");
            mypicker.Items.Add("Yearly");
            mypicker.Items.Add("Custom");
         }

        private async  void Button_Clicked(object sender, System.EventArgs e)
        {
                
        }
    }
}