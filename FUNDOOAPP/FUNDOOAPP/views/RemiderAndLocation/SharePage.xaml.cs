﻿using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
	public partial class SharePage : PopupPage
    {
		public SharePage ()
		{
			InitializeComponent ();

		}

        private void Button_Clicked(object sender, EventArgs e)
        {
             PopupNavigation.Instance.PopAsync(true);
        }
    }
}