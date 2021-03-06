﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sep3tier3.DataAccess;
using sep3tier3.Models;



namespace sep3tier3.Data
{
    public class userService : IUserService
    {
        private string msgFile = "users.json";
       
        sepDBContext dbcontext ;
        friendService _friendService ;

        public userService()
        {
            dbcontext = new sepDBContext();
            _friendService = new friendService();
        }

       

        public User RegisterUser(User user)
        {
            if (dbcontext.Users.Any(x => x.username == user.username))
            {
                return null;
            }
            
            dbcontext.Users.Add(user);
            dbcontext.SaveChanges();
            return user;
        }

        public string LoginUser(string username,string password)
        {
            Console.WriteLine("loging userService");
            var existingUser = dbcontext.Users.SingleOrDefault(x => x.username == username);

            if (existingUser != null)
            {
                if (existingUser.password.Equals(password))
                {
                    return "T";
                }

                return "F";
            }

            return "F";
        }

        public void editInfo(User user)
        {
            var loginUser = dbcontext.Users.Find(user.username);
            loginUser.firstname = user.firstname;
            loginUser.lastname = user.lastname;
            loginUser.sex = user.sex;
            loginUser.age = user.age;
            loginUser.major = user.major;
            loginUser.description = user.description;
            loginUser.hobbies = user.hobbies;
            loginUser.hometown = user.hometown;
            dbcontext.SaveChanges();
        }

        public List<User> getAllUsers()
        {
            var IEList= dbcontext.Users;
            var list=new List<User>();
            foreach (var user in IEList)
            {
                list.Add(user);
            }

            return list;
        }

        public List<User> getUsersByInfo(string firstname, string lastname, string sex, 
            string major, string hometown, int maxage, int minage, string hobbies)
        {
            var users = getAllUsers();

            List<User> list = new List<User>();

            foreach (User user in users)
            {
                if (user.firstname.Contains(firstname) && user.lastname.Contains(lastname) && user.sex.Contains(sex) &&
                    user.age >= minage && user.age <= maxage &&
                    user.hobbies.Contains(hobbies) && user.major.Contains(major) && user.hometown.Contains(hometown))
                {
                    list.Add(user);
                }
            }

            return list;
        }

        public void storeMessage(ChatMessage chatMessage)
        {
            dbcontext.ChatMessages.Add(chatMessage);
        }

        public void addFriend(User user1, User user2)
        {
            Friend friend = new Friend
            {
                username1 = user1.username,
                username2 = user2.username,
                accept = false,
            };
            dbcontext.Friends.Add(friend);
            dbcontext.SaveChanges();
        }


        public List<Friend> getAllFriends(User user)
        {
            var friends = _friendService.getFriends();

            List<Friend> list = new List<Friend>();

            foreach (var friend in friends)
            {
                if (friend.username1.Equals(user.username) || friend.username2.Equals(user.username))
                {
                    list.Add(friend);
                }
            }

            return list;
        }
    }
}