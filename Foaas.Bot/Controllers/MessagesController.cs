using System.Threading.Tasks;
using System.Web.Http;
using Foaas.Bot.Extensions;
using FOAASClient;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;

namespace Foaas.Bot.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private const string FromName = "Foaas Bot";
        private static readonly IFoaasClient FoaasClient;

        static MessagesController()
        {
            if (FoaasClient == null)
            {
                FoaasClient = new FoaasClient();
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
                if (message.Text.IsHi())
                {
                    return message.CreateReplyMessage("Hey, fuck face");
                }

                var response = await FoaasClient.Off(message.From.Name, FromName);

                // return our reply to the user
                return message.CreateReplyMessage(response.Message);
            }

            return HandleSystemMessage(message);
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
                var replyMessage = message.CreateReplyMessage("Hey, fuck face what's your name?");
                return replyMessage;
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