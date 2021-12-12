using System;
using System.Collections.Generic;

namespace Azure.Messaging.Models
{
    public class ChatMessage
    {
        public ChatMessage(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}