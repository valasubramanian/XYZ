using System;
using System.Collections.Generic;
using Azure.Storage.Queues;
using Azure.Messaging.Models;

namespace Azure.Messaging.Contracts
{
    public interface IQueueService
    {
        void SendMessage(string message);
        ChatMessage PeekMessage();
        ChatMessage ReceiveMessage();
    }
}