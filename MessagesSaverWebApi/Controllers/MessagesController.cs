using Messages.Core;
using MessagesSaver.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagesSaverWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {

        private readonly ILogger<MessagesController> _logger;
        private IMessagesServices _messagesServices;

        public MessagesController(ILogger<MessagesController> logger, IMessagesServices messageServices)
        {
            _logger = logger;
            _messagesServices = messageServices;
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            return Ok(_messagesServices.GetMessages());
        }

        [HttpGet("{id}", Name = "GetMessage")]
        public IActionResult GetMessage(int id)
        {
            return Ok(_messagesServices.GetMessage(id));
        }


        [HttpPost]
        public IActionResult CreateNote(Message message)
        {
            var newMessage = _messagesServices.CreateMessage(message);
            return CreatedAtRoute("GetMessage", new { newMessage.Id }, newMessage);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            _messagesServices.DeleteMessage(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditMessage([FromBody] Message message)
        {
            _messagesServices.EditMessage(message);
            return Ok();
        }
    }
}
