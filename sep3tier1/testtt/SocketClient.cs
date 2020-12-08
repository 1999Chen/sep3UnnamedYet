using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace testtt
{
    public class SocketClient
    {
        private int port = 8500;
        
        private string host = "127.0.0.1";

        private static SocketClient instance=new SocketClient();
        
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

        IPEndPoint ipEndPoint;
        Socket socket;

        private SocketClient()
        {
            ipEndPoint = new IPEndPoint(ipAddress, port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        public static SocketClient getInstance()
        {
             
            return instance;

        }
        public void send()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 8500);
            Console.WriteLine("connect!");
            
            // string s = "hahahahahahahhahaha";
            // byte[] bytes = Encoding.Default.GetBytes(s);
            // socket.Send(bytes);
            // Console.WriteLine(bytes);

            User user=new User("asd",8);
            string a = JsonSerializer.Serialize(user);
            Console.WriteLine(a);
            byte[] bytesa = Encoding.UTF8.GetBytes(a);
            socket.Send(bytesa);
            Console.WriteLine(bytesa);
            Console.WriteLine(a);
            
            
            
            byte[] rcvLenBytes = new byte[4];
            socket.Receive(rcvLenBytes);
            int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
            byte[] rcvBytes = new byte[rcvLen];
            socket.Receive(rcvBytes);
            String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);

            Console.WriteLine("Client received: " + rcv);
            
            


          



        }

      
    }
}