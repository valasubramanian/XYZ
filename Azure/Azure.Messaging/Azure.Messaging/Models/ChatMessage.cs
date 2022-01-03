using System;
using System.Collections.Generic;

namespace Azure.Messaging.Models
{
    public class ChatMessage
    {
        public ChatMessage()
        {

        }
        
        public ChatMessage(string message)
        {
            this.Message = message;
        }

        public ChatMessage(string message, string topicName)
        {
            this.Message = message;
            this.TopicName = topicName;
        }

        public string Message { get; set; }
        public string TopicName { get; set; }
    }
}