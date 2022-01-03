using System;
using System.Collections.Generic;
using Azure.Storage.Queues;
using Azure.Messaging.Models;
using System.Threading.Tasks;

namespace Azure.Messaging.Contracts
{
    public interface IServiceBusQueue
    {
        Task SendMessage(string message);
        Task<ChatMessage> PeekMessage();
        Task<ChatMessage> ReceiveMessage();
    }
}