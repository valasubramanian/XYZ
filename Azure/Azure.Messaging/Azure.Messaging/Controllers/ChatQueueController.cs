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
    public class ChatQueueController : Controller
    {
        private readonly ILogger<ChatQueueController> _logger;
        private readonly IQueueService _queueService;

        public ChatQueueController(ILogger<ChatQueueController> logger, 
                                    IQueueService queueService)
        {
            _logger = logger;
            _queueService = queueService;
        }

        [HttpPost]
        [Route("api/[controller]/send")]
        public IActionResult Send([FromBody] ChatMessage chatMessage)
        {
            _queueService.SendMessage(chatMessage.Message);
            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/peek")]
        public ChatMessage Peek()
        {
            return _queueService.PeekMessage();
        }

        [HttpGet]
        [Route("api/[controller]/receive")]
        public ChatMessage Receive()
        {
            return _queueService.ReceiveMessage();
        }
    }
}
