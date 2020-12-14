using System;
using System.Collections.Generic;
using System.Linq;

namespace WcfChat
{
    public class ChatEngine
    {
        private List<ChatUser> conectedUsers = new List<ChatUser>();
        private Dictionary<string,List<ChatMessage>> incomingMessages= new Dictionary<string,List<ChatMessage>>();      
        public List<ChatUser> ConectedUsers
        {
            get { return conectedUsers; }
        }

        public ChatUser AddNewChatUser(ChatUser user)
        {
            var exists = from ChatUser e in this.ConectedUsers where e.UserName == user.UserName select e;

            if (exists.Count() == 0)
            {
                this.ConectedUsers.Add(user);
                incomingMessages.Add(user.UserName, new List<ChatMessage>() {//Bienvenida al chat general
                    new ChatMessage(){User=user,Message="66wLAFzH9TboVJdmoVGqE7fN1O8unLss3kGYDs4iw2Q=",Date=DateTime.Now}
                });

                Console.WriteLine($"Nuevo usuario: {user}");
                return user;
            }
            else
            {
                Console.WriteLine($"Se ha intentado conectar una persona con el usuario: {user}");
                return null;
            }     
        }

        public void AddNewMessage(ChatMessage newMessage)
        {
            Console.WriteLine(newMessage.User.UserName+"  :"+newMessage.Message+"  "+newMessage.Date);
            
            //se envian mensajes a todos los usuarios conectados menos al que lo envia
            foreach (var user in this.ConectedUsers)
            {
                if (!newMessage.User.UserName.Equals(user.UserName))
                {
                    incomingMessages[user.UserName].Add(newMessage);                    
                }
            }
        }

        public void AddNewMessage(ChatMessage newMessage, List<string> listaUsuarios)
        {
            Console.WriteLine(newMessage.User.UserName + "  :" + newMessage.Message + "  " + newMessage.Date);

            //se envian mensajes a todos los usuarios conectados menos al que lo envia
            foreach (var user in listaUsuarios)
            {
                if (!newMessage.User.UserName.Equals(user))
                {
                    incomingMessages[user].Add(newMessage);
                }
            }
        }

        public List<ChatMessage> GetNewMessages(ChatUser user)
        {
            //se obtienen los nuevos mensajes
            List<ChatMessage> myNewMessages = incomingMessages[user.UserName];  
            //se borran de la "bandeja de entrada"
            incomingMessages[user.UserName] = new List<ChatMessage>();

            if (myNewMessages.Count > 0)
            {
                return myNewMessages;
            }
            else
            {
                return null;
            }
        }

        public void RemoveUser(ChatUser user)
        {
            this.ConectedUsers.RemoveAll(u=>u.UserName==user.UserName);
        }
    }
}
