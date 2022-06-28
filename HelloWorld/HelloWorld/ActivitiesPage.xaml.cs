using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld.Models;
using HelloWorld.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivitiesPage : ContentPage
    {
        public ActivitiesPage()
        {
            InitializeComponent();

            // Use the activity service to fetch the activities for a specified user and populate the list view
            ActivityService activityService = new ActivityService();

            // Lets fetch activities for a random user here
            UserService userService = new UserService();
            lstActivities.ItemsSource = activityService.GetActivities(userService.FetchRandomUser());

        }

        private void lstActivities_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            
            // Fetch the selected item as an activity
            Activity activity = lstActivities.SelectedItem as Activity;
                        
            // Navigate to the profile page with the participating user object
            Navigation.PushAsync(new ProfilePage(activity.ParticipatingUser));

            // Deselect the list view
            lstActivities.SelectedItem = null;
        }

        private void lstActivities_Refreshing(object sender, EventArgs e)
        {
            // Use the activity service to fetch the activities for a specified user and populate the list view
            ActivityService activityService = new ActivityService();

            // Lets fetch activities for a random user here
            UserService userService = new UserService();
            lstActivities.ItemsSource = activityService.GetActivities(userService.FetchRandomUser());
            lstActivities.EndRefresh();
        }
    }
}