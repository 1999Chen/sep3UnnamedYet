using System;

namespace tier1.Models
{
    public class ChatMessage
    {
        public string nameSend { get; set; }
        public string nameRecv { get; set; }
        public string message { set; get; }
        public DateTime date { set; get; }
        public byte[] image { set; get; }
    }
}