﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;

namespace sep3tier3.Models
{
    public class ChatMessage
    {
        public string nameSend { set; get; }
        public string nameReceived { set; get; }

        [Key, NotNull] 
        public int id { set; get; }

        public string message { set; get; }
        public DateTime date { set; get; }
        public byte[] image { set; get; }
        public bool online { set; get; }
    }
}