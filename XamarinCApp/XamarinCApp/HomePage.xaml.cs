using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinCApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
            var name = new Entry
            {
                Placeholder="name"
            };
            var email = new Entry
            {
                Placeholder="email"
            };
            var password = new Entry
            {
                Placeholder = "password"
            };
            var Mnumber = new Entry
            {
                Placeholder="Mobile no"
            };

            var Singup = new Button
            {
                Text = "summit"
            };

            Singup.Clicked += (Object sender, EventArgs e) =>
            {
                DisplayAlert("suceess", "register", "ok");
            };

            Content = new StackLayout
            {
                Padding =30,
                Spacing =10,
                Children =
                {
                    new Label
                    {
                        Text="Register form" , FontSize=Device.GetNamedSize (NamedSize.Large,typeof(Label)), HorizontalOptions=LayoutOptions.Center
                    },
                    name,
                    email,
                    password,
                    Mnumber,
                    Singup
                }
            };
            
			//InitializeComponent ();
		}
	}
}