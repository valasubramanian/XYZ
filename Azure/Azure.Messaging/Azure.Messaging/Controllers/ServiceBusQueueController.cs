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
    public class ServiceBusQueueController : Controller
    {
        private readonly ILogger<ServiceBusQueueController> _logger;
        private readonly IServiceBusQueue _serviceBusQueue;

        public ServiceBusQueueController(ILogger<ServiceBusQueueController> logger, 
                                    IServiceBusQueue serviceBusQueue)
        {
            _logger = logger;
            _serviceBusQueue = serviceBusQueue;
        }

        [HttpPost]
        [Route("api/[controller]/send")]
        public async Task<IActionResult> Send([FromBody] ChatMessage chatMessage)
        {
            await _serviceBusQueue.SendMessage(chatMessage.Message);
            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/peek")]
        public async Task<ChatMessage> Peek()
        {
            return await _serviceBusQueue.PeekMessage();
        }

        [HttpGet]
        [Route("api/[controller]/receive")]
        public async Task<ChatMessage> Receive()
        {
            return await _serviceBusQueue.ReceiveMessage();
        }
    }
}
