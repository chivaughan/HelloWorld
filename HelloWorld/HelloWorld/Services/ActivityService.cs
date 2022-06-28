using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HelloWorld.Services
{
    internal class ActivityService
    {
        /// <summary>
        /// Get activities for a specified owner
        /// </summary>
        /// <param name="ownerUser"> This is the user who originally owns the post</param>
        /// <returns></returns>
        public List<Activity> GetActivities(User ownerUser)
        {
            List<Activity> activities = GetAllActivities().Where(x => x.OwnerUser.Id == ownerUser.Id).ToList();
            return activities;
        }

        // Get all activities
        private List<Activity> GetAllActivities()
        {
            UserService userService = new UserService();
            Helper helper = new Helper();
            List<Activity> activities = new List<Activity>
            {
                new Activity
                {
                    Action = "liked your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "commented on your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "followed you",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "followed you",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "shared your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "shared on your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "liked your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "shared your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "followed you",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "liked your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "commented on your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "followed you",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "followed you",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "shared your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "shared on your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "liked your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "shared your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "followed you",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new Activity
                {
                    Action = "liked your post",
                    ParticipatingUser = userService.FetchRandomUser(),
                    OwnerUser = userService.FetchRandomUser(),
                    ImageUrl = helper.FetchRandomImageUrl()
                }
            };
            return activities;
            
        }
    }
}
