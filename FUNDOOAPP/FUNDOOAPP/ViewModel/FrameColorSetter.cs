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
            if (note.Color.Equals("Red"))
            {
                frame.BackgroundColor = Color.Red;
                return;
            }

            if (note.Color.Equals("Aqua"))
            {
                frame.BackgroundColor = Color.Aqua;
                return;
            }

            if (note.Color.Equals("DarkGoldenrod"))
            {
                frame.BackgroundColor = Color.DarkGoldenrod;
                return;
            }

            if (note.Color.Equals("Gold"))
            {
                frame.BackgroundColor = Color.Gold;
                return;
            }

            if (note.Color.Equals("GreenYellow"))
            {
                frame.BackgroundColor = Color.GreenYellow;
                return;
            }

            if (note.Color.Equals("Gray"))
            {
                frame.BackgroundColor = Color.Gray;
                return;
            }

            if (note.Color.Equals("Lavender"))
            {
                frame.BackgroundColor = Color.Green;
                return;
            }

            if (note.Color.Equals("MintCream"))
            {
                frame.BackgroundColor = Color.MintCream;
                return;
            }

            if (note.Color.Equals("White"))
            {
                frame.BackgroundColor = Color.White;
                return;
            }



        }
    }
}
