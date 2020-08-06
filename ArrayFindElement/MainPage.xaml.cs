using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ArrayFindElement
{
    /// <summary>
    /// A single page to handle the methods, no classes initiated.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ClearSingleTextInputBoxes();
            ClearMultiTextInputBoxes();
        }

        private void ClearSingleTextInputBoxes()
        {
            //Remove all items from Text User Input Boxes
            TextBoxSingleArray.Text = "";
            TextBoxSingleArrayValue.Text = "";
            TextBoxSinglePosition.Text = "";
        }
        private void ClearMultiTextInputBoxes()
        {
            //Remove all items from Text User Output Boxes
            TextBoxMultiDemensionArray.Text = "";
            TextBoxMultiDemensionalValue.Text = "";
            TextBoxMultiDemensionalPosition.Text = "";
        }

        private void ButtonMultiDemensionalResetValues_Click(object sender, RoutedEventArgs e)
        {
            ClearMultiTextInputBoxes();
        }

        private async void ButtonMultiDemensionalGetValues_Click(object sender, RoutedEventArgs e)
        {
            //Find TextBox Value with a Multidemensional array
            int mdlValueMulti = int.Parse(TextBoxMultiDemensionArray.Text);
            int[,] intArrayMulti = { { 80, 0 },    { 90, 10 },   { 100, 20 },  { 110, 30 },  { 120, 40 },  { 130, 50 },  { 140, 60 },
                                     { 150, 62 },  { 160, 63 },  { 170, 64 },  { 180, 65 },  { 190, 68 },  { 200, 70 },  { 210, 72 },
                                     { 220, 74 }, { 230, 76 }, { 240, 78 }, { 250, 80 }, { 260, 82 }, { 270, 84 }, { 280, 86 },
                                     { 290, 88 }, { 300, 90 }, { 310, 92 }, { 320, 94 }, { 330, 97 }, { 340, 100 } };

            int ElementM = -1;
            int a = intArrayMulti.GetLength(0);
            int b = intArrayMulti.GetLength(1);
            int arrayLeftColumnValue = 0;
            int arrayLeftColumnValuePosition = 0;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)           
                {
                    int arrayValue = intArrayMulti[i, 0];
                    if (mdlValueMulti == arrayValue)
                    {
                        arrayLeftColumnValue = i;
                        arrayLeftColumnValuePosition = i;
                        ElementM = i;
                    }
                }
            }
            if (ElementM == -1)
            {
                MessageDialog MsgNoper = new MessageDialog("Number not Found"); //Number was not found
                await MsgNoper.ShowAsync();
            }
            else
            {
                int ReturnArrayValue = intArrayMulti[arrayLeftColumnValue, 1];
                TextBoxMultiDemensionalValue.Text = ReturnArrayValue.ToString();
                TextBoxMultiDemensionalPosition.Text = "[" + arrayLeftColumnValuePosition.ToString() + " , 0]";
            }
        }

        private void TextBoxSingleArray_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBoxSingleArray_GotFocus = e.OriginalSource as TextBox;
            textBoxSingleArray_GotFocus.SelectAll();
        }

        private void TextBoxMultiDemensionArray_GotFocus(object sender, RoutedEventArgs e)
        {
            var TextBoxMultiDemensionArray_GotFocus = e.OriginalSource as TextBox;
            TextBoxMultiDemensionArray_GotFocus.SelectAll();
        }

        private void ButtonSingleResetValues_Click(object sender, RoutedEventArgs e)
        {
            ClearSingleTextInputBoxes();
        }

        private async void ButtonSingleGetValues_Click(object sender, RoutedEventArgs e)
        {
            //Find TextBox Value with a Single Demension array
            //Here is the single Array
            int[] singleDimension = new int[5] { 1, 5, 10, 15, 20 };
            //Grab value from user input textbox for single array          
            bool intSingleTryParse = int.TryParse(TextBoxSingleArray.Text, out int ValueSingle);
            if (intSingleTryParse)   //bool is true, continue 
            {

                int ArrayValue = Array.Find(singleDimension, element => element == ValueSingle);
                if (ArrayValue > 0)
                {
                    TextBoxSingleArrayValue.Text = ArrayValue.ToString();
                    int ArrayPosition = Array.IndexOf(singleDimension, ValueSingle);
                    TextBoxSinglePosition.Text = ArrayPosition.ToString();
                }
                else
                {
                    MessageDialog MsgNotFound = new MessageDialog("Did not find number in array!");
                    await MsgNotFound.ShowAsync();
                    ClearSingleTextInputBoxes();
                }
            }
            else
            {
                MessageDialog MsgNope = new MessageDialog("You not a number!");
                await MsgNope.ShowAsync();
            }
        }
    }
}
