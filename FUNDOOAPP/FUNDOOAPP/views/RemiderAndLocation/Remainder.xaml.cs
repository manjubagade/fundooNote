using FUNDOOAPP.Interfaces;
using FUNDOOAPP.Models;
using FUNDOOAPP.Repository;
using FUNDOOAPP.views.Dashbord;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FUNDOOAPP.views.RemiderAndLocation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
     public partial class Remainder
     {
        NotesRepository notesRepository = new NotesRepository();
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
    }
}