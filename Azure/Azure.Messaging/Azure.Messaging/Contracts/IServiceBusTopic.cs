using System;
using System.Collections.Generic;
using Azure.Storage.Queues;
using Azure.Messaging.Models;
using System.Threading.Tasks;

namespace Azure.Messaging.Contracts
{
    public interface IServiceBusTopic
    {
        Task SendMessage(string message, string topicName);
        Task<ChatMessage> ReceiveMessage(string topicName, string subscriptionName);
    }
}