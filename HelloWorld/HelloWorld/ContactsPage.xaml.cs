using HelloWorld.Models;
using HelloWorld.Services;
using HelloWorld.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
       public ContactViewModel ViewModel
        {
            get { return BindingContext as ContactViewModel; }
            set { BindingContext = value; }
        }
        bool _firstLoad;
        public ContactsPage()
        {
            ViewModel = new ContactViewModel(new PageService());
            InitializeComponent();
            _firstLoad = true;
        }

        protected override void OnAppearing()
        {
            // We should execute the connection async actions here if this is the first load
            // After this execution, we should set the flag to false
            if (_firstLoad)
            {
                ViewModel.LoadContactsCommand.Execute(null);
                // Set the flag to false
                _firstLoad = false;
            }            

            base.OnAppearing();
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            ViewModel.DeleteContactCommand.Execute(menuItem.CommandParameter);
        }


        private void lstContacts_Refreshing(object sender, EventArgs e)
        {
            ViewModel.LoadContactsCommand.Execute(null);
            lstContacts.EndRefresh();
        }

        private void lstContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectContactCommand.Execute(e.SelectedItem);
        }

        
    }
}