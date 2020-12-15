using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sep3tier3.Data;
using sep3tier3.Models;

namespace sep3tier3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class usersController : ControllerBase
    {
        private readonly IUserService userService;

        public usersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User loginuser)
        {
            Console.WriteLine("t3 API LOGIN");
            var result = userService.LoginUser(loginuser.username,loginuser.password);

            if (result == "F")
            {
                Console.WriteLine("tier 3 log in data wrong");
                return BadRequest(new {message = "Username or password is incorrect"});
            }

            return Ok();
        }
       

        [HttpPost]
        public IActionResult Register([FromBody] User registeruser)
        {
            var user = userService.RegisterUser(registeruser);

            if (user == null)
            {
                return BadRequest(new {message = "user exists"});
            }

            Console.WriteLine("asdasd");
            return Ok(user);
        }


        [HttpPut("{username}")]
        public IActionResult EditUserInfo(string username,[FromBody] User tobeEdituser)
        {
            try
            {
                //Update user
                userService.editInfo(tobeEdituser);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new {message = e.Message});
            }
        }


        [HttpGet]
        public IActionResult GetAllUsers()
        {
           Console.WriteLine("GET USETS");
            return Ok(userService.getAllUsers());
           
        }
        
        
        [HttpGet("{username}")]
        public IActionResult GetUsersByInfo()
        {
           
            return Ok(userService.getAllUsers());
           
        }
        
        
        

        [HttpGet("searchUsers")]
        public IActionResult SearchUsers(int minage,int maxage,[FromBody] User userTo)
        {
            var list = userService.getUsersByInfo(userTo.firstname, userTo.lastname, userTo.sex,
                userTo.major, userTo.hometown, maxage, minage, userTo.hobbies);
            return Ok(list);
        }

        [HttpPost("chatMessages")]
        public IActionResult storeMessage([FromBody] ChatMessage chatMessage)
        {
            userService.storeMessage(chatMessage);
            return Ok();
        }
        
        
        
        
        
        
    }
}