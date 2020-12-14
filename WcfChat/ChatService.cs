using System.Collections.Generic;
using System.ServiceModel;

namespace WcfChat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService :IChatService
    {
        private ChatEngine mainEngine = new ChatEngine();

        public ChatUser ClientConnect(string userName)
        {
            return mainEngine.AddNewChatUser(new ChatUser() { UserName = userName });        
        }

        public List<ChatMessage> GetNewMessages(ChatUser user)
        {
            return mainEngine.GetNewMessages(user);
        }

        public void SendNewMessage(ChatMessage newMessage)
        {
            mainEngine.AddNewMessage(newMessage);
        }

        public void SendNewMessagePrivado(ChatMessage newMessage, List<string> listaUsuarios)
        {
            mainEngine.AddNewMessage(newMessage, listaUsuarios);
        }

        public List<ChatUser> GetAllUsers()
        {
            return mainEngine.ConectedUsers;
        }

        public void RemoveUser(ChatUser user)
        {
            mainEngine.RemoveUser(user);
        }
    }
}
