using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.Models;
using System.Threading.Tasks;

namespace Azure.Messaging.Contracts
{
    public class ServiceBusQueue : IServiceBusQueue
    {
        private readonly ServiceBusClient  client;

        public ServiceBusQueue(IConfiguration configuration)
        {
            client = new ServiceBusClient(configuration["AzureServiceBus:ConnectionString"]);
        }

        public async Task SendMessage(string message)
        {
            ServiceBusSender sender = client.CreateSender("messageQueue");
            ServiceBusMessage serviceMessage = new ServiceBusMessage(message);
            await sender.SendMessageAsync(serviceMessage);
            await sender.DisposeAsync();
        }

        public async Task<ChatMessage> PeekMessage()
        {
            ServiceBusReceiver receiver = client.CreateReceiver("messageQueue");
            ServiceBusReceivedMessage message = await receiver.PeekMessageAsync();
            ChatMessage chatMessage = null;
            if (message != null) {
                chatMessage = new ChatMessage(message.Body.ToString());
            }
            await receiver.DisposeAsync();
            return chatMessage;
        }

        public async Task<ChatMessage> ReceiveMessage()
        {
            ServiceBusReceiver receiver = client.CreateReceiver("messageQueue");
            ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync();
            ChatMessage chatMessage = null;
            if (message != null) {
                chatMessage = new ChatMessage(message.Body.ToString());
                await receiver.CompleteMessageAsync(message);
            }
            await receiver.DisposeAsync();
            return chatMessage;
        }
    }
}