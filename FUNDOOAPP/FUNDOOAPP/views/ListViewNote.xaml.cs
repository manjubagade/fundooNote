﻿using FUNDOOAPP.Interfaces;
using FUNDOOAPP.Models;
using FUNDOOAPP.Repository;
using FUNDOOAPP.views.Dashbord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FUNDOOAPP.DataFile.Enum;

namespace FUNDOOAPP.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListViewNote : ContentPage
	{

        private NotesRepository notesRepository = new NotesRepository();
        public ListViewNote ()
		{
			InitializeComponent ();
		}


        public void ListGridView(IList<Note> list)
        {
            try
            {
                GridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(350) });
                GridLayout.Margin = 5;
                int rowCount = list.Count;



                //ListView listView = new ListView() { HasUnevenRows = true };

                var productIndex = 0;
                var indexe = -1;

                /// Iterate a single row at a time to add two notes in one row
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    /// iterating column to add per note in each column in a single row
                    for (int columnIndex = 0; columnIndex < 1; columnIndex++)
                    {
                        Note data = null;
                        indexe++;

                        /// to maintain the size of array to avoid exception
                        if (indexe < list.Count)
                        {
                            data = list[indexe];
                        }

                        /// Once every note is added in respective column and row than it will break
                        if (productIndex >= list.Count)
                        {
                            break;
                        }

                        productIndex += 1;
                        var index = rowIndex * columnIndex + columnIndex;

                        var label = new Xamarin.Forms.Label
                        {
                            Text = data.Title,
                            TextColor = Color.Black,
                            FontAttributes = FontAttributes.Bold,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start,
                        };

                        var labelKey = new Xamarin.Forms.Label
                        {
                            Text = data.Key,
                            IsVisible = false
                        };

                        var content = new Xamarin.Forms.Label
                        {
                            Text = data.Notes,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start,
                        };

                        StackLayout layout = new StackLayout()
                        {
                            Spacing = 2,
                            Margin = 2,
                            BackgroundColor = Color.White
                        };
                        var tapGestureRecognizer = new TapGestureRecognizer();
                        layout.Children.Add(labelKey);
                        layout.Children.Add(label);
                        layout.Children.Add(content);
                        layout.GestureRecognizers.Add(tapGestureRecognizer);
                        layout.Spacing = 2;
                        layout.Margin = 2;
                        layout.BackgroundColor = Color.White;

                        var frame = new Frame();
                        frame.BorderColor = Color.Black;
                        frame.Content = layout;
                        tapGestureRecognizer.Tapped += (object sender, EventArgs args) =>
                        {
                            StackLayout layout123 = (StackLayout)sender;
                            IList<View> item = layout123.Children;
                            Xamarin.Forms.Label KeyValue = (Xamarin.Forms.Label)item[0];
                            var Keyval = KeyValue.Text;
                            Navigation.PushAsync(new UpdateNote(Keyval));
                        };

                        GridLayout.Children.Add(frame, columnIndex, rowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected async override void OnAppearing()
        {
            var uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            var notes = await this.notesRepository.GetNotesAsync(uid);
            IList<Note> listNote = new List<Note>();
            if (notes != null)
            {
                foreach (var item in notes)
                {
                    if (item.noteType == NoteType.isNote)
                    {
                        listNote.Add(item);
                    }
                }
                this.ListGridView(listNote);
            }

        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
          await Navigation.PushModalAsync(new Masterpage());
        }
    }
}