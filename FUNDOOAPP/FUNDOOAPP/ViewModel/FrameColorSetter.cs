using FUNDOOAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FUNDOOAPP.ViewModel
{
    class FrameColorSetter :ContentPage

    {
        public static void GetColor(Note note, Frame frame)
        {
            if (note.ColorNote.Equals("Red"))
            {
                frame.BackgroundColor = Color.Red;
                return;
            }

            if (note.ColorNote.Equals("Aqua"))
            {
                frame.BackgroundColor = Color.Aqua;
                return;
            }

            if (note.ColorNote.Equals("DarkGoldenrod"))
            {
                frame.BackgroundColor = Color.DarkGoldenrod;
                return;
            }

            if (note.ColorNote.Equals("Gold"))
            {
                frame.BackgroundColor = Color.Gold;
                return;
            }

            if (note.ColorNote.Equals("GreenYellow"))
            {
                frame.BackgroundColor = Color.GreenYellow;
                return;
            }

            if (note.ColorNote.Equals("Gray"))
            {
                frame.BackgroundColor = Color.Gray;
                return;
            }

            if (note.ColorNote.Equals("Lavender"))
            {
                frame.BackgroundColor = Color.Green;
                return;
            }

            if (note.ColorNote.Equals("MintCream"))
            {
                frame.BackgroundColor = Color.MintCream;
                return;
            }

            if (note.ColorNote.Equals("White"))
            {
                frame.BackgroundColor = Color.White;
                return;
            }
            if(note.ColorNote.Equals("Green"))
            {
                frame.BackgroundColor = Color.Green;
                return;
            }
            if(note.ColorNote.Equals("Yellow"))
            {
                frame.BackgroundColor = Color.Yellow;
                return;
            }
            if (note.ColorNote.Equals("Orange"))
            {
                frame.BackgroundColor = Color.Orange;
                return;
            }
            if (note.ColorNote.Equals("Teal"))
            {
                frame.BackgroundColor = Color.Teal;
                return;
            }
            if (note.ColorNote.Equals("Purple"))
            {
                frame.BackgroundColor = Color.Purple;
                return;
            }
            if (note.ColorNote.Equals("Brown"))
            {
                frame.BackgroundColor = Color.Brown;
                return;
            }

        }
    }
}
