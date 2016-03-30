﻿using System.Threading.Tasks;
using System.Web.Http;
using FOAASClient;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;

namespace Foaas.Bot.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private static readonly IFoaasClient _foaasClient;

        static MessagesController()
        {
            if (_foaasClient == null)
            {
                _foaasClient = new FoaasClient();
            }
        }

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                var response = await _foaasClient.Off(message.Text, "Foass Bot");

                // return our reply to the user
                return message.CreateReplyMessage(response.Message);
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}