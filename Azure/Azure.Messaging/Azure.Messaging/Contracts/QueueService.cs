using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure.Messaging.Models;

namespace Azure.Messaging.Contracts
{
    public class QueueService : IQueueService
    {
        private readonly IConfiguration _configuration;
        private readonly QueueClient _queueClient;

        public QueueService(IConfiguration configuration)
        {
            _configuration = configuration;
            _queueClient = new QueueClient(_configuration["AzureStorage:ConnectionString"], "chat-queue", new QueueClientOptions { MessageEncoding = QueueMessageEncoding.Base64 });
        }

        public void SendMessage(string message) 
        {
            _queueClient.CreateIfNotExists();
            if (_queueClient.Exists())
                _queueClient.SendMessage(message);
        }

        public ChatMessage PeekMessage() 
        {
            ChatMessage chatMessage = null;
            if (_queueClient.Exists()) {
                var peekMessage = _queueClient.PeekMessage();
                if(peekMessage != null)
                    chatMessage = new ChatMessage(peekMessage.Value.MessageText);
            }
            return chatMessage;
        }

        public ChatMessage ReceiveMessage()
        {
            ChatMessage chatMessage = null;
            if (_queueClient.Exists()) {
                var nextMessage = _queueClient.ReceiveMessage();
                if(nextMessage != null) {
                    chatMessage = new ChatMessage(nextMessage.Value.MessageText);
                    _queueClient.DeleteMessage(nextMessage.Value.MessageId, nextMessage.Value.PopReceipt);
                }
            }
            return chatMessage;
        }
    }
}