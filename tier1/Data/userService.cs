using System;
using System.Collections.Generic;
using System.Linq;
using tier1.Models;
using tier1.Services;

namespace tier1.Data.Impl {
public class userService : IUserService {
    
    Sockets sockets=Sockets.getInstance();

    public userService() {
        
         sockets.start();
        
    }


    public string ValidateUser(string username, string password)
    {
        
       return sockets.Login(username,password);
        
       
       
    }

    public User RegisterUser(string username, string password)
    {
        sockets.Register(username, password);

        return new User
        {
            username = username,
            password = password
        };
    }
    
    
}
}