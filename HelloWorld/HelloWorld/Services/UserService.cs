using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HelloWorld.Services
{
    internal class UserService
    {        
        private List<User> GetAllUsers()
        {
            Helper helper = new Helper();            
            List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Chinedu Emmanuel Obi aka Akudinanwata Nanka",
                    Description = "Software Engineer & Business Developer",
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new User
                {
                    Id = 2,
                    Name = "Obinna Obi",
                    Description = "Systems Engineer & Game Developer",
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new User
                {
                    Id = 3,
                    Name = "Chizoba Obi",
                    Description = "Guest Service Executive",
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new User
                {
                    Id = 4,
                    Name = "Nkechi Obi",
                    Description = "Banker",
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new User
                {
                    Id = 5,
                    Name = "Esther Anyaora",
                    Description = "Model and Nutritionist",
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new User
                {
                    Id = 6,
                    Name = "Chioma Onyeka",
                    Description = "Chemist",
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new User
                {
                    Id = 7,
                    Name = "Ifeoma Obi",
                    Description = "Pharmacist",
                    ImageUrl = helper.FetchRandomImageUrl()
                },
                new User
                {
                    Id = 8,
                    Name = "Chidiebere Nwachukwu",
                    Description = "Trader",
                    ImageUrl = helper.FetchRandomImageUrl()
                }
            };
            return users;
        }

        public User FetchRandomUser()
        {
            int usersCount = GetAllUsers().Count();
            Random rand = new Random();
            int randomIndex = rand.Next(usersCount);
            User user = GetAllUsers()[randomIndex];
            return user;
        }
    }
}
