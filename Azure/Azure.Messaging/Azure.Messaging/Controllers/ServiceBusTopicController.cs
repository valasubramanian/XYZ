using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Azure.Messaging.Contracts;
using Azure.Messaging.Models;

namespace Azure.Messaging.Controllers
{
    [ApiController]
    public class ServiceBusTopicController : Controller
    {
        private readonly ILogger<ServiceBusTopicController> _logger;
        private readonly IServiceBusTopic _serviceBusTopic;

        public ServiceBusTopicController(ILogger<ServiceBusTopicController> logger, 
                                    IServiceBusTopic serviceBusTopic)
        {
            _logger = logger;
            _serviceBusTopic = serviceBusTopic;
        }

        [HttpPost]
        [Route("api/[controller]/send")]
        public async Task<IActionResult> Send([FromBody] ChatMessage chatMessage)
        {
            await _serviceBusTopic.SendMessage(chatMessage.Message, chatMessage.TopicName);
            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/receive/{topicName}/{subscriptionName}")]
        public async Task<ChatMessage> Receive(string topicName, string subscriptionName)
        {
            return await _serviceBusTopic.ReceiveMessage(topicName, subscriptionName);
        }
    }
}
