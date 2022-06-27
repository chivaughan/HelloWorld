using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesPage : ContentPage
    {
        List<string> lstQuotes = new List<string>();
        int indexToMoveTo; 
        public QuotesPage()
        {
            InitializeComponent();
            slider.Maximum = 360;
            slider.Value = 50;
            lstQuotes = new List<String> { "Quote 1", "Quote 2", "Quote 3", "Quote 4", "Quote 5" };
            lblQuote.Text = lstQuotes[0];
            lblCurrentIndex.Text = lstQuotes.IndexOf(lstQuotes[0]).ToString();
            
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            lstQuotes = new List<String> { "Quote 1", "Quote 2", "Quote 3", "Quote 4", "Quote 5" };

            // Calculate the index to move to based on the current index
            indexToMoveTo = int.Parse(lblCurrentIndex.Text) + 1;

            // If the indexToMoveTo is <= (the list count - 1), we move to that index,
            // otherwise, start all over and move to the first item in the list
            if (indexToMoveTo <= (lstQuotes.Count - 1))
            {
                lblQuote.Text = lstQuotes[indexToMoveTo];
                lblCurrentIndex.Text = lstQuotes.IndexOf(lstQuotes[indexToMoveTo]).ToString();
            }
            else
            {
                lblQuote.Text = lstQuotes[0];
                lblCurrentIndex.Text = lstQuotes.IndexOf(lstQuotes[0]).ToString();
            }

        }
    }
}