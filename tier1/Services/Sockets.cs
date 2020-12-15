using System;
using System.Net;
using System.Net.WebSockets;
using tier1.Models;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Linq;
using Newtonsoft.Json.Linq;


namespace tier1.Services
{
    public class Sockets : ISockets
    {
        
        private static Sockets sockets = new Sockets();
        private IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

        IPEndPoint ipEndPoint;
        Socket socket;

        // private Sockets()
        // {
        //    
        // }

        public void start()
        {
            ipEndPoint = new IPEndPoint(ipAddress, 8500);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 8500);
            // Debug.WriteLine("Connection is succesfull");
            Console.WriteLine("Connected!");
            
        }

        public static Sockets getInstance()
        {
            return sockets;
        }

        public string SendAndReceive(Request request)
        {
            var json = JsonSerializer.Serialize(request);
            byte[] bytes = Encoding.UTF8.GetBytes(json + ";");
            socket.Send(bytes);
            Console.WriteLine("send ok " + bytes);

            string recv = "";
            byte[] recvBytes = new byte[1024];
            int bytesa;
            bytesa = socket.Receive(recvBytes, recvBytes.Length, 0);
            recv += Encoding.UTF8.GetString(recvBytes, 0, bytesa);
            Console.WriteLine("receive ok " + recv);
            // return JsonSerializer.Deserialize(recv);
            return recv;

        }

        // public string receive()
        // {
        //     string recv = "";
        //     byte[] recvBytes = new byte[1024];
        //     int bytes;
        //     bytes = socket.Receive(recvBytes, recvBytes.Length, 0);
        //     recv += Encoding.ASCII.GetString(recvBytes, 0, bytes);
        //     return recv;
        // }
        //

        public string Login(string username, string password)
        {
            Request request = new Request()
            {
                Type = RequestTypes.LOGIN.ToString(),
                Args = new User {username = username, password = password}
            };
            string recvStr = SendAndReceive(request);

            Console.WriteLine(recvStr);
            if (recvStr.Contains("incorrect"))
            {
                return "Username or password is incorrect";
            }
            return "login succedds";

        }

        public string Register(string username, string password)
        {
            Request request = new Request()
            {
                Type = RequestTypes.REGISTER.ToString(),
                Args = new User {username = username, password = password}
            };
            string recv = SendAndReceive(request);
            return recv;
        }
        
        public string Search(UserInfo userInfo)
        {
            Request request = new Request()
            {
                Type = RequestTypes.SEARCHUSERS.ToString(),
                Args = userInfo,
            };
            string recv = SendAndReceive(request);
            return recv;
        }
        

        public string GetUser(string username)
        {
            throw new System.NotImplementedException();
        }

        public string Edit(string username, string password,string firstname,string lastname, string hobbies,   string sex, string hometown, string description, string major, int age)
        {
            Request request = new Request
            {
                Type = RequestTypes.EDITINFO.ToString(),
                Args = new User
                {
                    username = username,
                    sex = "sex",
                    hobbies = "hobbies",
                    firstname = "firstname",
                    lastname = "lastname",
                  
                    hometown = "hometown",
                    major = "major",
                    age = 0,
                    description =" description",
                }
            };
            string recv = SendAndReceive(request);
            return recv;
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public string SendMessage(ChatMessage message)
        {
            Request request = new Request
            {
                Type = RequestTypes.SENDMESSAGE.ToString(),
                Args = message,
            };
            string recv = SendAndReceive(request);
            return recv;
        }
        
        public string GetFriendList(int id)
        {
            throw new System.NotImplementedException();
        }

        
        public string AddFriendRequest(Friend friend)
        {

            Request request = new Request()
            {

                Type = RequestTypes.SENDFRIENDREQUEST.ToString(),
                Args = friend

            };
            string recv = SendAndReceive(request);
            return recv;
            
        }

        public string Reject(int otherId)
        {
            throw new System.NotImplementedException();
        }

       
    }
}