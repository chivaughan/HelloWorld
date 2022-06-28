using HelloWorld.Models;
using HelloWorld.Services;
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
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            BindingContext = user;

            InitializeComponent();
        }

        public ProfilePage()
        {
            // Here, we will temporarily pass a random user object to load this page
            // This will only be used when no user object is passed from the calling page
            // by clicking the selected item in the Activity Feed tab
            // That means the user clicked the Profile tab to view his/her own profile
            // That's the only time this constructor will be called.
            // Ideally, we should load the logged in user object from our webservice
            UserService userService = new UserService();
            User user = user = userService.FetchRandomUser();

            BindingContext = user;

            InitializeComponent();
        }
    }
}