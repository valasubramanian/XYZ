using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.Models;
using System.Threading.Tasks;

namespace Azure.Messaging.Contracts
{
    public class ServiceBusTopic : IServiceBusTopic
    {
        private readonly ServiceBusClient  client;

        public ServiceBusTopic(IConfiguration configuration)
        {
            client = new ServiceBusClient(configuration["AzureServiceBus:ConnectionString"]);
        }

        public async Task SendMessage(string message, string topicName)
        {
            ServiceBusSender sender = client.CreateSender(topicName);
            ServiceBusMessage serviceMessage = new ServiceBusMessage(message);
            await sender.SendMessageAsync(serviceMessage);
            await sender.DisposeAsync();
        }

        public async Task<ChatMessage> ReceiveMessage(string topicName, string subscriptionName)
        {
            ServiceBusReceiver receiver = client.CreateReceiver(topicName, subscriptionName);
            ChatMessage chatMessage = null;
            try 
            {
                ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
                if (message != null) {
                    chatMessage = new ChatMessage(message.Body.ToString());
                    await receiver.CompleteMessageAsync(message);
                }
            }
            finally
            {
                await receiver.DisposeAsync();
            }
            return chatMessage;
        }
    }
}