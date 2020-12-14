using System;
using System.Collections.Generic;
using System.Linq;
using tier1.Models;

namespace tier1.Data.Impl {
public class InMemoryUserService : IUserService {
    private List<User> users;

    public InMemoryUserService() {
        users = new[] {
            new User {
                Password = "123456",
                Role = "Manager",
                UserName = "Manager"
            },
            new User {
                Password = "123456",
                Role = "Guest",
                UserName = "Guest"
            },
            new User {
                Password = "123456",
                Role = "Admin",
                UserName = "a"
            }
        }.ToList();
    }


    public User ValidateUser(string userName, string password) {
        User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
        if (first == null) {
            throw new Exception("User not found");
        }

        if (!first.Password.Equals(password)) {
            throw new Exception("Incorrect password");
        }

        return first;
    }

    public User RegisterUser(string username, string password)
    {
        User user = new User()
        {
            Password = password,
            UserName = username,
            Role = "Admin"
        };
        users.Add(user);
        return user;
    }
    
    
}
}