using HelloWorld.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Models
{
    internal class Activity
    {
        public string FullDescription
        {
            get { return ParticipatingUser.Name + " " + Action; }
            set { }
        }
        public string Action { get; set; }
        public string ImageUrl { get; set; }

        /// <summary>
        /// This is the user who comments, likes, shares a post or follows another user
        /// </summary>
        public User ParticipatingUser { get; set; }

        /// <summary>
        /// This is the user who owns the post/picture
        /// </summary>
        public User OwnerUser { get; set; }

        
    }
}
