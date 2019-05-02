using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinCApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            var emai = new Entry
            {
               Placeholder ="user name",
               PlaceholderColor =Color.Black
               
               
            };
            var password = new Entry
            {
                Placeholder = "pass word",
                PlaceholderColor=Color.Black
                
            };
            var signup = new Button
            {
                Text="sign up",
                TextColor=Color.Red,
                FontAttributes=FontAttributes.Bold
                
            };
            signup.Clicked += (object sender, EventArgs e) =>
            {
                DisplayAlert("good news", "good morning", "ok");
                Navigation.PushModalAsync(new HomePage());
            };
            // InitializeComponent();
            Content = new StackLayout
            {
                Padding = 30,
                Spacing = 10,
                Children = {
          new Label { Text = "Fundoo App", FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)), HorizontalOptions = LayoutOptions.Center },
          emai,
          password,
          signup
        }
            };
        }
    }
}
