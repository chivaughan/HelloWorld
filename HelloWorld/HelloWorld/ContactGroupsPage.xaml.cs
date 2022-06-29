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
    public partial class ContactGroupsPage : ContentPage
    {
        public ContactGroupsPage()
        {
            InitializeComponent();
            lstContactGroups.ItemsSource = new List<string>
            {
                "Family",
                "Friends",
                "Work",
                "School"
            };
        }

        public ListView ContactGroups
        {
            get { return lstContactGroups; }
            set { }
        }
    }
}