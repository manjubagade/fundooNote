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
	public partial class SearchNotes : ContentPage
	{
        List<string> names = new List<string>
          {
                   "Kartik",
                   "Deepak",
                   "Amar",
                   "Rahul",
                   "Chetan",
                   "Girish"
           };
        public SearchNotes ()
		{
			InitializeComponent ();
            MainListView.ItemsSource = names;
		}

        private void OnBtnPressed(object sender, EventArgs e)
        {
            var keyword = MainSearchBar.Text;
            MainListView.ItemsSource =
            names.Where(name => name.ToLower().Contains(keyword.ToLower()));
        }
    }
}